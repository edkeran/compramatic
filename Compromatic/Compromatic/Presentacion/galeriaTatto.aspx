<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/galeriaTatto.aspx.cs" Inherits="Presentacion_galeriaTatto" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
    th
    {
        text-align:center !important;
    }
    .lb{
        vertical-align:central !important;
    }
    </style>
    <div style="padding:2%; text-align: center;background-color:blanchedalmond">
        <asp:Image ID="IMG_Tatto" runat="server" ImageUrl="~/Archivos/Asociados/Tatto.png" Height="187px" CssClass="text-center" Width="691px" />
    </div>
     <h1 style="text-align: center;" runat="server" id="title">Galeria Tatto Studio<br /><small>Los Mejores Tatuajes Del Departamento</small></h1>
   <div style="padding:0 10%;padding-top:1%">
     <asp:GridView ID="GV_Tatto" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="2" BorderStyle="Groove" class="table table-hover" Width="100%"  OnPageIndexChanging="GV_Tatto_PageIndexChanging">
         <Columns>
             <asp:TemplateField HeaderText="Imagen" HeaderStyle-Width="50%">
                 <ItemTemplate>
                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("img") %>' Width="200px" Height="200px" OnClick="ImageButton1_Click" />
                 </ItemTemplate>
                <HeaderStyle Width="50%"></HeaderStyle>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Artista" HeaderStyle-Width="50%">
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval ("nombre") %>'  CssClass=""></asp:Label>
                                 </ItemTemplate>

                <HeaderStyle Width="50%"></HeaderStyle>
                             </asp:TemplateField>
         </Columns>
     </asp:GridView>
  </div>
</asp:Content>

