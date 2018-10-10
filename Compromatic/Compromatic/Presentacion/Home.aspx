<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Home.aspx.cs" Inherits="Presentacion_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <link href="../App_Themes/Assets/css/Main_Ajax.css" rel="stylesheet"/>
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
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:DropDownList ID="DDL_Idioma" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Terminacion" DataValueField="Id_Idioma" OnSelectedIndexChanged="DDL_Idioma_SelectedIndexChanged" OnTextChanged="DDL_Idioma_SelectedIndexChanged"></asp:DropDownList>
                <asp:Button ID="BTN_Idioma" runat="server" Text="Cambiar Idioma" OnClick="BTN_Idioma_Click" CssClass="btn btn-primary" />
                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server"
                    TargetControlID="BTN_Idioma"
                    ConfirmText="Estas Seguro De Cambiar El Idioma?"
                    OnClientCancel="CancelClick"
                    DisplayModalPopupID="MPE"
                    Enabled="true"
                     
                    />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="get_idioms" TypeName="Logica.L_Home"></asp:ObjectDataSource>
                <ajaxToolkit:ModalPopupExtender ID="MPE" runat="server"
                        TargetControlID="BTN_Idioma"
                        PopupControlID="Panel1"
                        BackgroundCssClass="modalBackground" 
                        DropShadow="true" 
                        OkControlID="BTN_Acep"
                        CancelControlID="BTN_Can"
                        PopupDragHandleControlID="PopupHeader"/>

                <ajaxToolkit:AnimationExtender ID="ae"
                      runat="server" TargetControlID="BTN_Idioma">
                        <Animations>
                            <OnClick> 
                                <Sequence>
                                   <FadeIn Duration="1.5" Fps="60" AnimationTarget="Panel1"/>
                                </Sequence>
                            </OnClick>
                        </Animations>
                    </ajaxToolkit:AnimationExtender>
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center">
                     <asp:Panel runat="server" ID="PopupHeader" CssClass="modalHeader">
                        <asp:Label ID="LB_head" runat="server" Text="Deseas Cambiar El Idioma?"></asp:Label>
                    </asp:Panel>
                    <br />
                    <asp:Button ID="BTN_Acep" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
                    <br /><br />
                    <asp:Button ID="BTN_Can" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                    <br /><br />
                </asp:Panel>
                <div>

                </div>
                <div class="copyright">
                    COMPRAMATIC &copy; 2018 A NEW SHOPPING WAY. All rights reserved.
                </div>
            </div>
     </div>
</asp:Content>

