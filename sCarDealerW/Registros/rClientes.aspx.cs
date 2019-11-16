using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yCarDealerSFM.Utilitarios;

namespace sCarDealerW.Registros
{
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                ClienteIdTextBox.Text = "0";
            }
        }


        private void LimpiarCampos()
        {
            ClienteIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombresTextBox.Text = string.Empty;
            SexoDropDownList.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LlenaCampos(Clientes clientes)
        {
            ClienteIdTextBox.Text = clientes.ClienteId.ToString();
            NombresTextBox.Text = clientes.Nombres;
            SexoDropDownList.Text = clientes.Sexo.ToString();
            CorreoTextBox.Text = clientes.Email.ToString();
            CedulaTextBox.Text = clientes.Cedula.ToString();
            DireccionTextBox.Text = clientes.Direccion.ToString();
            TelefonoTextBox.Text = clientes.Telefono.ToString();
            CelularTextBox.Text = clientes.Celular.ToString();
            FechaTextBox.Text = clientes.Fecha.ToString("yyyy-MM-dd");
            FechaTextBox.Text = clientes.FechaNacimiento.ToString("yyyy-MM-dd");
            FechaTextBox.Text = clientes.FechaRegistro.ToString("yyyy-MM-dd");
        }

        private Clientes LlenaClase()
        {
            Clientes u = new Clientes();

            u.ClienteId = Utils.ToInt(ClienteIdTextBox.Text);
            bool result = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            if (result)
                u.Fecha = fecha;
            u.Fecha = DateTime.Now;
            u.Nombres = NombresTextBox.Text;
            u.Sexo = SexoDropDownList.Text;
            u.Email = CorreoTextBox.Text;
            u.Cedula = CedulaTextBox.Text;
            u.Direccion = DireccionTextBox.Text;
            u.Telefono = TelefonoTextBox.Text;
            u.Celular = CelularTextBox.Text;
            return u;
        }

        protected bool ValidarNombres(Clientes clientes)
        {
            bool validar = false;
            Expression<Func<Clientes, bool>> filtro = p => true;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            var lista = repositorio.GetList(c => true);
            foreach (var item in lista)
            {

                if (clientes.Cedula == item.Cedula)
                {
                    Utils.ShowToastr(this.Page, "Cedula ya Existe", "Error", "error");
                    return validar = true;
                }

                if (clientes.Telefono == item.Telefono)
                {
                    Utils.ShowToastr(this.Page, "Telefono ya Existe", "Error", "error");
                    return validar = true;
                }

                if (clientes.Email == item.Email)
                {
                    Utils.ShowToastr(this.Page, "Correo ya Existe", "Error", "error");
                    return validar = true;
                }
            }

            if (TelefonoTextBox.Text.Length != 10)
            {
                Utils.ShowToastr(this, "Ingrese Correctamente el telefono", "Error", "error");
                validar = true;
            }

            if (CedulaTextBox.Text.Length != 11)
            {
                Utils.ShowToastr(this, "Ingrese Correctamente la Cedula", "Error", "error");
                validar = true;
            }

            if (String.IsNullOrWhiteSpace(ClienteIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                validar = true;
            }

            return validar;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes u = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            if (u != null)
            {
                LimpiarCampos();
                LlenaCampos(u);
                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                LimpiarCampos();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(ClienteIdTextBox.Text) == 0)
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
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes u = new Clientes();
            bool paso = false;

            if (Verificar())
            {
                Utils.ShowToastr(this, "Solo Letras en Nombres!", "Error", "error");
                return;
            }
            u = LlenaClase();
            if (ValidarNombres(u))
            {
                return;
            }
            else
            {
                    if (u.ClienteId == 0)
                    {
                        paso = repositorio.Guardar(u);
                        Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                        LimpiarCampos();
                    }
                    else
                    {
                        int id = Utils.ToInt(ClienteIdTextBox.Text);
                        RepositorioBase<Clientes> repository = new RepositorioBase<Clientes>();
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
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            int id = Utils.ToInt(ClienteIdTextBox.Text);

            var Clientes = repositorio.Buscar(id);

            if (Clientes != null)
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
                Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
        }

        private bool Verificar()
        {
            bool paso = false;
            bool resultado = Regex.IsMatch(NombresTextBox.Text, @"^[a-z A-Z]+$");

            if (!resultado)
            {
                resultado = Regex.IsMatch(NombresTextBox.Text, @"^[a-z A-Z]+$");
                if (resultado)
                {
                    paso = false;
                }
                else
                {
                    paso = true;
                    Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                }
                Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                paso = true;
            }

            if (!resultado)
            {
                if (resultado)
                {
                    paso = false;
                }
                else
                {
                    paso = true;
                    Utils.ShowToastr(this, "Solo Letras en Nombres", "Error", "error");
                }
                Utils.ShowToastr(this, "Solo Letras en Nombres!", "Error", "error");
                paso = true;
            }

            return paso;
        }
    }
}