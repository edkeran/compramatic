using System;
using System.Collections;
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
            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 6;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            L_TopDiezUsr logica = new L_TopDiezUsr();
            DataTable topTen = logica.page_load(IsPostBack, Session["Sesion"], (DataTable)RP_TopTen.DataSource, compIdioma["BTN_VerProducto"].ToString());
            RP_TopTen.DataSource = topTen;
            RP_TopTen.DataBind();
            String redir = logica.redireccion(topTen);
            try
            {
                this.title_panel.InnerText = compIdioma["title_panel"].ToString();
                this.dat.InnerText = compIdioma["dat"].ToString();
                this.nom_pro.InnerText = compIdioma["nom_pro"].ToString();
                this.nom_emp.InnerText = compIdioma["nom_emp"].ToString();
                this.ver_prod.InnerText = compIdioma["ver_prod"].ToString();
                
            }
            catch (Exception ex)
            {

            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + redir + "');", true);
        }catch(Exception ex)
        {
            //No Hago Nada
        }
    }

    protected void RP_TopTen_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        L_TopDiezUsr logica = new L_TopDiezUsr();
        Session["VerProducto"]=logica.RP_TopTen_ItemCommand(e.CommandName, e.CommandArgument.ToString());
        Response.Redirect("VerProducto.aspx");
        
    }

}