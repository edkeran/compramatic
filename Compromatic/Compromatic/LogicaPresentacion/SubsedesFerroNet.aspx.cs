using System;
using Utilitarios;
using Logica;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;

public partial class Presentacion_SubsedesFerroNet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //NO HAY QUE VALIDAR EL PAGE LOAD DEBIDO A QUE ESTA PAGINA ES COMPLETAMENTE PUBLICA
        swFerro.ServiciosSoapClient obwsClientesSoap = new swFerro.ServiciosSoapClient();
        //obwsClientesSoap.ClientCredentials.UserName = "compramatic";
        swFerro.SeguridadToken objclsSeguridad = new swFerro.SeguridadToken
        {
            username = "compramatic",
            contrasena = "Z|FrI8QBdY"
        };

        string token = obwsClientesSoap.autenticacionUsuario(objclsSeguridad);
        L_SubsedesFerro logi = new L_SubsedesFerro();
        try
        {
            logi.verficarService(token);
        }catch(Exception ex)
        {
            throw ex;
        }
        objclsSeguridad.AutenticacionToken = token;
        //DATOS SETEADOS
        List<Ubicaciones> data = JsonConvert.DeserializeObject<List<Ubicaciones>>(obwsClientesSoap.ConsultaDeUbicaciones(objclsSeguridad));
        GV_test.DataSource = data;
        GV_test.DataBind();

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 43;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.InnerHtml = compIdioma["title"].ToString();
        }
        catch (Exception ex)
        { }
    }
}