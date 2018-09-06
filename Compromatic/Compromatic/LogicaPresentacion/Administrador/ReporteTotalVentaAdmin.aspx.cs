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

    /**
     * if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            DataTable datos = (DataTable)Session["Sesion"];
            if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 1)
            {
                Response.Redirect("LoginUsr.aspx");
            }
            
            CRS_Ventas.ReportDocument.SetDataSource(obtenerVentas());
            CRV_Ventas.ReportSource = CRS_Ventas;

        } 
     * */
    protected DataSet obtenerVentas()
    {
        DataSet compras = new DataSet();
        L_ReporteTotVenta logi = new L_ReporteTotVenta();
        DataTable data = new DataTable();
        data = compras.VentasTotales;
        logi.obtener_ventas(data);
        return compras;
    }
}