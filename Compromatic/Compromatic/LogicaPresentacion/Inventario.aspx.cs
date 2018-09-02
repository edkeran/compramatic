using System;
using System.Data;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_Inventario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Invertario logic = new L_Invertario();
        String redir=logic.page_load(IsPostBack,Session["Sesion"]);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "sctr", "redireccionar('" + redir + "');", true);
    }

    /**
     * 
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
        }

     **/

    protected void Productos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        L_Invertario logic = new L_Invertario();
        String redir=logic.Productos_ItemCommand(e.CommandName, ((TextBox)e.Item.FindControl("TB_Cantidad")).Text, e.CommandArgument.ToString(), ((TextBox)e.Item.FindControl("TB_Alerta")).Text,Empresa, Request.Url.AbsoluteUri);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + redir + "');", true);
    }

    /**
     * if(e.CommandName=="Modificar")
        {
            int cantidad = int.Parse(((TextBox)e.Item.FindControl("TB_Cantidad")).Text);
            int id = int.Parse(e.CommandArgument.ToString());
            int bajoInventario = int.Parse(((TextBox)e.Item.FindControl("TB_Alerta")).Text);
            IADProducto IAD_Producto = new IADProducto();
            IAD_Producto.ModificarInventario(id,cantidad,bajoInventario,Empresa.Rows[0]["nomEmpresa"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
     **/
}