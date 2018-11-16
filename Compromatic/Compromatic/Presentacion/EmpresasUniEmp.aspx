<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterHome.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/EmpresasUniEmp.aspx.cs" Inherits="Presentacion_EmpresasUniEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
    th
    {
        text-align:center !important;
    }
    </style>
    <div style="padding:2%; text-align: center;">
        <asp:Image ID="IMG_UniEmp" runat="server" ImageUrl="~/Archivos/Asociados/UniEmpleo.png" Height="150px" CssClass="text-center" />
    </div>
    <h1 style="text-align: center;">Empresas De Uniempleo <br /><small>Nuestros Aliados Para Encontrar Trabajo</small></h1>
    <!--GRIDVIEW PARA TRAER LOS DATOS -->
     <div class="dataTables_empty">
         <div style="text-align:center">
             <asp:GridView ID="GV_Empre" runat="server" BorderStyle="Groove" class="table table-hover" AutoGenerateColumns="False" Width="100%">
             <AlternatingRowStyle BackColor="LightGray" />
            <Columns>
                <asp:BoundField DataField="Nombre_empresa" HeaderText="Nombre Empresa" HeaderStyle-BackColor="#99ccff" HeaderStyle-ForeColor="White"></asp:BoundField>
                <asp:BoundField DataField="Forma_juridica" HeaderText="Forma Juridica" HeaderStyle-BackColor="#99ccff" HeaderStyle-ForeColor="White"></asp:BoundField>
                <asp:BoundField DataField="Direccion_empresa" HeaderText="Direccion Empresa" HeaderStyle-BackColor="#99ccff" HeaderStyle-ForeColor="White"></asp:BoundField>
                <asp:BoundField DataField="Telefono_empresa" HeaderText="Telefono Empresa" HeaderStyle-BackColor="#99ccff" HeaderStyle-ForeColor="White"></asp:BoundField>
                <asp:BoundField DataField="Sector_economico" HeaderText="Sector Economico" HeaderStyle-BackColor="#99ccff" HeaderStyle-ForeColor="White"></asp:BoundField>
            </Columns>
        </asp:GridView>
         </div>
    </div>
</asp:Content>

