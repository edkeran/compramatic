using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_PrincipalAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

        if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            if (int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString()) == 1)
            {
                
                int num = int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString());
                DAOadministrador user = new DAOadministrador();
                DataTable totalcliente = user.MostrarTotalClientes();
                DataTable TotalEmpresa = user.MostrarTotalEmpresas();
                DataTable totalVentas = user.MostrarTotalVentas();
                DataTable not = user.LlenarNotificacion();
                DataTable notAcep = user.LlenarNotificacionAceptadas();
                DataTable notRecha = user.LlenarNotificacionRechazada();
                L_Usuarios.Text = totalcliente.Rows[0]["count"].ToString();
                L_Empresas.Text = TotalEmpresa.Rows[0]["count"].ToString();
                L_totalVentas.Text = totalVentas.Rows[0]["valor"].ToString();
                L_Pqr.Text = ((int.Parse(notAcep.Rows[0]["Activas"].ToString())) + (int.Parse(notRecha.Rows[0]["Activas"].ToString())) + (int.Parse(not.Rows[0]["Activas"].ToString()))).ToString();
            }

            else
            {
                Response.Redirect("LoginUsr.aspx");
            }
        }
    }
}