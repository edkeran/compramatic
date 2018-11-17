<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/PublicacionesUser.aspx.cs" Inherits="Presentacion_PublicacionesUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
     th
     {
         text-align:center !important;
     } 
     </style>
     <h1 style="text-align: center;" id="title" runat="server">Publicacion De Los Usuarios En Compramatic<br /><small>Tu Opinion Cuenta</small></h1>
     <div style="padding:1% 3%">
                <asp:GridView ID="GV_Comments" runat="server" AllowPaging="True" PageSize="10" BorderStyle="Groove" class="table table-hover" Width="100%"  Visible="true">
                    <HeaderStyle Width="50%"  BackColor="Gray" ForeColor="White"></HeaderStyle>
                    <emptydatarowstyle  BackColor="LightBlue"  ForeColor="Red"/>    
                        <emptydatatemplate>
                           No Se Han Encontrado Publicaciones
                        </emptydatatemplate> 
                </asp:GridView>
     </div>
</asp:Content>

