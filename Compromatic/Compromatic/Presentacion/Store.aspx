<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Store.aspx.cs" Inherits="Presentacion_Store" enableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-header" class="section-container page-header-container bg-black">
            <!-- BEGIN page-header-cover -->
        <div class="page-header-cover">
            <img src="../App_Themes/Home/assets/img/apple-cover.jpg"/>
        </div>
            <!-- END page-header-cover -->
            <!-- BEGIN container -->
        <div class="container">
            <h1 class="page-header">Productos</h1>
        </div>
            <!-- END container -->
    </div>

    <div id="search-results" class="section-container bg-silver">
            <!-- BEGIN container -->
            <div class="container">
                <!-- BEGIN search-container -->
                <div class="search-container">
                    <!-- BEGIN search-content -->
                    
                        <div class="search-item-container">
                            <!-- BEGIN item-row -->
                            <div class="item-row">
                                <!-- BEGIN item -->
                                <asp:Repeater runat="server" ID="RP_Productos" OnItemCommand="RP_Productos_ItemCommand">
                                    <ItemTemplate>
                                        <div class="item item-thumbnail">
                                            <a class="item-image">
                                                <img src='../Archivos/FotosProductos/<%# Eval("[_foto]") %>'/>
                                            </a>
                                            <div class="item-info">
                                                <h4 class="item-title">
                                                    <a><%# Eval("[_nomproducto]") %></a>
                                                </h4>
                                                <p class="item-desc"><%# Eval("[_desproducto]") %></p>
                                                <div class="item-price">$ <%# Eval("[_precioproducto]") %></div>
                                                <asp:Button ID="BTN_VerPdto" runat="server" CssClass="btn btn-default" CommandName="Ver" CommandArgument='<%# Eval("[_idproducto]") %>' Text="Ver Producto" OnClick="load_product" />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                           </div>
                        </div>
                    </div>
             
            </div>
    </div>



</asp:Content>

