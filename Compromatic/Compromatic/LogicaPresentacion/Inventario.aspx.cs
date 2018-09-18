using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_Inventario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Invertario logic = new L_Invertario();
        String redir = logic.page_load(IsPostBack, Session["Sesion"]);
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 14;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.inv.InnerText= compIdioma["inv"].ToString();
            this.Produc.InnerText= compIdioma["Produc"].ToString(); 
            this.nom.InnerText= compIdioma["nom"].ToString();
            this.desc.InnerText= compIdioma["desc"].ToString();
            this.cant.InnerText= compIdioma["cant"].ToString();
            this.min_cant.InnerText= compIdioma["min_cant"].ToString();
            this.categ.InnerText= compIdioma["categ"].ToString();
            this.modi.InnerText= compIdioma["modi"].ToString();
            //this.man_usr.InnerText = compIdioma["man_usr"].ToString();
        }
        catch (Exception ex)
        { }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "sctr", "redireccionar('" + redir + "');", true);
    }

    protected void Productos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        L_Invertario logic = new L_Invertario();
        String redir=logic.Productos_ItemCommand(e.CommandName, ((TextBox)e.Item.FindControl("TB_Cantidad")).Text, e.CommandArgument.ToString(), ((TextBox)e.Item.FindControl("TB_Alerta")).Text,Empresa, Request.Url.AbsoluteUri);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + redir + "');", true);
    }
}