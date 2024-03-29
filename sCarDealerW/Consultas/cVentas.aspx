﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="cVentas.aspx.cs" Inherits="sCarDealerW.Consultas.cVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="container">
        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Consulta de Ventas</div>
        </div>

        <div class="form-horizontal col-md-12" role="form">

            <div class="panel panel-primary">
                <div class="panel-body">


                    <%--Desde--%>
                <div class="form-group row">
                    <label class="control-label col-md-2" for="DesdeTextBox">Desde:</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="DesdeTextBox" CssClass="form-control input-group" TextMode="Date" runat="server" />
                    </div>


                    <%--Hasta--%>
                    <label class="control-label col-md-1" for="HastaTextBox">Hasta:</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="HastaTextBox" CssClass="form-control input-group" TextMode="Date" runat="server" />
                    </div>
                </div>

                                <%--DropDownList--%>
                    <div class="form-group row">
                        <label class="control-label col-md-2" for="DesdeTextBox">Elija una opcion:</label>
                        <div class="col-md-2">
                            <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem>Todos</asp:ListItem>
                                <asp:ListItem>VentaId</asp:ListItem>
                                <asp:ListItem>VehiculoId</asp:ListItem>
                                <asp:ListItem>Total</asp:ListItem>
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
                                    CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:HyperLinkField ControlStyle-ForeColor="blue"
                                            DataNavigateUrlFields="UsuarioID"
                                            DataNavigateUrlFormatString="~/Registros/rVentas.aspx?Id={0}"
                                            Text="Editar"></asp:HyperLinkField>
                                    </Columns>

                                        <Columns>
                                    <asp:BoundField DataField="VentaId" HeaderText="VentaId" />                       
                                    <asp:BoundField DataField="VehiculoId" HeaderText="VehiculoId" />  
                                    <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" /> 
                                     <asp:BoundField DataField="Total" HeaderText="Total" /> 
                                    <asp:BoundField DataField="FechaRegistro" HeaderText="FechaRegistro" DataFormatString="{0:dd/MM/yy}" /> 
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
                        <asp:Button ID="Button" runat="server" Class=" col-md-4 btn btn-danger input-sm" Text="Imprimir" OnClick="ImprimirButton_Click" />
                    </div>
                </div>
            </div>
           <br /><br /><br /><br /><br />
        </div>
    </div>
</asp:Content>