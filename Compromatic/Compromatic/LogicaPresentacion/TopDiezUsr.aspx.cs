using System;
using System.Data;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_TopDiezUsr : System.Web.UI.Page
{
    //FALTA EVITAR PARA RECARGAR EL DATABIND CON EL TRY CATCH
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_TopDiezUsr logica = new L_TopDiezUsr();
            DataTable topTen = logica.page_load(IsPostBack, Session["Sesion"], (DataTable)RP_TopTen.DataSource);
            RP_TopTen.DataSource = topTen;
            RP_TopTen.DataBind();
            String redir = logica.redireccion(topTen);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + redir + "');", true);
        }catch(Exception ex)
        {
            //No Hago Nada
        }
    }

    /**
     * CODIGO ORIGINAL PAGE LOAD
     * 
     *  if (!IsPostBack)
        {
            if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUSr.aspx");
            }
            DataTable datos = (DataTable)Session["Sesion"];
            if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
            {
                Response.Redirect("LoginUsr.aspx");
            }
            DataTable user = (DataTable)Session["Sesion"];
            DAOUsuario dao= new DAOUsuario ();
            DataTable topten = dao.ObtenerTopTen(int.Parse(user.Rows[0]["idUsuario"].ToString()));
            RP_TopTen .DataSource = topten;
            RP_TopTen .DataBind();
        }
     **/
    protected void RP_TopTen_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        L_TopDiezUsr logica = new L_TopDiezUsr();
        Session["VerProducto"]=logica.RP_TopTen_ItemCommand(e.CommandName, e.CommandArgument.ToString());
        Response.Redirect("VerProducto.aspx");
    }

    /**
     * if (e.CommandName.Equals("Ver"))
        {
            DAOProducto pdto = new DAOProducto();
            Session["VerProducto"] = pdto.ProductosDetalle(int.Parse(e.CommandArgument.ToString()));
            Response.Redirect("VerProducto.aspx");
        }
     **/
}