<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="sCarDealerW.Consultas.cUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Consulta de Usuarios</div>
        </div>

        <div class="form-horizontal col-md-12" role="form">

            <div class="panel panel-primary">
                <div class="panel-body">

                        <%--Selercionar solo por fecha--%>
                         <div class="form-group row">
                        <label for="CheckBox" class="col-md-2 col-form-label">Filtral por fecha?</label>
                        <div class="col-ms-2">
                            <asp:CheckBox runat="server" CssClass="custom-checkbox" ID="CheckBox" />
                        </div>
                    </div>

                    <%--Desde--%>
                <div class="form-group row">
                    <label class="control-label col-md-2" for="DesdeTextBox">Desde:</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="DesdeTextBox" CssClass="form-control input-group" TextMode="Date" runat="server" />
                    </div>


                    <%--Hasta--%>
                    <label class="control-label col-md-1" for="HastaTextBox">Hasta:</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="HastaTextBox" CssClass="form-control input-group" TextMode="Date" runat="server" />
                    </div>
                </div>

                                <%--DropDownList--%>
                    <div class="form-group row">
                        <label class="control-label col-md-2" for="DesdeTextBox">Seleccione uno:</label>
                        <div class="col-md-2">
                            <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem>Todos</asp:ListItem>
                                <asp:ListItem>UsuarioID</asp:ListItem>
                                <asp:ListItem>Nombre</asp:ListItem>
                                <asp:ListItem>Fecha</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <%--Criterio--%>
                        <label class="control-label col-md-1" for="CriterioTextBox">Criterio:</label>
                        <div class="col-md-2">
                            <asp:TextBox type="text" class="form-control" ID="CriterioTextBox" placeholder="Ingrese Criterio" runat="server"></asp:TextBox>
                        </div>


                        <%--Buscar--%>
                        <div class="col-md-4">
                            <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" />
                        </div>
                    </div>

                    <br /> <br />
                    <%--GRID--%>
                    <div class="table-responsive">
                        <div class="center">
                            <div class="col-md-12">
                                <asp:GridView ID="DatosGridView"
                                    runat="server"
                                    CssClass="table table-condensed table-bordered table-responsive"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:HyperLinkField ControlStyle-ForeColor="blue"
                                            DataNavigateUrlFields="UsuarioID"
                                            DataNavigateUrlFormatString="~/UI/Registros/RegistroUsuario.aspx?Id={0}"
                                            Text="Editar"></asp:HyperLinkField>
                                    </Columns>
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--Imprimir--%>
            <div class="container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-4">
                        <asp:Button ID="Button" runat="server" Class=" col-md-4 btn btn-danger input-sm" Text="Imprimir" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>