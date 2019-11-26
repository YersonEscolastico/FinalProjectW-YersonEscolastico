<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sCarDealerW.Login" %>


<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<html>
<head runat="server">
    <title></title>

    <%--Librerias para el toast--%>
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" />
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/css/toastr.css"
        rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"
        type="text/javascript"></script>


    <script type="text/javascript">
        function Notify(msg, title, type, clear, pos, sticky) {
            if (clear == true) {
                toastr.clear();
            }
            if (sticky == true) {
                toastr.tapToDismiss = true;
                toastr.timeOut = 10000;
            }
            toastr.options.onclick = function () {
            }
            //"toast-top-left"; 
            toastr.options.positionClass = pos;
            if (type.toLowerCase() == 'info') {
                toastr.options.timeOut = 1000;
                toastr.tapToDismiss = true;
                toastr.info(msg, title);
            }
            if (type.toLowerCase() == 'success') {
                toastr.options.timeOut = 1500;
                toastr.success(msg, title);
            }
            if (type.toLowerCase() == 'warning') {
                toastr.options.timeOut = 3000;
                toastr.warning(msg, title);
            }
            if (type.toLowerCase() == 'error') {
                toastr.options.timeOut = 10000;
                toastr.error(msg, title);
            }
        }
    </script>

</head>

<body>
    <div class="container">
             
        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">CAR DEALER SFM</div>
        </div>
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Login</h1>

                <div class="account-wall">
                    <div class="text-center">
                        <img class="profile-img" src="\Resources\usuari.png"
                            alt="">
                    </div>
                    <form runat="server">
                        <br />
                        <div class="text-center">
                            <asp:TextBox ID="UsuarioTextBox" placeholder="Usuario" runat="server" Width="228px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="Iniciar" ControlToValidate="UsuarioTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>

                        </div>
                        <br />
                        <div class="text-center">
                            <asp:TextBox ID="PasswordTextBox" type="password" placeholder="Password" runat="server" Width="228px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="Iniciar" ControlToValidate="PasswordTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>

                        </div>
                        <br />
                        <asp:Button runat="server" Text="Iniciar" class="btn btn-md btn-success btn-block" OnClick="LoginButton_Click" />
                        <label class="checkbox pull-center">
                            <input type="checkbox" value="remember-me">
                            Recuerdame               
                        </label>
                        <br />
                    </form>
                </div>
                <div class="text-center">
                    <a href="Registros/rUsuarios.aspx" class="text-center new-account">Crear Cuenta </a>
                </div>
            </div>
        </div>
    </div>
</body>

</html>