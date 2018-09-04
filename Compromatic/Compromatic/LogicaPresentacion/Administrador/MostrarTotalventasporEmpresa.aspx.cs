using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_MostrarTotalventasporEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MostrTablaEmp log = new L_MostrTablaEmp();
        U_AuxQuejAdm res = log.pageLoad(Session["Sesion"], Session["sesion"], GridView1.Rows.Count);
        GridView1.UseAccessibleHeader = true;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);

    }
    /**
     *if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            if (int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString()) == 1)
            {
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                int num = int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString());

            }

            else
            {
                Response.Redirect("LoginUsr.aspx");
            }
        } 
     **/
}