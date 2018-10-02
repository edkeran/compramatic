<%@ page title="" language="C#" masterpagefile="~/Presentacion/MasterHome.master" autoeventwireup="true" inherits="Presentacion_VerProducto, App_Web_4kwpqrqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN product -->
    <div class="product">
        <!-- BEGIN product-detail -->
        <div class="product-detail">
            <!-- BEGIN product-image -->
            <div class="product-image">
                <!-- BEGIN product-thumbnail -->
                <div class="product-thumbnail">
                    <ul class="product-thumbnail-list">
                        <asp:Repeater runat="server" ID="RP_FotosProductos">
                            <ItemTemplate>
                                <li>
                                    <a href="#" data-click="show-main-image" data-url='<%# Eval("[nomArchivo]") %>'>
                                    <img src='<%# Eval("[nomArchivo]") %>' alt="" /></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <!-- END product-thumbnail -->
                <!-- BEGIN product-main-image -->
                <div class="product-main-image" data-id="main-image"  >
                    <img src='' />
                </div>
                <!-- END product-main-image -->
            </div>
            <!-- END product-image -->
            <!-- BEGIN product-info -->
            <div class="product-info">
                <!-- BEGIN product-info-header -->
                <div class="product-info-header">
                    <h1 class="product-title">
                        <span class="label label-success">
                            <asp:Label ID="LB_NombreProducto" runat="server"></asp:Label>
                        </span>
                    </h1>
                    <br />
                </div>
           
                     <!-- END product-info-header -->
                <!-- BEGIN product-info-list -->
                <ul class="product-info-list">
                    <li><asp:Label ID="LB_info" runat="server">Informacion:</asp:Label>
                        <asp:Label ID="LB_DescripcionProducto" runat="server"></asp:Label></li>

                </ul>
                <!-- END product-info-list -->
                <ul class="product-info-list">
                    <li><asp:Label ID="LB_Cant_Disp" runat="server">Cantidad Disponible:</asp:Label>
                    <asp:Label ID="LB_CantidadProducto" runat="server"></asp:Label></li>
                </ul>
                <ul class="product-info-list">
                    <li><asp:Label ID="LB_Empresa" runat="server">Empresa:</asp:Label>
                    <asp:Label ID="LB_NombreEmpresa" runat="server"></asp:Label></li>
                </ul>
                <ul class="product-info-list">
                    <li><asp:Label ID="LB_Cat" runat="server">Categoria:</asp:Label>
                    <asp:Label ID="LB_CategoriaProducto" runat="server"></asp:Label></li>
                </ul>
                <!-- BEGIN product-purchase-container -->
                <div class="product-info-list">
                    <div class="product-price">
                         <ul class="product-info-list">
                            <li class="price">
                                <asp:Label ID="LB_PrecioProducto" runat="server"></asp:Label>
                            </li>
                         </ul>
                    </div>
                    <ul class="product-info-list">
                        <li><asp:Label ID="LB_Cantidad_Comprar" runat="server">Cantidad A Comprar:</asp:Label>
                            <asp:TextBox ID="TB_CantidadVenta" runat="server" TextMode="Number" min="1" max="1000000"></asp:TextBox></li>

                    </ul>
                    <ul class="product-info-list">
                            <asp:Button ID="BTN_ComprarProducto" runat="server" CssClass="btn btn-inverse btn-lg fa fa-shopping-cart" Text="COMPRAR" OnClick="BTN_ComprarProducto_Click" />
                    </ul>
                </div>
                <!-- END product-purchase-container -->
            </div>
            <!-- END product-info -->
        </div>
        <!-- END product-detail -->
    </div>
    <!-- END product -->
    <!-- #modal-dialog -->
    <div class="modal fade" id="modal-dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" runat="server" id="advert">Advertencia</h4>
                </div>
                <div class="modal-body">
                    <asp:Label runat="server" ID="MensajeModal"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="BTN_Modal" OnClick="BTN_Modal_Click" Visible="false" Text="Inicia sesión" CssClass="btn btn-sm btn-inverse"/>
                    <asp:Button runat="server" ID="BTN_Yes" OnClick="BTN_Yes_Click" Visible="false" Text="Confirmar compra" CssClass="btn btn-sm btn-inverse"/>
                    <a href="javascript:;" class="btn btn-sm btn-white" data-dismiss="modal">Close</a>
                </div>
            </div>
        </div>
    </div>
    <!-- begin PQR-panel -->
        <div class="theme-panel">
            <a href="javascript:;" data-click="theme-panel-expand" class="theme-collapse-btn"><i class="fa fa-ban"></i></a>
            <div class="theme-panel-content">
                <h5 class="m-t-0" runat="server" id="rep_prod">Reportar producto</h5>
                <div class="row m-t-10">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="DDL_Reportes" CssClass="form-control" datasize="10" data-live-search="true" data-style="btn-white" DataSourceID="OBS_MotivosR" DataTextField="desMotivo" DataValueField="idMotivoR">
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="OBS_MotivosR" SelectMethod="MostrarMotivosReporte" TypeName="Logica.L_Componentes"></asp:ObjectDataSource>
                        </div>
                     </div>
                </div>
                <div class="row m-t-10">
                    <div class="col-md-12">
                        <asp:Button runat="server" ID="BTN_Reportar" OnClick="BTN_Reportar_Click" class="btn btn-inverse btn-block btn-sm" Text="Reportar producto"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <!-- end theme-panel -->
</asp:Content>

