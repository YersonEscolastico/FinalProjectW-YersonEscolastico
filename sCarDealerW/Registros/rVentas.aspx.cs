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
                LimpiarCampos();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarDropDownList();

                ViewState["Ventas"] = new Ventas();
            }
        }
        protected void BindGrid()
        {
            if (ViewState["Ventas"] != null)
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
            PrecioTextBox.Text = "0";
            TotalTextBox.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ViewState["Ventas"] = new Ventas();
            VentasGridView.DataSource = null;
            this.BindGrid();
 
        }


    public void LlenarCampos(Ventas ventas)
    {

            int id;
            RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();
            Vehiculos s = new Vehiculos();
            int.TryParse(VehiculoDropDownList.SelectedValue, out id);
            s = db.Buscar(id);
            decimal precio = s.Precio;

            if (precio < 0)
            precio = precio * (-1);
       
            VentaIdTextBox.Text = ventas.VentaId.ToString();
            ClienteDropDownList.Text = ventas.ClienteId.ToString();
            TotalTextBox.Text = ventas.Total.ToString();
            PrecioTextBox.Text = Convert.ToString(s.Precio);
            FechaRegistroTextBox.Text = ventas.FechaRegistro.ToString("yyyy-MM-dd");
            ViewState["Ventas"] = ventas;
            this.BindGrid();
        }

    private Ventas LlenaClase()
    {
            Ventas ventas = new Ventas();
            ventas = (Ventas)ViewState["Ventas"];
            ventas.FechaVenta = DateTime.Now;
            ventas.FechaRegistro = DateTime.Now;
            ventas.VentaId = Utils.ToInt(VentaIdTextBox.Text);
            ventas.ClienteId = Utils.ToInt(ClienteDropDownList.Text);
            ventas.UsuarioId = Utils.ToInt(UsuarioDropDownList.Text);
            ventas.VehiculoId = Utils.ToInt(VehiculoDropDownList.Text);
            ventas.Total = Convert.ToDecimal(TotalTextBox.Text);
            return ventas;
    }

    private bool ExisteEnLaBaseDeDatos()
    {
            Ventas ventas = RepositorioVentas.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (ventas != null);

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
                Utilitarios.Utils.ShowToastr(this.Page, "Modificado", "Exito", "success");
                LimpiarCampos();
                return;
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error", "Error", "error");
            LimpiarCampos();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
        
            Ventas ventas = RepositorioVentas.Buscar(Utils.ToInt(VentaIdTextBox.Text));

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
            decimal total = 0;
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculos = new Vehiculos();

            int id = ToInt(VehiculoDropDownList.SelectedValue);
            vehiculos = repositorio.Buscar(id);

            venta = (Ventas)ViewState["Ventas"];

            DateTime date = DateTime.Now.Date;
            decimal precio = Convert.ToDecimal(PrecioTextBox.Text);
            int VehiculoId = Utils.ToInt(VehiculoDropDownList.SelectedValue);
            var subtotal = vehiculos.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            string descripcion = VehiculoDropDownList.SelectedItem.ToString();

            venta.Detalle.Add(new VentasDetalle(Convert.ToInt32(VentaIdTextBox.Text), VehiculoId, subtotal, descripcion));

            ViewState["Ventas"] = venta;
            this.BindGrid();
            TotalTextBox.Text = total.ToString();

            foreach (var item in venta.Detalle)
            {
                total += item.SubTotal;
            }
            TotalTextBox.Text = total.ToString();
            CalTotal();
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
            TotalTextBox.Text = Total.ToString();
        }


        private void VaciaValores()
        {
            decimal total = Utils.ToDecimal(TotalTextBox.Text);
            decimal total2 = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["VentasDetalle"];
            foreach (var item in lista)
            {
                total2 = item.SubTotal;
            }
            total = total - total2;

            TotalTextBox.Text = total.ToString();
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

        protected void RemoveLinkButton_Click(object sender, EventArgs e)
        {

            decimal total = Utils.ToDecimal(TotalTextBox.Text);
            if (VentasGridView.Rows.Count > 0 && VentasGridView.SelectedIndex >= 0)
            {
                Ventas entrada = new Ventas();
                entrada = (Ventas)ViewState["Ventas"];

                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                entrada.RemoverDetalle(row.RowIndex);
                ViewState["Ventas"] = entrada;
                this.BindGrid();

                foreach (var item in entrada.Detalle)
                {
                    total -= item.SubTotal;
                }
                TotalTextBox.Text = total.ToString();
                CalTotal();

            }

        }


        protected void VentasGridVie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
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