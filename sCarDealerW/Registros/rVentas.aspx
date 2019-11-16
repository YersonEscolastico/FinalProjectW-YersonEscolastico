<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="sCarDealerW.Registros.rVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de Ventas</div>
        </div>


        <div class="form-horizontal col-md-12" role="form">

            <%--VentaId--%>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="VentaIdTextBox">Venta ID:</label>
                <div class="col-sm-1 col-md-2 col-xs4">
                    <asp:TextBox type="Number" class="form-control" ID="VentaIdTextBox" placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="VentaIdTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="VentaIdTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="VentaIdTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="VentaIdTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>


                <%--Buscar Button--%>
                <div class="col-sm-1 col-md-1 col-xs-2">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" ValidationGroup="Buscar" />
                </div>

                <%--Fecha--%>
                <div>
                    <label class="control-label col-sm-3" for="FechaTextBox">Fecha:</label>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-sm-1 col-md-2 col-xs4">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>
            <br>

            <%--Cliente--%>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="UsuarioTextBox">Cliente:</label>
                <div class="col-sm-1 col-md-3 col-xs4">
                    <asp:DropDownList class="form-control" ID="UsuarioDropDownList" runat="server"></asp:DropDownList>
                </div>

                <%--Fecha Fecha Registro--%>
                <label class="control-label col-sm-1" for="FechaRegistroTextBox">Fecha Registro:</label>
                <div class="col-sm-1 col-md-3">
                    <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="False" />
                </div>
            </div>


            <div class="panel panel-primary">
                <div class="panel-body">
                    <%--Vehiculo--%>
                    <div class="form-group row">
                        <label class="control-label col-sm-2" for="VehiculoTextBox">Vehiculo:</label>
                        <div class="col-sm-1 col-md-3 col-xs4">
                            <asp:DropDownList class="form-control" ID="VehiculoDropDownList" runat="server"></asp:DropDownList>
                        </div>

                        <%--Precio--%>
                        <label class="control-label col-sm-2" for="PrecioTextBox">Precio:</label>
                        <div class="col-sm-1 col-md-2 col-xs4">
                            <asp:TextBox type="Number" class="form-control" ID="PrecioTextBox" placeholder="0" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="PrecioTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="PrecioTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </div>

                        <div class="col-lg-0 p-4">
                            <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" class="btn btn-info" />
                        </div>
                    </div>
                    <hr>
                    <div class="col row">
                        <asp:GridView ID="VentasGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="#0066FF">
                            <AlternatingRowStyle BackColor="#999999" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="Opciones">
                                    <ItemTemplate>
                                        <asp:Button ID="Remover" runat="server" CausesValidation="false" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).DataItemIndex %>"
                                            Text="Remover" class="btn btn-danger btn-sm" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#005a65" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#005a65" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                    <hr>
                </div>
            </div>

        </div>
        <hr>
        <div class="panel">
            <div class="text-center">
                  <div class="form-group">
                            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" ValidationGroup="guardar" />
                            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="guardar" />
                            <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" ValidationGroup="Buscar"/>
                        </div>
            </div>
        </div>
        <hr>
    </div>
</asp:Content>
