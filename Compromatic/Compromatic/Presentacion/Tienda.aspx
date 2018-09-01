<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Tienda.aspx.cs" Inherits="Presentacion_Tienda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container" style="margin-top:20px;">
            <div class="row">
                <h1 class="title" style="text-align:center">Tienda</h1>
                <div class="col-md-10 col-md-offset-1 main-shop text-center">
                    <div class="row shop-container">
                        <asp:Repeater runat="server" ID="RP_MostrarProducto" OnItemCommand="RP_MostrarProducto_ItemCommand">
                            <ItemTemplate>
                                <div class="col-md-3 col-sm-6 product text-center">
                                    <div class="product-holder">
                                        <img src='../Archivos/FotosProductos/<%# Eval("[_foto]") %>' class="pic" alt="" style="height: 200px; width: 100%">
                                        <div class="overlay">
                                            <a href='../Archivos/FotosProductos/<%# Eval("[_foto]") %>' data-rel="prettyPhoto"><i class="fa fa-plus"></i></a>
                                        </div>
                                    </div>
                                    <h5 class="no-transform"><%# Eval("[_nomproducto]") %></h5>
                                    <p>
                                        <%# Eval("[_desproducto]") %>
                                    </p>
                                    <h5 class="alt"><span class="price-new accent"><%# Eval("[_precioproducto]") %><sup>$</sup></span></h5>
                                    <asp:ImageButton ID="BTN_VerPdto" runat="server" CssClass="btn btn-default" CommandName="Ver" CommandArgument='<%# Eval("[_idproducto]") %>' AlternateText="Ver Producto" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

