<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rVehiculos.aspx.cs" Inherits="sCarDealerW.Registros.rVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de Vehiculos</div>
        </div>
        <div class="form-horizontal col-md-12" role="form">

            <%--VehiculoId--%>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="VehiculoIdTextBox">Id:</label>
                <div class="col-sm-1 col-md-3 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="VehiculoIdTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="VehiculoIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="VehiculoIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="VehiculoIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="VehiculoIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
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
                    <%--Marca--%>
                    <div class="form-group row">
                        <label class="control-label col-sm-2" for="MarcaUserTextBox">Marca:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:DropDownList ID="MarcaDropDownList" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Ferrary."></asp:ListItem>
                                <asp:ListItem Text="Jeep."></asp:ListItem>
                                <asp:ListItem Text="Toyota."></asp:ListItem>
                                <asp:ListItem Text="Aston Martin."></asp:ListItem>
                                <asp:ListItem Text="Audi.."></asp:ListItem>
                                <asp:ListItem Text="Bentley"></asp:ListItem>
                                <asp:ListItem Text="BMW."></asp:ListItem>
                                <asp:ListItem Text="Bugatti."></asp:ListItem>
                                <asp:ListItem Text="Abarth."></asp:ListItem>
                                <asp:ListItem Text="Honda"></asp:ListItem>
                                <asp:ListItem Text="Lamborghini"></asp:ListItem>

                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Marca: Seleccione" ValidationGroup="Guardar" ControlToValidate="MarcaDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <%--Descripcion--%>
                        <label class="control-label col-sm-1" for="DescripcionTextBox">Descripcion:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="DescripcionTextBox" class="form-control" ID="DescripcionTextBox" placeholder="Ingrese Nombre Usuario" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese algun Telefono!" ValidationGroup="guardar" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre usuario">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Ingrese algun Telefono!" ControlToValidate="DescripcionTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <%--Color--%>
                    <div class="form-group row">
                        <label class="control-label col-sm-2" for="ColorUserTextBox">Color:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:DropDownList ID="ColorDropDownList" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Azul"></asp:ListItem>
                                <asp:ListItem Text="Rojo"></asp:ListItem>
                                <asp:ListItem Text="Amarillo"></asp:ListItem>
                                <asp:ListItem Text="Blanco"></asp:ListItem>
                                <asp:ListItem Text="Verde"></asp:ListItem>
                                <asp:ListItem Text="Negro"></asp:ListItem>
                                <asp:ListItem Text="Dorado"></asp:ListItem>
                                <asp:ListItem Text="Plateado"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Sexo: Seleccione" ValidationGroup="Guardar" ControlToValidate="ColorDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <%--Vin--%>
                        <label class="control-label col-sm-1" for="VinTextBox">Vin:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="text" class="form-control" ID="VinTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="guardar" ControlToValidate="VinTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="VinTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>

                        <br />
                        <%--Modelo--%>
                        <label class="control-label col-sm-2" for="ModeloUserTextBox">Modelo:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:DropDownList ID="ModeloDropDownList" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Sedan"></asp:ListItem>
                                <asp:ListItem Text="Deportivo"></asp:ListItem>
                                <asp:ListItem Text="Familiar"></asp:ListItem>
                                <asp:ListItem Text="Coupe"></asp:ListItem>
                                <asp:ListItem Text="Todo Terreno"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Sexo: Seleccione" ValidationGroup="Guardar" ControlToValidate="ModeloDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <%--Anio--%>
                        <label class="control-label col-sm-1" for="AnioTextBox">Anio:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="text" class="form-control" ID="AnioTextBox" placeholder="Ingrese Cedula" runat="server" MaxLength="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CedulaRequiredFieldValidator" runat="server" ErrorMessage="Ingrese alguna cedula!" ValidationGroup="guardar" ControlToValidate="AnioTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="CedulaRegularExpressionValidator" runat="server" ErrorMessage="Ingrese alguna cedula!" ControlToValidate="AnioTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="AnioCustomValidator" runat="server" ControlToValidate="AnioTextBox" ErrorMessage="Introduzca Cedula Correcta" ValidationGroup="guardar" ClientValidationFunction="VerificarCantidad"></asp:CustomValidator>
                        </div>
                        <br />
                        <%--Placa--%>
                        <label class="control-label col-sm-2" for="PlacaTextBox">Placa:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:TextBox type="PlacaTextBox" class="form-control" ID="PlacaTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="guardar" ControlToValidate="PlacaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="PlacaTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                        <br />
                        <%--Estado--%>
                        <label class="control-label col-sm-1" for="EstadoTextBox">Estado:</label>
                        <div class="col-sm-1 col-md-4">
                            <asp:DropDownList ID="EstadoDropDownList" runat="server" Class="form-control">
                                <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Text="Disponible"></asp:ListItem>
                                <asp:ListItem Text="Vendido"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Estado: Seleccione" ValidationGroup="Guardar" ControlToValidate="EstadoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--Costo--%>
                    <label class="control-label col-sm-2" for="CostoTextBox">Costo:</label>
                    <div class="col-sm-1 col-md-4">
                        <asp:TextBox type="Number" class="form-control" ID="CostoTextBox" Text="0" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CostoTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CostoTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>

                    <%--Precio--%>
                    <label class="control-label col-sm-1" for="PrecioTextBox">Precio:</label>
                    <div class="col-sm-1 col-md-4">
                        <asp:TextBox type="Number" class="form-control" ID="PrecioTextBox" Text="0" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="PrecioTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="PrecioTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>

                    <%--Fecha Registro--%>
                    <label class="control-label col-sm-2" for="FechaRegistroTextBox">Fecha Registro:</label>
                    <div class="col-sm-1 col-md-4">
                        <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="False" />
                    </div>
                    <label class="control-label col-sm-1" for="hh"></label>
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
    </div>

</asp:Content>
