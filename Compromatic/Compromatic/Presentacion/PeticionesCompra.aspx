<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/PeticionesCompra.aspx.cs" Inherits="Presentacion_PeticionesCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title" runat="server" id="pet">Peticiones de Compra</h4>
                </div>
                <div class="panel-body">
                    <table id="data-table" class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th id="nom" runat="server">Nombre</th>
                                <th id="celular" runat="server">Telefono</th>
                                <th id="mail" runat="server">Correo</th>
                                <th id="dir" runat="server">Direccion</th>
                                <th id="cal" runat="server">Calificacion</th>
                                <th id="prod" runat="server">Producto</th>
                                <th>#</th>
                                <th id="stk" runat="server">Stock</th>
                                <th id="val" runat="server">Valor</th>
                                <th id="fe" runat="server">Fecha</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_Peticiones" OnItemCommand="RP_Peticiones_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomUsuario]") %> <%# Eval("[apeUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[telUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[correoUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[dirUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[calificacionUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[cantVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[canProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[valorVenta ]") %>$</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <div class="btn-group">
                                                <div class="m-b-5">
                                                    <asp:Button runat="server" ID="BTN_Aceptar" Text="Aceptar" CssClass="btn btn-primary btn-default " CommandName="Aceptar" CommandArgument='<%# Eval("[idVenta]") %>' />
                                                </div>
                                                <div>
                                                    <asp:Button runat="server" Text="Declinar" ID="BTN_Declinar" CssClass="btn btn-danger btn-default" CommandName="Declinar" CommandArgument='<%# Eval("[idVenta]") %>' />
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
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-repeat"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>
                    <h4 class="panel-title" id="comp_proc" runat="server">Compras en Proceso</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th id="nomb" runat="server">Nombre</th>
                                <th id="telefo" runat="server">Telefono</th>
                                <th id="mai" runat="server">Correo</th>
                                <th id="direc" runat="server">Direccion</th>
                                <th id="calif" runat="server">Calificacion</th>
                                <th id="product" runat="server">Producto</th>
                                <th id="valu" runat="server">Valor</th>
                                <th id="date" runat="server">Fecha</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_EnProceso" OnItemCommand="RP_EnProceso_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomUsuario]") %> <%# Eval("[apeUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[telUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[correoUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[dirUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[calificacionUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[valorVenta ]") %>$</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="BTN_Rechazar" Text="Rechazar" CssClass="btn btn-danger btn-default " CommandName="Cancelar" CommandArgument='<%# Eval("[idVenta]") %>' />
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
                    <h4 class="panel-title" id="calific" runat="server">Calificar</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th id="nomber" runat="server">Nombre</th>
                                <th id="celu" runat="server">Telefono</th>
                                <th id="corr" runat="server">Correo</th>
                                <th id="direcc" runat="server">Direccion</th>
                                <th id="cali" runat="server">Calificacion</th>
                                <th id="prdcto" runat="server">Producto</th>
                                <th id="valo" runat="server">Valor</th>
                                <th id="fha" runat="server">Fecha</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_VentasRealizadas" OnItemCommand="RP_VentasRealizadas_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomUsuario]") %> <%# Eval("[apeUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[telUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[correoUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[dirUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[calificacionUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[valorVenta ]") %>$</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="BTN_Calificar" Text="Calificar" CssClass="btn btn-primary btn-default " CommandName="Calificar" CommandArgument='<%# Eval("[idVenta]") %>' />
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
                    <h4 class="panel-title" id="vent_made" runat="server">Ventas Hechas</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped table-bordered data-table" width="100%">
                        <thead>
                            <tr>
                                <th id="nbre" runat="server">Nombre</th>
                                <th id="tfn" runat="server">Telefono</th>
                                <th id="maii" runat="server">Correo</th>
                                <th id="dirc" runat="server">Direccion</th>
                                <th id="calificar" runat="server">Calificacion</th>
                                <th id="pcto" runat="server">Producto</th>
                                <th id="valor" runat="server">Valor</th>
                                <th id="fecha" runat="server">Fecha</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RP_Finalizadas" OnItemCommand="RP_VentasRealizadas_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomUsuario]") %> <%# Eval("[apeUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[telUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[correoUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[dirUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[calificacionUsuario]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[nomProducto]") %></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[valorVenta ]") %>$</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server"><%# Eval("[fechaVenta]") %></asp:Label>
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
    <!-- #modal-dialog -->
    <div class="modal fade" id="modal-dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <asp:Label runat="server" ID="MensajeModal"></asp:Label>
                </div>
                <div class="modal-footer">
                    <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
                </div>
            </div>
        </div>
    </div>
    <!-- #modal-Calificar -->
    <div class="modal fade" id="modal-calificar">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="calfc" runat="server">Calificar</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-12">
                                <label id="LB_Calif" runat="server">Calificacion:</label><asp:TextBox runat="server" ID="TB_Calificacion" placeholder="1-10" TextMode="Number" min="1" max="10" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Calificacion" ValidationGroup="calificacion"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <label id="coment" runat="server">Comentario:</label><asp:TextBox runat="server" ID="TB_Comentario" placeholder="max 100" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator runat="server" ValidationGroup="calificacion" ValidationExpression="^[\s\S]{0,850}$" ErrorMessage="Numero de Caracteres Excedido (Max 100)" ControlToValidate="TB_Comentario"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator runat="server" CssClass="alert-warning" ErrorMessage="Campo Necesario" ForeColor="Red" ControlToValidate="TB_Comentario" ValidationGroup="calificacion"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Label runat="server" ID="LB_Venta" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="LB_Usuario" Visible="false"></asp:Label>
                    <asp:Button runat="server" CssClass="btn btn-sm btn-primary" ID="BTN_Calificar" OnClick="BTN_Calificar_Click" Text="Calificar" ValidationGroup="calificacion" />
                    <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

