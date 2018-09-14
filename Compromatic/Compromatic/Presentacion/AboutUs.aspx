<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/AboutUs.aspx.cs" Inherits="Presentacion_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="about-us-cover" class="has-bg section-container">
            <!-- BEGIN cover-bg -->
            <div class="cover-bg">
                <img src="../App_themes/Home/assets/img/about-us-cover.jpg" alt="" />
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
    <div id="about-us-content" class="section-container bg-white">
            <!-- BEGIN container -->
            <div class="container">
                <!-- BEGIN about-us-content -->
                <div class="about-us-content">
                    <h2 class="title text-center" id="que_hac" runat="server">¿Qué hacemos?</h2>
                    <p class="desc text-center" id="desc" runat="server"></p>
                    
                    <!-- BEGIN row -->
                    <div class="row">
                        <!-- begin col-4 -->
                        <div class="col-md-4 col-sm-4">
                            <div class="service">
                                <div class="icon text-muted"><a href="Store.aspx"><i class="fa fa-search"></i></a></div>
                                <div class="info">
                                    <h4 class="title" id="title" runat="server">Explora</h4>
                                    <p class="desc" id="explore" runat="server">Explora en nuestra tienda, y encuentra todos los productos que desees, seguramente encontrarás acá la solución a tus necesidades.</p>
                                </div>
                            </div>
                        </div>
                        <!-- end col-4 -->
                        <!-- begin col-4 -->
                        <div class="col-md-4 col-sm-4">
                            
                            <div class="service">
                                <div class="icon text-primary"><a href="RegistroUsuario.aspx"><i  class="fa fa-universal-access"></i></a></div>
                                <div class="info">
                                    
                                    <h4 class="title" id="profile" runat="server">Create your own profile</h4>
                                    <p class="desc" id="desc2" runat="server">Únete como cliente, edita tu información, contacta empresas, has compras, y lleva un registro minucioso de tus compras y visitas, y lo mejor es que es GRATIS!</p>
                                    
                                </div>
                            </div>
                                
                        </div>
                        <!-- end col-4 -->
                        <!-- begin col-4 -->
                        <div class="col-md-4 col-sm-4">
                            <div class="service">
                                <div class="icon text-info"><i class="fa fa-assistive-listening-systems"></i></div>
                                <div class="info">
                                    <h4 class="title" id="atencion" runat="server">Atención al usuario</h4>
                                    <p class="desc" id="desc3" runat="server">Tenemos comunicación directa con los clientes, para mejorar su experiencia de compra online, atendemos tus quejas y tenemos presente tu bienestar.</p>
                                </div>
                            </div>
                        </div>
                        <!-- end col-4 -->
                    </div>
                    <!-- END row -->
                    <hr />
                    <!-- BEGIN row -->
                    <div class="row">
                        <!-- begin col-4 -->
                        <div class="col-md-4 col-sm-4">
                            <div class="service">
                                <div class="icon text-danger"><a href="RegistroEmpresa.aspx"><i class="fa fa-cc-discover"></i></a></div>
                                <div class="info">
                                    <h4 class="title" id="comp" runat="server">Eres una empresa?</h4>
                                    <p class="desc" id="desc4" runat="server">Ingresa a nuestra tienda, registrate y publica tus productos, es hora de hacer crecer tus ventas, consulta nuestros planes de membresia.</p>
                                </div>
                            </div>
                        </div>
                        <!-- end col-4 -->
                        <!-- begin col-4 -->
                        <div class="col-md-4 col-sm-4">
                            <div class="service">
                                <div class="icon text-inverse"><i class="fa fa-connectdevelop"></i></div>
                                <div class="info">
                                    <h4 class="title" id="conec" runat="server">Conectividad</h4>
                                    <p class="desc" id="desc5" runat="server">Acercamos a las empresas con sus clientes.</p>
                                </div>
                            </div>
                        </div>
                        <!-- end col-4 -->
                        <!-- begin col-4 -->
                        <div class="col-md-4 col-sm-4">
                            <div class="service">
                                <div class="icon text-success"><i class="fa fa-braille"></i></div>
                                <div class="info">
                                    <h4 class="title" id="comp_inv" runat="server">Compras e inventario</h4>
                                    <p class="desc" id="desc6" runat="server">Te ayudamos con el control de tus ventas e inventarios, es fácil y sencillo, en tu perfil de Empresa encontrarás cómo hacerlo.</p>
                                </div>
                            </div>
                        </div>
                        <!-- end col-4 -->
                    </div>
                    <!-- END row -->
                </div>
                <!-- END about-us-content -->
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
                <div class="copyright">
                    COMPRAMATIC &copy; 2016 A NEW SHOPPING WAY. All rights reserved.
                </div>
            </div>
     </div>
    
</asp:Content>



