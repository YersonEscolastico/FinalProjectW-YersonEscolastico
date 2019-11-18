using BLL;
using Entidades;
using sCarDealerW.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sCarDealerW.Registros
{
    public partial class rVentas : System.Web.UI.Page
    {
        Ventas v = new Ventas();

        List<VentasDetalle> ListaDetalle = new List<VentasDetalle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VentasGridView.DataSource = null;
                VentasGridView.DataBind();
                VentaIdTextBox.Text = "0";
                PrecioTextBox.Text = "0";
                SubtotalLabel.Text = "0";
                TotalLabel.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarDropDownList();
            }
        }

        protected void BindGrid()
        {
            if (ViewState["AnVentasalisis"] != null)
            {
                VentasGridView.DataSource = ((Ventas)ViewState["Ventas"]).Detalle;
                VentasGridView.DataBind();
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void LimpiarCampos()
    {
            VentaIdTextBox.Text = "0";
            ClienteDropDownList.SelectedIndex = 0;
            UsuarioDropDownList.SelectedIndex = 0;
            FechaRegistroTextBox.Text = "";
            VehiculoDropDownList.SelectedIndex = 0;
            PrecioTextBox.Text = "0";
            TotalLabel.Text = 0.ToString();
            SubtotalLabel.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            VentasGridView.DataSource = null;
            VentasGridView.DataBind();
            Ventas Servicios = new Ventas();
        }


    public void LlenarCampos(Ventas ventas)
    {
        decimal precio = ventas.Total;

        if (precio < 0)
            precio = precio * (-1);
       
            VentaIdTextBox.Text = ventas.VentaId.ToString();
            ClienteDropDownList.Text = ventas.ClienteId.ToString();
            UsuarioDropDownList.Text = ventas.UsuarioId.ToString();
            TotalLabel.Text = ventas.Total.ToString();
            SubtotalLabel.Text = ventas.SubTotal.ToString();
            PrecioTextBox.Text = Convert.ToString(precio);
            FechaRegistroTextBox.Text = ventas.FechaRegistro.ToString("yyyy-MM-dd");
            ViewState["VentasDetalle"] = ventas.Detalle;
            VentasGridView.DataSource = ViewState["VentasDetalle"];
            VentasGridView.DataBind();
    }

    private Ventas LlenaClase()
    {
            Ventas ventas = new Ventas();

            ventas.FechaVenta = DateTime.Now;
            ventas.FechaRegistro = DateTime.Now;
            ventas.VentaId = Utils.ToInt(VentaIdTextBox.Text);
            ventas.ClienteId = Utils.ToInt(ClienteDropDownList.Text);
            ventas.UsuarioId = Utils.ToInt(UsuarioDropDownList.Text);
            ventas.Total = Convert.ToDecimal(TotalLabel.Text);
            ventas.SubTotal = Convert.ToDecimal(SubtotalLabel.Text);
            ventas.Detalle = (List<VentasDetalle>)ViewState["VentasDetalle"];

            return ventas;
    }

    private bool ExisteEnLaBaseDeDatos()
    {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas Servicios = db.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (Servicios != null);

    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
            Ventas ventas;
            bool paso = false;

            ventas = LlenaClase();

            if (VentaIdTextBox.Text == 0.ToString())
            {
                paso = RepositorioVentas.Guardar(ventas);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");
                    return;
                }
                paso = RepositorioVentas.Modificar(ventas);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            LimpiarCampos();
     }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = repositorio.Buscar(Utils.ToInt(VentaIdTextBox.Text));

            if (ventas != null)
            {
                LlenarCampos(ventas);

                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
                LimpiarCampos();
            }

            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioVentas repositorio = new RepositorioVentas();
            int id = Utils.ToInt(VentaIdTextBox.Text);

            var Ventas = RepositorioVentas.Buscar(id);

            if (Ventas != null)
            {
                if (RepositorioVentas.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado Exitosamente!!", "Exito", "info");
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "Fallo!! No se Puede Eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }


        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();
            Ventas venta = new Ventas();

            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculos = new Vehiculos();
            int id = ToInt(VehiculoDropDownList.SelectedValue);
            vehiculos = repositorio.Buscar(id);


            if (IsValid)
            {
                DateTime date = DateTime.Now.Date;
                decimal precio = Convert.ToDecimal(PrecioTextBox.Text);
                int VehiculoId = Utils.ToInt(VehiculoDropDownList.SelectedValue);
                var subtotal = vehiculos.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                string descripcion = VehiculoDropDownList.SelectedItem.ToString();

                if (VentasGridView.Rows.Count != 0)
                {
                    venta.Detalle = (List<VentasDetalle>)ViewState["VentasDetalle"];
                }
                VentasDetalle vd = new VentasDetalle();
                venta.Detalle.Add(new VentasDetalle(0, vd.VentaId, VehiculoId, subtotal, descripcion));

                ViewState["VentasDetalle"] = venta.Detalle;
                VentasGridView.DataSource = ViewState["VentasDetalle"];
                VentasGridView.DataBind();
                LlenaValores();
                CalTotal();
            }
        }

        private void CalTotal()
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();

            if (VentasGridView.DataSource != null)
            {
                detalle = (List<VentasDetalle>)VentasGridView.DataSource;
            }
            decimal Total = 0;

            foreach (var item in detalle)
            {
                Total += item.SubTotal;
            }
            TotalLabel.Text = Total.ToString();
            SubtotalLabel.Text = Total.ToString();
        }


        private void LlenaValores()
        {
            RepositorioVentas repositorio = new RepositorioVentas();
            decimal total = 0;
            decimal SubTotal = 0;

            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["VentasDetalle"];
            foreach (var item in lista)
            {
                total += item.SubTotal;
            }
            TotalLabel.Text = total.ToString();
            SubtotalLabel.Text = SubTotal.ToString();
        }

        private void VaciaValores()
        {
            decimal total = Utils.ToDecimal(TotalLabel.Text);
            decimal Sub = Utils.ToDecimal(SubtotalLabel.Text);
            decimal total2 = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["VentasDetalle"];
            foreach (var item in lista)
            {
                total2 = item.SubTotal;
            }
            total = total - total2;
            Sub = Sub - total2;

            TotalLabel.Text = total.ToString();
            SubtotalLabel.Text = total.ToString();
        }

        protected void PrecioDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();
            Vehiculos s = new Vehiculos();
            int.TryParse(VehiculoDropDownList.SelectedValue, out id);
            s = db.Buscar(id);
            PrecioTextBox.Text = Convert.ToString(s.Precio);
        }

        protected void VentasGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VentasGridView.DataSource = ViewState["VentasDetalle"];
            VentasGridView.PageIndex = e.NewPageIndex;
            VentasGridView.DataBind();
        }

        protected void VentasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<Vehiculos, bool>> filtro = p => true;
                RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
                var lista = repositorio.GetList(c => true);
                var combos = repositorio.Buscar(lista[index].VehiculoId);

                VaciaValores();
                ((List<VentasDetalle>)ViewState["VentasDetalle"]).RemoveAt(index);
                VentasGridView.DataSource = ViewState["VentasDetalle"];
                VentasGridView.DataBind();
            }
        }


        protected void VentasGridVie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<Vehiculos, bool>> filtro = p => true;
                RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
                var lista = repositorio.GetList(c => true);
                var combos = repositorio.Buscar(lista[index].VehiculoId);

                VaciaValores();
                ((List<VentasDetalle>)ViewState["VentasDetalle"]).RemoveAt(index);
                VentasGridView.DataSource = ViewState["VentasDetalle"];
                VentasGridView.DataBind();
            }
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<Clientes> clientes = new RepositorioBase<Clientes>();
            ClienteDropDownList.Items.Clear();
            ClienteDropDownList.DataSource = clientes.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.DataBind();

            RepositorioBase<Vehiculos> ve = new RepositorioBase<Vehiculos>();
            VehiculoDropDownList.Items.Clear();
            VehiculoDropDownList.DataSource = ve.GetList(x => true);
            VehiculoDropDownList.DataValueField = "VehiculoId";
            VehiculoDropDownList.DataTextField = "Descripcion";
            VehiculoDropDownList.DataBind();

            RepositorioBase<Usuarios> vee = new RepositorioBase<Usuarios>();
            UsuarioDropDownList.Items.Clear();
            UsuarioDropDownList.DataSource = vee.GetList(x => true);
            UsuarioDropDownList.DataValueField = "UsuarioId";
            UsuarioDropDownList.DataTextField = "Usuarioss";
            UsuarioDropDownList.DataBind();

            ViewState["Ventas"] = new Ventas();
        }

        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }


    }
}