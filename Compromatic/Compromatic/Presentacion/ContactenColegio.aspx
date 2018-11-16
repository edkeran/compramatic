<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/ContactenColegio.aspx.cs" Inherits="Presentacion_ContactenColegio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="../App_Themes/JS-Redireccion/Funiones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="padding:2%; text-align: center;">
        <asp:Image ID="IMG_Ferro" runat="server" ImageUrl="~/Archivos/Asociados/Colegio.jpg" Height="237px" CssClass="text-center" />
    </div>
     <h1 style="text-align: center;">Contactar Al Mejor Colegio Del Estado<br /><small>Aliados Patrocinadores</small></h1>
    <!--Div Para El Formulario De Contactenos De Colegio-->
    <div style="padding:0px 10%; padding-bottom:4%">
        <div class="form-group">
             <div class="input-group-prepend">
                <span class="input-group-text">Nombre:</span>
             </div>
            <asp:TextBox ID="TB_Nom" runat="server"  CssClass="form-control" onkeypress="return validarn(event)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Este Campo Es Obligatorio" ControlToValidate="TB_Nom" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
             <div class="input-group-prepend">
                <span class="input-group-text">Apellidos:</span>
             </div>
             <asp:TextBox ID="TB_Apell" runat="server" CssClass="form-control" onkeypress="return validarn(event)"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Este Campo Es Obligatorio" ControlToValidate="TB_Apell" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="input-group-prepend">
                <span class="input-group-text">Correo:</span>
            </div>
            <asp:TextBox ID="TB_Corr" runat="server" CssClass="form-control" onkeypress="return validarn(event)" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Este Campo Es Obligatorio" ControlToValidate="TB_Corr" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="input-group-prepend">
                <span class="input-group-text">Telefono:</span>
            </div>
            <asp:TextBox ID="TB_Telefono" runat="server" CssClass="form-control" onkeypress="return validarn(event)" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Este Campo Es Obligatorio"  ControlToValidate="TB_Telefono" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="input-group-prepend">
                <span class="input-group-text">Mensaje:</span>
            </div>
            <asp:TextBox ID="TB_MSG" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="5" onkeypress="return validarn(event)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Este Campo Es Obligatorio" ControlToValidate="TB_MSG" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="text-align:center">
            <asp:Button ID="Button1" runat="server" Text="Enviar Datos" CssClass="btn btn-primary" style="text-align:center" OnClick="BTN_Send"/>
        </div>
    </div>
</asp:Content>

