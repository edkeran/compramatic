<%@ page title="" language="C#" masterpagefile="~/Presentacion/MasterDashBoardUsr.master" autoeventwireup="true" inherits="Presentacion_HistorialUsr, App_Web_4kwpqrqr" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Compras" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" HasRefreshButton="True" Height="50px" ReportSourceID="CRS_Compras" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CRS_Compras" runat="server">
            <Report FileName="~\Reportes\ComprasUsr.rpt">
            </Report>
        </CR:CrystalReportSource>
    
        
</asp:Content>

