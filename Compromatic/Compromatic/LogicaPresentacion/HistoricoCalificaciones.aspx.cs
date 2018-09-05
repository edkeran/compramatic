using System;
using System.Data;
using Logica;

public partial class Presentacion_HistoricoCalificaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_HistoricoCalificaciones logic = new L_HistoricoCalificaciones();
            String res=logic.page_inicial(IsPostBack, Session["Sesion"]);
            CRS_Calificaciones.ReportDocument.SetDataSource(Calificaciones());
            CRV_Calificaciones.ReportSource = CRS_Calificaciones;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scrt", "redireccionar('" + res + "');", true);
        }
        catch(Exception eg)
        {}
    }
    /**
     * if (!IsPostBack)
        {
            if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUsr.aspx");
            }
            DataTable Empresa = (DataTable)Session["Sesion"];
            if (Empresa.Rows[0]["idTipo"].ToString() != "2")
            {
                Response.Redirect("LoginUsr.aspx");
            }
            if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
            {
                Response.Redirect("PerfilEmpresa.aspx");
            }
            CRS_Calificaciones.ReportDocument.SetDataSource(Calificaciones());
            CRV_Calificaciones.ReportSource = CRS_Calificaciones;
        }
     **/

    protected DataSet Calificaciones()
    {
        DataSet compras = new DataSet();
        DataTable data = new DataTable();
        data = compras.Calificaciones;
        L_HistoricoCalificaciones logi = new L_HistoricoCalificaciones();
        logi.Calificaciones(Session["idEmpresa"],data);
        return compras;
    }

    /**
     * for (int i = 0; i < historial.Rows.Count; i++)
        {
            fila = data.NewRow();

            fila["Rango"] = historial.Rows[i]["rango"].ToString();
            fila["Comentario"] = historial.Rows[i]["comentarios"].ToString();
            fila["FechaRango"] = historial.Rows[i]["fechaRango"].ToString();
            fila["nomUsuario"] = historial.Rows[i]["nomUsuario"].ToString();
            data.Rows.Add(fila);
        } 
     **/
}