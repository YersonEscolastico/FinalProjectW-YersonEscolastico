<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="sCarDealerW.Registros.rClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de Clientes</div>
        </div>
        <div class="form-horizontal col-md-12" role="form">

            <%--ClienteId--%>
            <div class="form-group row">
                <label class="control-label col-md-2" for="ClienteIdTextBox">Id:</label>
                <div class="col-md-2">
                    <asp:TextBox type="Number" class="form-control" ID="ClienteIdTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ClienteIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="ClienteIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ClienteIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="ClienteIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>

                <%--Buscar Button--%>
                <div class="col-md-2 ">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BtnBuscar_Click" />
                </div>

                <%--Fecha--%>
                <label class=" col-md-2" for="FechaTextBox">Fecha:</label>
                <div class=" col-md-2">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" disabled = "disabled"  />
                </div>
            </div>

            <div class="panel panel-primary">
                <div class="panel-body">

                    <%--Nombres--%>
                    <div class="form-group row">
                        <label class="control-label col-md-2" for="NombresTextBox">Nombres:</label>
                        <div class="col-md-4">
                            <asp:TextBox type="text" class="form-control" ID="NombresTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombresRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="guardar" ControlToValidate="NombresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Nombres obligatorio&quot;&gt;Por favor llenar el campo Nombres">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombresRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>


                        <%--Sexo--%>

                        <label class="control-label col-md-1" for="SexoTextBox">Sexo:</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="SexoDropDownList" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Masculino"></asp:ListItem>
                                <asp:ListItem Text="Femenino"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="NivelRequiredFieldValidator1" runat="server" ErrorMessage="Elija una opcion!" ValidationGroup="guardar" ControlToValidate="SexoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe elegir una opcion">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NivelRequiredFieldValidator"  runat="server" ErrorMessage="Elija una opcion!" ControlToValidate="SexoDropDownList" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>

                           </div>

                        </div>

                    </div>
                    <%--Email--%>

                    <label class="control-label col-md-2" for="CorreoTextBox">Correo:</label>
                    <div class="col-md-4">
                        <asp:TextBox type="email" class="form-control" ID="CorreoTextBox" placeholder="Ingrese Correo Electronico" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="guardar" ControlToValidate="CorreoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>
                    </div>

                    <%--Cedula--%>

                    <label class="control-label col-md-1" for="CedulaTextBox">Cedula:</label>
                    <div class="col-md-4">
                        <asp:TextBox type="text" class="form-control" ID="CedulaTextBox" placeholder="Ingrese Cedula" runat="server" MaxLength="11"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CedulaRequiredFieldValidator" runat="server" ErrorMessage="Ingrese alguna cedula!" ValidationGroup="guardar" ControlToValidate="CedulaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="CedulaRegularExpressionValidator" runat="server" ErrorMessage="Ingrese alguna cedula!" ControlToValidate="CedulaTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="CedulaCustomValidator" runat="server" ControlToValidate="CedulaTextBox" ErrorMessage="Introduzca Cedula Correcta" ValidationGroup="guardar" ClientValidationFunction="VerificarCantidad"></asp:CustomValidator>
                    </div>

                    <%--Direccion--%>

                    <label class="control-label col-md-2" for="DireccionTextBox">Direccion:</label>
                    <div class="col-md-4">
                        <asp:TextBox type="text" class="form-control" ID="DireccionTextBox" placeholder="Ingrese Direccion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="DireccionTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese direccion!" ValidationGroup="guardar" ControlToValidate="DireccionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Direccion obligatorio&quot;&gt;Por favor llenar el campo Direccion">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="DireccionTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese direccion" ControlToValidate="DireccionTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>

                    <%--Telefono--%>
                    <label class="control-label col-md-1" for="TelefonoTextBox">Telefono:</label>
                    <div class=" col-md-4">
                        <asp:TextBox type="text" class="form-control" ID="TelefonoTextBox" placeholder="Ingrese Telefono" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TelefonoTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese Telefono!" ValidationGroup="guardar" ControlToValidate="TelefonoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Telefono obligatorio&quot;&gt;Por favor llenar el campo Telefono">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="TelefonoTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese Telefono!" ControlToValidate="TelefonoTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>

                    <%--Celular--%>
                    <label class="control-label col-md-2" for="CelularTextBox">Celular:</label>
                    <div class="col-md-4">
                        <asp:TextBox type="text" class="form-control" ID="CelularTextBox" placeholder="Ingrese Celular" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese Celular" ValidationGroup="guardar" ControlToValidate="CelularTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Celular obligatorio&quot;&gt;Por favor llenar el campo Celular">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese Celular" ControlToValidate="CelularTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>

                    <%--Fecha Nacimiento--%>
                    <div class="form-group row">
                        <label class="control-label col-md-1" for="FechaRegistroTextBox">Fecha Registro:</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="False" />
                               <asp:RequiredFieldValidator ID="FechaRequiredFieldValidator" runat="server" ErrorMessage="Ingrese Fecha!" ValidationGroup="guardar" ControlToValidate="FechaRegistroTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Fecha obligatorio&quot;&gt;Por favor llenar el campo fecha">*</asp:RequiredFieldValidator>

                        </div>

                    </div>
                </div>
            </div>
        </div>
                <%--Botones--%>
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


