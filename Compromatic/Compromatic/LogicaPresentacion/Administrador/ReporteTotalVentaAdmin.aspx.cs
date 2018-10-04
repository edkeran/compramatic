using System;
using System.Data;
using Logica;
using Utilitarios;

public partial class Presentacion_ReporteTotalVentaAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_ReporteTotVenta logi = new L_ReporteTotVenta();
        try
        {
            logi.page_load(Session["Sesion"]);
            CRS_Ventas.ReportDocument.SetDataSource(obtenerVentas());
            CRV_Ventas.ReportSource = CRS_Ventas;
        }
        catch (Exception ert)
        {
            Response.Redirect("LoginUsr.aspx");
        }
      
    }

    
    protected Utilitarios.DataSet obtenerVentas()
    {
        Utilitarios.DataSet compras = new Utilitarios.DataSet();
        L_ReporteTotVenta logi = new L_ReporteTotVenta();
        DataTable data = new DataTable();
        data = compras.VentasTotales;
        logi.obtener_ventas(data);
        return compras;
    }
}