using BLL;
using Entidades;
using sCarDealerW.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sCarDealerW.Registros
{
    public partial class rVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                VehiculoIdTextBox.Text = "0";
            }
        }


        private void LimpiarCampos()
        {
            VehiculoIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            MarcaDropDownList.Text = string.Empty;
            ModeloDropDownList.Text = string.Empty;
            ColorDropDownList.Text = string.Empty;
            VinTextBox.Text = string.Empty;
            PlacaTextBox.Text = string.Empty;
            AnioTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            EstadoDropDownList.Text = string.Empty;
            FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LlenaCampos(Vehiculos vehiculos)
        {
            VehiculoIdTextBox.Text = vehiculos.VehiculoId.ToString();
            MarcaDropDownList.Text = vehiculos.Marca;
            ModeloDropDownList.Text = vehiculos.Modelo.ToString();
            ColorDropDownList.Text = vehiculos.Color.ToString();
            VinTextBox.Text = vehiculos.Vin.ToString();
            PlacaTextBox.Text = vehiculos.Placa.ToString();
            AnioTextBox.Text = vehiculos.Anio.ToString();
            DescripcionTextBox.Text = vehiculos.Descripcion.ToString();
            PrecioTextBox.Text = vehiculos.Precio.ToString();
            CostoTextBox.Text = vehiculos.Costo.ToString();
            EstadoDropDownList.Text = vehiculos.Estado.ToString();
            FechaTextBox.Text = vehiculos.Fecha.ToString("yyyy-MM-dd");
            FechaTextBox.Text = vehiculos.FechaRegistro.ToString("yyyy-MM-dd");
        }

        private Vehiculos LlenaClase()
        {
            Vehiculos u = new Vehiculos();

            u.VehiculoId = Utils.ToInt(VehiculoIdTextBox.Text);
            bool result = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            if (result)
                u.Fecha = fecha;
            u.Fecha = DateTime.Now;
            u.Marca = MarcaDropDownList.Text;
            u.Modelo = ModeloDropDownList.Text;
            u.Color = ColorDropDownList.Text;
            u.Vin = VinTextBox.Text;
            u.Placa = PlacaTextBox.Text;
            u.Anio = AnioTextBox.Text;
            u.Descripcion = DescripcionTextBox.Text;
            u.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            u.Costo = Convert.ToDecimal(CostoTextBox.Text);
            u.Descripcion = DescripcionTextBox.Text;
            u.Estado = EstadoDropDownList.Text;
            return u;
        }


        protected bool ValidarNombres(Vehiculos vehiculos)
        {
            bool validar = false;
            Expression<Func<Vehiculos, bool>> filtro = p => true;
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            var lista = repositorio.GetList(c => true);
            foreach (var item in lista)
            {
                if (vehiculos.Descripcion == item.Descripcion)
                {
                    Utils.ShowToastr(this.Page, "Vehicilo ya Existe", "Error", "error");
                    return validar = true;
                }
                if (vehiculos.Placa == item.Placa)
                {
                    Utils.ShowToastr(this.Page, "Ya se ha registrado un vehiculo con esta Placa", "Error", "error");
                    return validar = true;
                }
                if (vehiculos.Vin == item.Vin)
                {
                    Utils.ShowToastr(this.Page, "Ya se ha registrado un vehiculo con este VIn", "Error", "error");
                    return validar = true;
                }

                if (Convert.ToDecimal(PrecioTextBox.Text) <= Convert.ToDecimal(CostoTextBox.Text))
                {
                    Utils.ShowToastr(this.Page, "El Precio debe ser mayor que el Costo", "Error", "error");
                    return validar = true;
                }

            }

            return validar;
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos u = repositorio.Buscar(Utils.ToInt(VehiculoIdTextBox.Text));

            if (u != null)
            {
                LimpiarCampos();
                LlenaCampos(u);
            }
            else
            {
                LimpiarCampos();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(VehiculoIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos u = new Vehiculos();
            bool paso = false;


            u = LlenaClase();

            {
                if (u.VehiculoId == 0)
                {
                    if (ValidarNombres(u))
                    {
                        return;
                    }

                    paso = repositorio.Guardar(u);
                    Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                    LimpiarCampos();
                }
                else
                {
                    int id = Utils.ToInt(VehiculoIdTextBox.Text);
                    RepositorioBase<Vehiculos> repository = new RepositorioBase<Vehiculos>();
                    u = repository.Buscar(id);

                    if (u != null)
                    {
                        paso = repositorio.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado Exitosamente!!", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
                }

                if (paso)
                {
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "Fallo!! no ha podido Guardar", "Error", "error");

            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            int id = Utils.ToInt(VehiculoIdTextBox.Text);

            var vehiculos = repositorio.Buscar(id);

            if (vehiculos != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado Exitosamente!!", "Exito", "info");
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "Fallo!! No se Puede Eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No hay datos para eliminar!!", "Error", "error");
            if (Utils.ToInt(VehiculoIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }
    }
}
