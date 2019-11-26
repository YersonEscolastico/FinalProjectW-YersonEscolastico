<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="sCarDealerW.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
    <div class="container">

        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de Usuarios</div>
        </div>
        <div class="form-horizontal col-md-12" role="form">

            <%--UsuarioId--%>
            <div class="form-group row">
                <label class="control-label col-md-2" for="UsuarioIdTextBox">ID:</label>
                <div class="col-md-2">
                    <asp:TextBox type="Number" class="form-control" ID="UsuarioIdTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UsuarioIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="UsuarioIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="UsuarioIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese un valor correcto!" ControlToValidate="UsuarioIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>

                <%--Buscar Button--%>
                <div class="col-md-2">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BtnBuscar_Click" />
                </div>


                <%--Fecha--%>
                <label class="col-md-2" for="FechaTextBox">Fecha:</label>
                <div class="col-md-2">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" disabled = "disabled"  />
                </div> 
            </div>

            <div class="panel panel-primary">
                <div class="panel-body">

                    <%--Nombres--%>
                    <div class="form-group row">
                        <label class="control-label col-md-2" for="NombreTextBox">Nombres:</label>
                        <div class="col-md-2">
                            <asp:TextBox type="text" class="form-control" ID="NombreTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="guardar" ControlToValidate="NombreTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Nombre obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese un nombre correcto!" ControlToValidate="NombreTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>

                        <%--Correo--%>
                        <label class="control-label  col-md-3" for="CorreoTextBox">Email:</label>
                        <div class="col-md-4">
                            <asp:TextBox type="email" class="form-control" ID="CorreoTextBox" placeholder="Ingrese Correo Electronico" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="guardar" ControlToValidate="CorreoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <%--Nivel Acceso--%>
                    <div class="form-group row">
                        <label class="control-label col-md-2" for="NivelAccesoTextBox">Nivel Acceso:</label>
                        <div class=" col-md-3">
                            <asp:DropDownList ID="NivelAccesoTextBox" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Administrador"></asp:ListItem>
                                <asp:ListItem Text="Usuario"></asp:ListItem>
                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="NivelRequiredFieldValidator1" runat="server" ErrorMessage="Elija una opcion!" ValidationGroup="guardar" ControlToValidate="NivelAccesoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe elegir una opcion">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NivelRequiredFieldValidator"  runat="server"  ControlToValidate="NivelAccesoTextBox"  SetFocusOnError="True"></asp:RegularExpressionValidator>

                        </div>
                        <%--Usuario--%>
                        <label class="control-label col-md-2" for="NombreUserTextBox">Usuario:</label>
                        <div class="col-md-4">
                            <asp:TextBox type="text" class="form-control" ID="NombreUserTextBox" placeholder="Ingrese Nombre De Usuario" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreUserTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun Telefono!" ValidationGroup="guardar" ControlToValidate="NombreUserTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre usuario">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombreUserTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese un usuario correcto!" ControlToValidate="NombreUserTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                                            </div>
                        <%--Contrasena--%>
                        <div class="form-group row">
                            <label class="control-label col-md-2" for="ContraseñaTextBox">Contraseña:</label>
                            <div class=" col-md-3">
                                <asp:TextBox type="password" class="form-control" ID="ContraseñaTextBox" placeholder="Ingrese Contraseña" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Contraseña!" ValidationGroup="guardar" ControlToValidate="ContraseñaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Contraseña obligatorio&quot;&gt;Por favor llenar el campo Contraseña">*</asp:RequiredFieldValidator>

                            </div>
                            <%--Confirmar Contraseña--%>

                            <label class="control-label col-md-2" for="VContraseñaTextBox">Confirme Contraseña:</label>
                            <div class="col-md-4">
                                <asp:TextBox type="password" class="form-control" ID="VContraseñaTextBox" placeholder="Verifique Contraseña" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Verifique Contraseña!" ValidationGroup="guardar" ControlToValidate="VContraseñaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Verificar Contraseña obligatorio&quot;&gt;Por favor llenar el campo Verificar Contraseña">*</asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <%--Fecha Registro--%>
                        <div class="form-group row">
                            <label class="control-label col-md-2" for="FechaRegistroTextBox">Fecha Registro:</label>
                            <div class=" col-md-3">
                                <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="False" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese Fecha!" ValidationGroup="guardar" ControlToValidate="FechaRegistroTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Fecha obligatorio&quot;&gt;Por favor llenar el campo fecha">*</asp:RequiredFieldValidator>

                            </div>


                            <%--Total Ventas--%>
                            <label class="control-label col-md-2" for="TotalVendidoTextBox">Total Ventas:</label>
                            <div class="col-md-4">
                                <asp:TextBox type="Number" class="form-control" ID="TotalVendidoTextBox" Text="0" runat="server" ReadOnly="True"></asp:TextBox>
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
