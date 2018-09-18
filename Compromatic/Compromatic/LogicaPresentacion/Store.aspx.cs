using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using System.Collections;

public partial class Presentacion_Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Store logica = new L_Store();
        DataTable res =logica.L_Page_Load(IsPostBack, Session["Tienda"], null);
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 9;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.prod.InnerText= compIdioma["prod"].ToString();
            DataColumn colm = new DataColumn();
            colm.DefaultValue= compIdioma["btn_comp"].ToString();
            colm.DataType = typeof(String);
            colm.ColumnName = "btn_comp";
            res.Columns.Add(colm);
        }
        catch (Exception ex)
        { }
        RP_Productos.DataSource = res;
        RP_Productos.DataBind();
    }

    protected void RP_Productos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {}

    protected void load_product(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        L_Store logica = new L_Store();
        Session["VerProducto"] = logica.LoadProduct(int.Parse(btn.CommandArgument.ToString()));
        Response.Redirect("VerProducto.aspx");
    }
}