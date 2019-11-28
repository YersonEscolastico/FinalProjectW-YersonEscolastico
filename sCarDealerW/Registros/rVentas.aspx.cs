using BLL;
using DAL;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
         
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarDropDownList();

                ViewState["Ventas"] = new Ventas();
                LimpiarCampos();
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
            ViewState["Ventas"] = new Ventas();
            VentasGridView.DataSource = null;
            this.BindGrid();
            PrecioDropDown_SelectedIndexChanged(null, null);
        }


    public void LlenarCampos(Ventas ventas)
    {

            int id;
            RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();
            int.TryParse(VehiculoDropDownList.SelectedValue, out id);
            Vehiculos s = db.Buscar(id);
            decimal precio = s.Precio;

            if (precio < 0)
            precio = precio * (-1);
       
            VentaIdTextBox.Text = ventas.VentaId.ToString();
            ClienteDropDownList.Text = ventas.ClienteId.ToString();
            UsuarioDropDownList.Text = ventas.UsuarioId.ToString();
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
            ventas.VehiculoId = Utils.ToInt(VehiculoDropDownList.Text);
            ventas.UsuarioId = Utils.ToInt(UsuarioDropDownList.Text);
            ventas.Total = Convert.ToDecimal(TotalTextBox.Text);
            ventas.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            return ventas;
    }

    private bool ExisteEnLaBaseDeDatos()
    {
            Ventas ventas = RepositorioVentas.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (ventas != null);

    }
        private bool Validar()
        {
            bool estado = false;

            if (VentasGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar detalle.", "Error", "error");
                estado = true;
            }
            if (String.IsNullOrWhiteSpace(VentaIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estado = true;
            }
            if (String.IsNullOrWhiteSpace(VehiculoDropDownList.Text))
            {
                Utils.ShowToastr(this, "Debe Agregar un Vehiculo", "Error", "error");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(ClienteDropDownList.Text))
            {
                Utils.ShowToastr(this, "Debe Agregar un Cliente", "Error", "error");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(UsuarioDropDownList.Text))
            {
                Utils.ShowToastr(this, "Debe Agregar un Usuario", "Error", "error");
                estado = true;
            }
            return estado;
        }

        private bool Validarr()
        {
            bool estado = false;

            if (String.IsNullOrWhiteSpace(VehiculoDropDownList.Text))
            {
                Utils.ShowToastr(this, "Debe Agregar un Vehiculo", "Error", "error");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(ClienteDropDownList.Text))
            {
                Utils.ShowToastr(this, "Debe Agregar un Cliente", "Error", "error");
                estado = true;
            }


            return estado;
        }

        private bool ValidarD()
        {
            bool estado = false;

            decimal precio = Convert.ToDecimal(PrecioTextBox.Text);

            if (precio <=0)
            {
                Utils.ShowToastr(this, "Debe agregar un precio", "Error", "error");
                estado = true;
            }
            return estado;
        }


    

        protected void BtnGuardar_Click(object sender, EventArgs e)
    {
            Ventas ventas;
            bool paso = false;


            if (Validar())
                return;

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
                Utils.ShowToastr(this, "No hay datos para eliminar!!", "Error", "error");
            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }


        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {

            Ventas venta = new Ventas();
            decimal total = 0;
            VentasDetalle d = new VentasDetalle();
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();

            if (ValidarD())
                return;


            if (Validarr())
                return;
      
            Ventas P = new Ventas();
            P = (Ventas)ViewState["Ventas"];
            Vehiculos A = new RepositorioBase<Vehiculos>().Buscar(Utils.ToInt(VehiculoDropDownList.SelectedValue));

            int idd = Utils.ToInt(VehiculoDropDownList.SelectedValue);

            foreach (var item in P.Detalle.ToList())
            {
                if (idd == item.VehiculoId)
                {
                    Utils.ShowToastr(this, "Ya se ha agregado", "Error", "error");
                    return;
                }
            }

            int id = Utils.ToInt(VehiculoDropDownList.SelectedValue);
            Vehiculos vehiculos = repositorio.Buscar(id);

            venta = (Ventas)ViewState["Ventas"];

            decimal precio = Convert.ToDecimal(PrecioTextBox.Text);
            int VehiculoId = Utils.ToInt(VehiculoDropDownList.SelectedValue);
            var subtotal = vehiculos.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            string descripcion = VehiculoDropDownList.SelectedItem.ToString();

            venta.Detalle.Add(new VentasDetalle(Convert.ToInt32(VentaIdTextBox.Text), VehiculoId, subtotal, descripcion,vehiculos.Vin));


            ViewState["Ventas"] = venta;
            this.BindGrid();
            TotalTextBox.Text = total.ToString();

            foreach (var item in venta.Detalle)
            {
                total += item.Precio;
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
                Total += item.Precio;
            }
            TotalTextBox.Text = Total.ToString();
        }

        protected void PrecioDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();
            Vehiculos s = new Vehiculos(); 
            int.TryParse(VehiculoDropDownList.SelectedValue, out id);
            s = db.Buscar(id);
            if (VehiculoDropDownList.Text=="")
            {
                PrecioTextBox.Text = "0";
            }else
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
            if (VentasGridView.Rows.Count != 0 && VentasGridView.SelectedIndex != 0)
            {
      
                Ventas entrada = (Ventas)ViewState["Ventas"];

                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                entrada.RemoverDetalle(row.RowIndex);
                ViewState["Ventas"] = entrada;
                this.BindGrid();

                foreach (var item in entrada.Detalle)
                {
                    total -= item.Precio;
                }
                TotalTextBox.Text = total.ToString();
                CalTotal();

            }

        }


        private void VaciaValores()
        {
            decimal total = Utils.ToDecimal(TotalTextBox.Text);
            decimal total2 = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["VentasDetalle"];
            foreach (var item in lista)
            {
                total2 = item.Precio;
            }
            total = total - total2;

            TotalTextBox.Text = total.ToString();
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

            RepositorioBase<Usuarios> U = new RepositorioBase<Usuarios>();
            UsuarioDropDownList.Items.Clear();
            UsuarioDropDownList.DataSource = U.GetList(x => true);
            UsuarioDropDownList.DataValueField = "UsuarioId";
            UsuarioDropDownList.DataTextField = "Usuarioss";
            UsuarioDropDownList.DataBind();



            ViewState["Ventas"] = new Ventas();
        }
    }
}