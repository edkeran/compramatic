using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_QuejasAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_QuejasAdmin logi = new L_QuejasAdmin();
        U_AuxQuejAdm rep = logi.page_load(Session["Sesion"], GridView1.Rows.Count, TableRowSection.TableHeader,Session["sesion"]);
        GridView1.UseAccessibleHeader = rep.AcceHeader;
        GridView1.HeaderRow.TableSection = (TableRowSection)rep.Header1;
        int num = rep.Num;
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 29;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.quej.InnerText= compIdioma["quej"].ToString();
            this.comprom.InnerText= compIdioma["comprom"].ToString();
            this.adm_pqr.InnerText= compIdioma["adm_pqr"].ToString();
            this.emp_pqr.InnerText= compIdioma["emp_pqr"].ToString();
            this.clien_pqr.InnerText= compIdioma["clien_pqr"].ToString();

            //this.bloq_perfi.InnerText = compIdioma["bloq_perfi"].ToString();
        }
        catch (Exception ex)
        {

        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + rep.Redir + "');", true);
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 29;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            ((Label)e.Row.FindControl("LB_send_by")).Text= compIdioma["LB_send_by"].ToString(); ;
            ((Label)e.Row.FindControl("LB_date")).Text= compIdioma["LB_date"].ToString();
        }
        catch (Exception ex)
        {

        }
    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 29;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            ((Label)e.Row.FindControl("LB_send_by2")).Text = compIdioma["LB_send_by"].ToString(); ;
            ((Label)e.Row.FindControl("LB_date2")).Text = compIdioma["LB_date"].ToString();
        }
        catch (Exception ex)
        {

        }
    }

    protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 29;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            ((Label)e.Row.FindControl("LB_send_by3")).Text = compIdioma["LB_send_by"].ToString(); ;
            ((Label)e.Row.FindControl("LB_date3")).Text = compIdioma["LB_date"].ToString();
        }
        catch (Exception ex)
        {

        }
    }
}