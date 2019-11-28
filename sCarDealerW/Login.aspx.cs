using BLL;
using Entidades;
using sCarDealerW.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sCarDealerW
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            String Valor = UsuarioTextBox.Text;

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            LoginRepositorio repositorio = new LoginRepositorio();

            if (UsuarioTextBox.Text.Length > 0 && PasswordTextBox.Text.Length > 0)
            {


                string password = Utils.Hash(PasswordTextBox.Text);
                if (repositorio.Auntenticar(UsuarioTextBox.Text, PasswordTextBox.Text))
                {
                    FormsAuthentication.RedirectFromLoginPage(user.Usuarioss, true);
                }
                else
                    Utils.ShowToastr(this.Page, "Usuario o contraseña Incorrecta", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "Debe ingresar su usuario y contraseña", "Error", "error");
        }
    }
}