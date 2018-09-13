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

    protected Utilitarios.DataSet Calificaciones()
    {
        Utilitarios.DataSet compras = new Utilitarios.DataSet();
        DataTable data = new DataTable();
        data = compras.Calificaciones;
        L_HistoricoCalificaciones logi = new L_HistoricoCalificaciones();
        logi.Calificaciones(Session["idEmpresa"],data);
        return compras;
    }
}