<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="sCarDealerW.Registros.rVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de Ventas</div>
        </div>


        <div class="form-horizontal col-md-12" role="form">

            <%--VentaId--%>
            <div class="form-group row">
                <label class="control-label col-md-1" for="VentaIdTextBox">Venta ID:</label>
                <div class=" col-md-2 ">
                    <asp:TextBox type="Number" class="form-control" ID="VentaIdTextBox" placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="VentaIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="VentaIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="VentaIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese un valor correcto!" ControlToValidate="VentaIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>

                <%--Buscar Button--%>
                <div class=" col-md-2">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BuscarButton_Click" />
                </div>

                <%--Fecha--%>
                <label class="col-md-1" for="FechaTextBox">Fecha:</label>
                <div class="col-md-3">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>

                
                        <%--Usuario--%>
                    <div class="form-group row">
                        <label class="control-label col-md-1" for="UsuarioTextBox" >Usuario:</label>
                        <div class=" col-md-2">
                            <asp:DropDownList class="form-control" ID="UsuarioDropDownList" AutoPostBack="true" runat="server"   ></asp:DropDownList>
                        </div>
            </div>
            <br>


            <%--Cliente--%>
            <div class="form-group row">
                <label class="control-label col-md-2" for="ClienteTextBox">Cliente:</label>
                <div class=" col-md-3">
                    <asp:DropDownList class="form-control" ID="ClienteDropDownList" runat="server"></asp:DropDownList>
                </div>


                <%--Fecha Fecha Registro--%>
                <label class="control-label col-md-2" for="FechaRegistroTextBox">Fecha Registro:</label>
                <div class="col-md-3">
                    <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="False" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese Fecha!" ValidationGroup="guardar" ControlToValidate="FechaRegistroTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Fecha obligatorio&quot;&gt;Por favor llenar el campo fecha">*</asp:RequiredFieldValidator>

                    </div>
            </div>


            <div class="panel panel-primary">
                <div class="panel-body">

                    <%--Vehiculo--%>
                    <div class="form-group row">
                        <label class="control-label col-md-2" for="VehiculoTextBox">Vehiculo:</label>
                        <div class=" col-md-3">
                            <asp:DropDownList class="form-control" ID="VehiculoDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="PrecioDropDown_SelectedIndexChanged"></asp:DropDownList>
                        </div>


                        <%--Precio--%>
                        <label class="control-label col-md-1" for="PrecioTextBox">Precio:</label>
                        <div class="col-md-4">
                            <asp:TextBox type="Number" class="form-control" ID="PrecioTextBox" Text="0" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="PrecioTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Ingrese un valor correcto!" ControlToValidate="PrecioTextBox" ValidationExpression="^[0-9.00]*$"></asp:RegularExpressionValidator>
                        </div>
                        <%--Agregar--%>
                        <div class="col-md-2">
                            <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" class="btn btn-success" OnClick="ButtonAgregar_Click" />
                        </div>
                    </div>


                    <%--Grid--%>
                    <div class="table-responsive">
                        <div class="center">
                            <asp:GridView ID="VentasGridView" runat="server" class="table table-condensed table-bordered table-responsive"  CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="true" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">

                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="RemoveLinkButton" runat="server" CausesValidation="false" CommandName="Select"
                                                Text="Remover" class="btn btn-danger btn-sm" OnClick="RemoveLinkButton_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                
                                <Columns>
                                    <asp:BoundField DataField="VehiculoId" HeaderText="VehiculoId" />                       
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="Vin" HeaderText="Vin" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />

                                </Columns>

                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                    </div>
                                     <%--Total--%>
                    <div class="form-group">
                        <label for="Total:" class="col-md-9 control-label input-sm">Total: </label>
                        <div class="col-md-3">
                            <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="TotalTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>


            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" ValidationGroup="guardar" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="guardar" OnClick="BtnGuardar_Click"/>
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" ValidationGroup="Buscar" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
        </div>
</asp:Content>
