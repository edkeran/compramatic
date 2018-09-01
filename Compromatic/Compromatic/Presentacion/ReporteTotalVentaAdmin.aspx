<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterSuperAdministrador.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/Administrador/ReporteTotalVentaAdmin.aspx.cs" Inherits="Presentacion_ReporteTotalVentaAdmin" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="content">
        <CR:CrystalReportViewer ID="CRV_Ventas" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" HasRefreshButton="True" Height="50px" ReportSourceID="CRS_Ventas" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="100%" />
        <CR:CrystalReportSource ID="CRS_Ventas" runat="server">
            <Report FileName="~\Reportes\VentasTotales.rpt">
            </Report>
        </CR:CrystalReportSource>
        </div>

    
    
</asp:Content>
