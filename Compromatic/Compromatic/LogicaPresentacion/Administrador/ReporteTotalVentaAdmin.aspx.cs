using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_ReporteTotalVentaAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Sesion"] == null)
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
    }
    protected DataSet obtenerVentas()
    {
       
        DataSet compras = new DataSet();
        DAOadministrador bdventa = new DAOadministrador();
        DataTable historial = bdventa.MostrarVentasPorEmpresa();
        DataTable data = new DataTable();
        data = compras.VentasTotales;
        DataRow fila;

        for (int i = 0; i < historial.Rows.Count; i++)
        {
            fila = data.NewRow();

            fila["nitEmp"] = historial.Rows[i]["nitEmpresa"].ToString();
            
            fila["nomEmp"] = historial.Rows[i]["nomEmpresa"].ToString();
            fila["calEmp"] = historial.Rows[i]["calificacionEmpresa"].ToString();
            fila["valorVentas"] = historial.Rows[i]["valor"].ToString();
            fila["totalVentas"] = historial.Rows[i]["ventas"].ToString();
           
            data.Rows.Add(fila);
        }
        return compras;
    }
}