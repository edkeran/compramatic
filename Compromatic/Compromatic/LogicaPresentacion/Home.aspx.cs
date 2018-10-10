using System;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Home logi = new L_Home();
        Session["idiomases"] = int.Parse(logi.validar_ses_idioma(Session["idiomases"]).ToString());
        Session["global"] = logi.validar_region(Session["global"]).ToString();
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 24;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["global"].ToString());
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["global"].ToString());
        try
        {
            this.BTN_Idioma.Text= compIdioma["BTN_Idioma"].ToString();
            this.LB_head.Text= compIdioma["LB_head"].ToString();
            this.BTN_Acep.Text= compIdioma["BTN_Acep"].ToString();
            this.BTN_Can.Text= compIdioma["BTN_Can"].ToString();
        }
        catch (Exception ex)
        { }
    }

    protected void DDL_Idioma_SelectedIndexChanged(object sender, EventArgs e)
    {}

    protected void BTN_Idioma_Click(object sender, EventArgs e)
    {
        DropDownList ddl = DDL_Idioma;
        Session["idiomases"] = int.Parse(ddl.SelectedValue);
        Session["global"] = DDL_Idioma.SelectedItem;
        Response.Redirect("Home.aspx");
    }

    
    protected void BTN_LogOut_Click(object sender, EventArgs e)
    {
        L_Master_Home logica = new L_Master_Home();
        logica.log_out(Session["sesion"], Session["Sesion"]);
        Session["Sesion"] = null;
        Response.Redirect("Home.aspx");
    }

}