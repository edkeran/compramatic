<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/SubsedesFerroNet.aspx.cs" Inherits="Presentacion_SubsedesFerroNet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--LOGO DE FERRONET-->
    <div style="padding:2%; text-align: center;">
        <asp:Image ID="IMG_Ferro" runat="server" ImageUrl="~/Archivos/Asociados/FerroNet.jpg" Width="50%" Height="200px" CssClass="text-center" />
    </div>
    <h1 style="text-align: center;">Subsedes De FerroNet <br /><small>Nuestros Aliados Comerciales</small></h1>
    <!--DIV PARA LA API DE GOOGLE MAPS BUSCAR EJEMPLO-->
    <div>
        <!--Label De Pruebas Para Pintar Los Datos-->
        <asp:GridView ID="GV_test" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Ubicacion Subsede Ferronet"  HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <div class="mapouter"><div class="gmap_canvas"><iframe width="100%" height="500" id="gmap_canvas" src="https://maps.google.com/maps?q=<%# Eval("Latitud") %>%2C%20<%# Eval("Longitud") %>&t=&z=15&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe><a href="https://www.embedgooglemap.net">embedgooglemap.net</a></div><style>.mapouter{text-align:right;height:500px;width:100%;}.gmap_canvas {overflow:hidden;background:none!important;height:500px;width:100%;}</style></div>
                        <%# Eval("Latitud") %>,<%# Eval("Longitud") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

