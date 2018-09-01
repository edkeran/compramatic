<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/DashEmpresa.master" AutoEventWireup="true" CodeFile="~/LogicaPresentacion/HistoricoCalificaciones.aspx.cs" Inherits="Presentacion_HistoricoCalificaciones" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Calificaciones" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" HasRefreshButton="True" Height="50px" ReportSourceID="CRS_Calificaciones" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CRS_Calificaciones" runat="server">
            <Report FileName="~\Reportes\Calificaciones.rpt">
            </Report>
        </CR:CrystalReportSource>
</asp:Content>

