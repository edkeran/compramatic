<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterDashBoardUsr.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/MisComprasUsr.aspx.cs" Inherits="Presentacion_MisComprasUsr" EnableEventValidation="false" %>

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
                    <h4 class="panel-title">Mis Peticiones de Compra</h4>
                </div>
                <div class="panel-body">
                    <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th>N° de Venta</th>
                                <th>Fecha</th>
                                <th>Cantidad</th>
                                <th>Valor</th>
                                <th>Nombre Empresa</th>
                                <th>Nombre Producto</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_Peticiones">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[idVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[cantVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server">$ <%# Eval("[valorVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomEmpresa]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
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
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title">Peticiones Aceptadas</h4>
                </div>
                <div class="panel-body">
                    <table id="data-table1" class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th>N° de Venta</th>
                                <th>Fecha</th>
                                <th>Cantidad</th>
                                <th>Valor</th>
                                <th>Nombre Empresa</th>
                                <th>Nombre Producto</th>
                                <th>Confirmar Producto Recibido</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_PeticionesAceptadas" OnItemCommand="RP_PeticionesAceptadas_ItemCommand" >
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[idVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[cantVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server">$ <%# Eval("[valorVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomEmpresa]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <div class="m-b-5">
                                                    <asp:Label Text="Calificación:" runat="server" />
                                                    <br />
                                                    <asp:TextBox runat="server"   ID="TB_Calificacion" TextMode="Number" Text="5"  CssClass="form-control" min="0" max="10"  />
                                                    <br />
                                                    <asp:Label Text="Comentarios:" runat="server" />
                                                <br />
                                                    <asp:TextBox runat="server"  ID="TB_Comentario" CssClass="form-control" MaxLength="100" />
                                                    <br />
                                                    <asp:Button runat="server" ID="BTN_Confirmar" Text="Confirmar" CssClass="btn btn-primary btn-default " CommandName="Confirmar" CommandArgument='<%# Eval("[idVenta]") %>' />
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
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title">Peticiones Rechazadas</h4>
                </div>
                <div class="panel-body">
                    <table id="data-table2" class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th>N° de Venta</th>
                                <th>Fecha</th>
                                <th>Cantidad</th>
                                <th>Valor</th>
                                <th>Nombre Empresa</th>
                                <th>Nombre Producto</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_PeticionesRechazadas">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[idVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[cantVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server">$ <%# Eval("[valorVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomEmpresa]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
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
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title">Compras Hechas</h4>
                </div>
                <div class="panel-body">
                    <table id="data-table3" class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th>N° de Venta</th>
                                <th>Fecha de Petición</th>
                                <th>Fecha de Entrega</th>
                                <th>Cantidad</th>
                                <th>Valor</th>
                                <th>Nombre Empresa</th>
                                <th>Nombre Producto</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_ComprasHechas">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[idVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("fechaEntrega") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[cantVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server">$ <%# Eval("[valorVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomEmpresa]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <td>
                            <div class="btn-group">
                                <div class="m-b-5">
                                    <asp:Button runat="server" ID="BTN_Historial" Text="Crear Historial" CssClass="btn btn-primary btn-default " OnClick="BTN_Historial_Click" />
                                </div>
                            </div>
                        </td>
                    </table>
                </div>

            </div>
        </div>
    </div>
    <!-- #modal-dialog -->
    <div class="modal fade" id="modal-dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Respuesta</h4>
                </div>
                <div class="modal-body">
                    <asp:Label runat="server" ID="MensajeModal"></asp:Label>
                </div>
                <div class="modal-footer">
                    <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal" id="myBtn">Close</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

