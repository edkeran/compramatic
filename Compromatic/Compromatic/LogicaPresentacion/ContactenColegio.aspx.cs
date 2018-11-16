using System;
using Logica;

public partial class Presentacion_ContactenColegio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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