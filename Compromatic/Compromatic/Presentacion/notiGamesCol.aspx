<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/notiGamesCol.aspx.cs" Inherits="Presentacion_notiGamesCol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
    th
    {
        text-align:center !important;
    }
    </style>
     <div style="padding:2%; text-align: center;background-color:darkgray">
        <asp:Image ID="IMG_gamesCol" runat="server" ImageUrl="~/Archivos/Asociados/GamesCol.jpg" Height="150px" CssClass="text-center" />
    </div>
      <h1 style="text-align: center;" runat="server" id="title">Noticias GamesCol <br /><small>El Mejor Sitio Web Para Mantenerte Informado de Los VideoJuegos</small></h1>
    <div>
        <asp:GridView ID="GV_miPost" runat="server" Width="100%"></asp:GridView>
    </div>
</asp:Content>

