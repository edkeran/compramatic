using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Presentacion_HistoricoCalificaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
    }

    protected DataSet Calificaciones()
    {
        DataSet compras = new DataSet();
        DAOEmpresa DAO_Empresa = new DAOEmpresa();
        DataTable historial = DAO_Empresa.MostrarCalificaciones(int.Parse(Session["idEmpresa"].ToString()));
        DataTable data = new DataTable();
        data = compras.Calificaciones;
        DataRow fila;

        for (int i = 0; i < historial.Rows.Count; i++)
        {
            fila = data.NewRow();

            fila["Rango"] = historial.Rows[i]["rango"].ToString();
            fila["Comentario"] = historial.Rows[i]["comentarios"].ToString();
            fila["FechaRango"] = historial.Rows[i]["fechaRango"].ToString();
            fila["nomUsuario"] = historial.Rows[i]["nomUsuario"].ToString();
            data.Rows.Add(fila);
        }
        return compras;
    }
}