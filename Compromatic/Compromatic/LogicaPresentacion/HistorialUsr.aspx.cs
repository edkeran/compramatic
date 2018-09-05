using System;
using System.Data;
using Logica;

public partial class Presentacion_HistorialUsr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_HistorialUsr logica = new L_HistorialUsr();
            logica.page_load(Session["Sesion"]);
            CRS_Compras.ReportDocument.SetDataSource(obtenerCompras());
            CRV_Compras.ReportSource = CRS_Compras;

        }catch (Exception ex)
        {
            L_HistorialUsr logica = new L_HistorialUsr();
            logica.validarExcepcion(ex.Message);
            Response.Redirect("LoginUsr.aspx");
        }
    }

    protected DataSet obtenerCompras()
    {

        DataTable datos = (DataTable)Session["Sesion"];
        DataSet compras = new DataSet();
        EUsuario user = new EUsuario();
        //DAOUsuario bdcompra=new DAOUsuario();
        user.IdUsr=int.Parse(datos.Rows[0]["idUsuario"].ToString());
        //DataTable historial = bdcompra.HistorialCompras(user,4);
        DataTable data = new DataTable();
        data = compras.HistorialCompras;
        L_HistorialUsr logi = new L_HistorialUsr();
        logi.obtenerCompras(Session["Sesion"],data);
        return compras;
    }

    /**
     *
     data = compras.HistorialCompras;
     DataRow fila;

        for (int i = 0; i < historial.Rows.Count; i++)
        {
            fila = data.NewRow();
            
            fila["idVenta"] = historial.Rows[i]["idVenta"].ToString();
            String muestra = fila["idVenta"].ToString();
            fila["fechaVenta"] = historial.Rows[i]["fechaVenta"].ToString();
            String muestra1 = fila["fechaVenta"].ToString();
            fila["fechaEntrega"] = historial.Rows[i]["fechaEntrega"].ToString();
            String muestra2 = fila["fechaEntrega"].ToString();
            fila["cantVenta"] = historial.Rows[i]["cantVenta"].ToString();
            String muestra3 = fila["cantVenta"].ToString();
            fila["estadoVenta"] = historial.Rows[i]["estadoVenta"].ToString();
            String muestra4 = fila["estadoVenta"].ToString();
            fila["valorVenta"] = historial.Rows[i]["valorVenta"].ToString();
            String muestra5 = fila["valorVenta"].ToString();
            fila["nomProducto"] = historial.Rows[i]["nomProducto"].ToString();
            String muestra6 = fila["nomProducto"].ToString();
            fila["nomEmpresa"] = historial.Rows[i]["nomEmpresa"].ToString();
            String muestra7 = fila["nomEmpresa"].ToString();
            data.Rows.Add(fila);
        }
        return compras; 
     **/
}