<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterDashBoardUsr.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/TopDiezUsr.aspx.cs" Inherits="Presentacion_TopDiezUsr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title">Últimos 10 productos vistos por el cliente</h4>
                </div>
                <div class="panel-body">
                    <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th>Fecha</th>
                                <th>Nombre Producto</th>
                                <th>Nombre Empresa</th>
                                <th>Ver Producto</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_TopTen" OnItemCommand="RP_TopTen_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaTop]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomEmpresa]") %></asp:Label>
                                        </td>
                                         <td>
                                            <div class="btn-group">
                                                <div class="m-b-5">
                                                    <asp:Button runat="server" ID="BTN_VerProducto" Text="Ver producto" CssClass="btn btn-primary btn-default " CommandName="Ver" CommandArgument='<%# Eval("[idProducto]") %>'/>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

