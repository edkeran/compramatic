<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Home.aspx.cs" Inherits="Presentacion_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div id="about-us-cover" class="has-bg section-container">
            <!-- BEGIN cover-bg -->
            <div class="cover-bg">
                <img src="../App_themes/Home/assets/img/HomeCover.jpg" alt="" />
            </div>
            <!-- END cover-bg -->
            <!-- BEGIN container -->
            <div class="container">
                <!-- BEGIN breadcrumb -->
               
                <!-- END breadcrumb -->
                <!-- BEGIN about-us -->
                <div class="about-us text-center">
                    <h1>COMPRAMATIC</h1>
                    <p>
                        A NEW SHOPPING WAY
                    </p>
                </div>
                <!-- END about-us -->
                 <!-- BEGIN #about-us-content -->
        
            </div>
            <!-- END container -->
        </div>
    <div id="footer-copyright" class="footer-copyright">
            <!-- BEGIN container -->
            <div class="container">
                <div class="payment-method">
                        <td><a href="#"><i class="fa fa-facebook f-s-14"></i></a></td>
                        <td><a href="#"><i class="fa fa-twitter f-s-14"></i></a></td>
                        <td><a href="#"><i class="fa fa-instagram f-s-14"></i></a></td>
                        <td><a href="#"><i class="fa fa-dribbble f-s-14"></i></a></td>
                        <td><a href="#"><i class="fa fa-google-plus f-s-14"></i></a></td>
               </div>
                <!--Div para el DLL de los Idiomas En La BD-->
                <asp:DropDownList ID="DDL_Idioma" runat="server" DataSourceID="ObjectDataSource1" DataTextField="terminacion" DataValueField="id_idioma" OnSelectedIndexChanged="DDL_Idioma_SelectedIndexChanged" OnTextChanged="DDL_Idioma_SelectedIndexChanged"></asp:DropDownList>
                <asp:Button ID="BTN_Idioma" runat="server" Text="Cambiar Idioma" OnClick="BTN_Idioma_Click" CssClass="btn btn-primary" />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="obtener_Idiomas" TypeName="Logica.L_Home"></asp:ObjectDataSource>
                <div>

                </div>
                <div class="copyright">
                    COMPRAMATIC &copy; 2018 A NEW SHOPPING WAY. All rights reserved.
                </div>
            </div>
     </div>
</asp:Content>

