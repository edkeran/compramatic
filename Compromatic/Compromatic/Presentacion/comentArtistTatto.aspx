<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/comentArtistTatto.aspx.cs" Inherits="Presentacion_comentArtistTatto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
     th
     {
         text-align:center !important;
     } 
     </style>
    <div style="padding:2%; text-align: center;background-color:blanchedalmond">
        <asp:Image ID="IMG_Tatto" runat="server" ImageUrl="~/Archivos/Asociados/Tatto.png" Height="187px" CssClass="text-center" Width="691px" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1 style="text-align: center;">Comentarios De Artistas Tatto Studio <br /><small>Los Mejores Tatuajes Del Departamento</small></h1>
    <!--Div para el ComboBox para escoger la categoria-->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align:center;">
                <asp:DropDownList ID="DDL_artist" runat="server" CssClass="btn btn-default btn-sm"></asp:DropDownList>
                <asp:Button ID="BTN_Get" runat="server" Text="Cargar Datos"  OnClick="BTN_Get_Click" CssClass="btn btn-dark"/>
            </div>
            <div style="padding:1% 3%">
                <asp:GridView ID="GV_Comment" runat="server" AllowPaging="True" PageSize="10" BorderStyle="Groove" class="table table-hover" Width="100%" >
                    <HeaderStyle Width="50%"  BackColor="Gray" ForeColor="White"></HeaderStyle>
                    <emptydatarowstyle  BackColor="LightBlue"  ForeColor="Red"/>    
                        <emptydatatemplate>
                           No Se Han Encontrado Comentarios
                        </emptydatatemplate> 
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
             <asp:AsyncPostBackTrigger ControlID="BTN_Get" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

