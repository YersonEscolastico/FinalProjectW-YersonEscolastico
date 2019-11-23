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
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                UsuarioIdTextBox.Text = "0";
            }
        }


        private void LimpiarCampos()
        {
            UsuarioIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = string.Empty;
            NombreUserTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            ContraseñaTextBox.Text = string.Empty;
            VContraseñaTextBox.Text = string.Empty;
            TotalVendidoTextBox.Text = string.Empty;
            FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LlenaCampos(Usuarios usuarios)
        {
            UsuarioIdTextBox.Text = usuarios.UsuarioId.ToString();
            FechaTextBox.Text = usuarios.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = usuarios.Nombres;
            NombreUserTextBox.Text = usuarios.Usuarioss.ToString();
            CorreoTextBox.Text = usuarios.Email.ToString();
            ContraseñaTextBox.Text = usuarios.Clave.ToString();
            VContraseñaTextBox.Text = usuarios.Clave.ToString();
            NivelAccesoTextBox.Text = usuarios.NivelAcceso.ToString();
            TotalVendidoTextBox.Text = usuarios.TotalVentas.ToString();
        }

        private Usuarios LlenaClase()
        {
            Usuarios u = new Usuarios();

            u.UsuarioId = Utils.ToInt(UsuarioIdTextBox.Text);
            bool result = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            if (result)
                u.Fecha = fecha;
            u.Fecha = DateTime.Now;
            u.Nombres = NombreTextBox.Text;
            u.Usuarioss = NombreUserTextBox.Text;
            u.Email = CorreoTextBox.Text;
            u.Clave = ContraseñaTextBox.Text;
            u.NivelAcceso = NivelAccesoTextBox.Text;
            return u;
        }


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios u = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

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
            if (Utils.ToInt(UsuarioIdTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        protected bool Validar(Usuarios usuarios)
        {
            bool validar = false;
            Expression<Func<Usuarios, bool>> filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            var lista = repositorio.GetList(c => true);
            foreach (var item in lista)
            {
                if (usuarios.Usuarioss == item.Usuarioss)
                {
                    Utils.ShowToastr(this.Page, "Usuario ya Existe", "Error", "error");
                    return validar = true;
                }


                if (usuarios.Email == item.Email)
                {
                    Utils.ShowToastr(this.Page, "Email ya Existe", "Error", "error");
                    return validar = true;
                }
            }

            if (String.IsNullOrWhiteSpace(UsuarioIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                validar = true;
            }

            return validar;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios u = new Usuarios();
            bool paso = false;

            if (Verificar())
            {
                Utils.ShowToastr(this, "Solo Letras en Nombre y NombreUsuario!", "Error", "error");
                return;
            }
            u = LlenaClase();
            if (Validar(u))
            {
                return;
            }
            else
            {
                if (ContraseñaTextBox.Text == VContraseñaTextBox.Text)
                {
                    if (u.UsuarioId == 0)
                    {
                        paso = repositorio.Guardar(u);
                        Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                        LimpiarCampos();
                    }
                    else
                    {
                        Usuarios user = new Usuarios();
                        int id = Utils.ToInt(UsuarioIdTextBox.Text);
                        RepositorioBase<Usuarios> repository = new RepositorioBase<Usuarios>();
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
                else
                    Utils.ShowToastr(this, "Fallo!! Contraseña no coinciden", "Error", "error");
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = Utils.ToInt(UsuarioIdTextBox.Text);

            var Usuarios = repositorio.Buscar(id);

            if (Usuarios != null)
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
                return;
        }

        private bool Verificar()
        {
            bool paso = false;
            bool resultado = Regex.IsMatch(NombreTextBox.Text, @"^[a-z A-Z]+$");
            bool resultado1 = Regex.IsMatch(NombreUserTextBox.Text, @"^[a-z A-Z]+$");

            if (!resultado)
            {
                resultado = Regex.IsMatch(NombreTextBox.Text, @"^[a-z A-Z]+$");
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

            if (!resultado1)
            {
                resultado1 = Regex.IsMatch(NombreUserTextBox.Text, @"^[a-z A-Z]+$");
                if (resultado1)
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

            return paso;
        }
    }
}