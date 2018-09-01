using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class Presentacion_Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Store logica = new L_Store();
        DataTable res =logica.L_Page_Load(IsPostBack, Session["Tienda"], null);
        RP_Productos.DataSource = res;
        RP_Productos.DataBind();
    }

    protected void RP_Productos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {}

    protected void load_product(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DAOProducto pdto = new DAOProducto();
        Session["VerProducto"] = pdto.ProductosDetalle(int.Parse(btn.CommandArgument.ToString()));
        Response.Redirect("VerProducto.aspx");
    }
}