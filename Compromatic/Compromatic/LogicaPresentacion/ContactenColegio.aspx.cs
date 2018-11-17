using System;
using System.Collections;
using Logica;

public partial class Presentacion_ContactenColegio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 45;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.InnerHtml = compIdioma["title"].ToString();
            this.name.InnerHtml = compIdioma["name"].ToString();
            this.lastName.InnerHtml = compIdioma["lastName"].ToString();
            this.email.InnerHtml= compIdioma["email"].ToString();
            this.phone.InnerHtml= compIdioma["phone"].ToString();
            this.msg.InnerHtml= compIdioma["msg"].ToString();
            this.Button1.Text= compIdioma["Button1"].ToString();
        }
        catch (Exception ex)
        { }
    }

    protected void BTN_Send(object sender, EventArgs e)
    {
        try
        {
            //LLAMAMOS AL SERVICE DEL COLEGIO
            swColegio.WSContactenosSoapClient obwsClienteSoap = new swColegio.WSContactenosSoapClient();
            //SETEAMOS LAS CREDENCIALES
            swColegio.clsSeguridadContactenos obclsSeguridad = new swColegio.clsSeguridadContactenos()
            {
                stToken = "contactenos"
            };

            string stToken = obwsClienteSoap.AutenticacionUsuario(obclsSeguridad);
            try
            {
                L_ContacCole logi = new L_ContacCole();
                logi.validarToken(stToken);
            }catch(Exception ex)
            {
                throw ex;
            }
            obclsSeguridad.AutenticacionToken = stToken;
            obwsClienteSoap.contactenos(obclsSeguridad,TB_Nom.Text,TB_Apell.Text, TB_Corr.Text, TB_Telefono.Text, TB_MSG.Text);
            Response.Redirect("ContactenColegio.aspx");
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}