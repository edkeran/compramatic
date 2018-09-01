<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Inventario.aspx.cs" Inherits="Presentacion_Inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin #content -->
    <div id="content">
        <!-- begin page-header -->
        <h1 class="page-header">Inventario</h1>
        <!-- end page-header -->

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Productos con bajo inventario</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                                <thead>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Descripcion</th>
                                        <th>Cantidad</th>
                                        <th>Cantidad Minima</th>
                                        <th>Categoria</th>
                                        <th>Modificar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="Productos" DataSourceID="OBS_Productos" OnItemCommand="Productos_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" Width="50px" Style="word-wrap: normal; word-break: break-all;" runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("[desProducto]") %>' ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TB_Cantidad" CssClass="form-control" runat="server" Text='<%# Eval("[canProducto]") %>' TextMode="Number" min="0" max="1000000"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TB_Alerta" CssClass="form-control" runat="server" Text='<%# Eval("[bajoInventario]") %>' TextMode="Number" min="0" max="1000000"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" Width="3px" runat="server"><%# Eval("[nomCategoria]") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" CommandName="Modificar" Text="Modificar Cantidad" CssClass="btn btn-primary" CommandArgument='<%# Eval("[idProducto]")%>'/>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:ObjectDataSource runat="server" ID="OBS_Productos" SelectMethod="ProductosBajoI" TypeName="DAOProducto">
                                        <SelectParameters>
                                            <asp:SessionParameter SessionField="IdEmpresa" Name="idEmpresa" Type="Int32"></asp:SessionParameter>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- end #content -->
</asp:Content>

