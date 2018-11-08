using System;
using System.Collections;
using Logica;
using Utilitarios;

public partial class Presentacion_forgotPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Seteando Idiomas
        Response.Cache.SetNoStore();
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 20;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.lb_h2.InnerText= compIdioma["lb_h2"].ToString();
            this.email.InnerText= compIdioma["email"].ToString();
            this.Button1.Text= compIdioma["Button1"].ToString();
            this.HL_Index.Text= compIdioma["HL_Index"].ToString();
            //this.title.Text = compIdioma["title"].ToString();
        }
        catch (Exception ex)
        { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
            L_ForgotPass logi = new L_ForgotPass();
            String res=logi.pass(TB_Correo.Text);
            LB_1.Text = res;
    }
}