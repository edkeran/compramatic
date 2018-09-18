using System;
using System.Collections;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Home logi = new L_Home();
        Session["idiomases"] = int.Parse(logi.validar_ses_idioma(Session["idiomases"]).ToString());
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 24;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.BTN_Idioma.Text= compIdioma["BTN_Idioma"].ToString();
            //this.respo.InnerText = compIdioma["respo"].ToString();
        }
        catch (Exception ex)
        { }
    }

    protected void DDL_Idioma_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList ddl = (DropDownList)sender;
        //Session["idiomases"] = int.Parse(ddl.SelectedValue);
    }

    protected void BTN_Idioma_Click(object sender, EventArgs e)
    {
        DropDownList ddl = DDL_Idioma;
        Session["idiomases"] = int.Parse(ddl.SelectedValue);
        Response.Redirect("Home.aspx");
    }
}