<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="sCarDealerW.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
    <div class="container">

        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de Usuarios</div>
        </div>
        <div class="form-horizontal col-md-12" role="form">

            <%--UsuarioId--%>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="UsuarioIdTextBox">ID:</label>
                <div class="col-sm-1 col-md-3 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="UsuarioIdTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UsuarioIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="UsuarioIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="UsuarioIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="UsuarioIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>

                <%--Buscar Button--%>
                <div class="col-sm-1 col-md-2 col-xs2">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BtnBuscar_Click" />
                </div>


                <%--Fecha--%>
                <label class="col-sm-1 col-md-1 col-xs1" for="FechaTextBox">Fecha:</label>
                <div class="col-sm-1 col-md-2">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>

            <div class="panel panel-primary">
                <div class="panel-body">

                    <%--Nombres--%>
                    <div class="form-group row">
                        <label class="control-label col-sm-2" for="NombreTextBox">Nombres:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="text" class="form-control" ID="NombreTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="guardar" ControlToValidate="NombreTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombreTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>

                        <%--Correo--%>
                        <label class="control-label col-sm-1" for="CorreoTextBox">Email:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="email" class="form-control" ID="CorreoTextBox" placeholder="Ingrese Correo Electronico" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="guardar" ControlToValidate="CorreoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <%--Nivel Acceso--%>
                    <div class="form-group row">
                        <label class="control-label col-sm-2" for="NombreUserTextBox">Nivel Acceso:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:DropDownList ID="SexoDropDownList" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Administrador"></asp:ListItem>
                                <asp:ListItem Text="Usuario"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Sexo: Seleccione" ValidationGroup="Guardar" ControlToValidate="SexoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                        <%--Usuario--%>
                        <label class="control-label col-sm-1" for="NombreUserTextBox">Usuario:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="text" class="form-control" ID="NombreUserTextBox" placeholder="Ingrese Nombre De Usuario" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreUserTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun Telefono!" ValidationGroup="guardar" ControlToValidate="NombreUserTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre usuario">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombreUserTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun Telefono!" ControlToValidate="NombreUserTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>

                        <%--Contrasena--%>
                        <div class="form-group row">
                            <label class="control-label col-sm-2" for="ContraseñaTextBox">Contraseña:</label>
                            <div class="col-sm-1 col-md-4">
                                <asp:TextBox type="password" class="form-control" ID="ContraseñaTextBox" placeholder="Ingrese Contraseña" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Contraseña!" ValidationGroup="guardar" ControlToValidate="ContraseñaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Contraseña obligatorio&quot;&gt;Por favor llenar el campo Contraseña">*</asp:RequiredFieldValidator>

                            </div>
                            <%--Confirmar Contraseña--%>

                            <label class="control-label col-sm-1" for="VContraseñaTextBox">Confirme Contraseña:</label>
                            <div class="col-sm-1 col-md-4">
                                <asp:TextBox type="password" class="form-control" ID="VContraseñaTextBox" placeholder="Verifique Contraseña" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Verifique Contraseña!" ValidationGroup="guardar" ControlToValidate="VContraseñaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Verificar Contraseña obligatorio&quot;&gt;Por favor llenar el campo Verificar Contraseña">*</asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <%--Fecha Registro--%>
                        <div class="form-group row">
                            <label class="control-label col-sm-2" for="FechaRegistroTextBox">Fecha Registro:</label>
                            <div class="col-sm-1 col-md-4">
                                <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="False" />
                            </div>


                            <%--Total Ventas--%>
                            <label class="control-label col-sm-1" for="TotalVendidoTextBox">Total Ventas:</label>
                            <div class="col-sm-1 col-md-4">
                                <asp:TextBox type="Number" class="form-control" ID="TotalVendidoTextBox" Text="0" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>  
        </div>
                <hr>
                <div class="panel">
                    <div class="text-center">
                        <div class="form-group">
                            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" ValidationGroup="guardar" OnClick="BtnNuevo_Click" />
                            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="guardar" OnClick="BtnGuardar_Click" />
                            <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" ValidationGroup="Buscar" OnClick="BtnEliminar_Click" />
                        </div>
                    </div>
                </div>
                <script type="text/javascript"> function VerificarCantidad(sender, args) { args.IsValid = (args.Value.length <= 11); }</script>
                <hr>
    </div>

</asp:Content>
