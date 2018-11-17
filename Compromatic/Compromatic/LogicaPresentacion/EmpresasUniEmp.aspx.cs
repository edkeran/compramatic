using System;
using System.Collections.Generic;
using Logica;
using Utilitarios;
using Newtonsoft.Json;
using System.Collections;

public partial class Presentacion_EmpresasUniEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //NO HAY QUE VALIDAR LO DEL POSTBACK Y LA PAGINA DEBIDO A QUE ES PARA TODOS
       
        try
        {
            swUniEmp.ServidorUniempleoSoapClient servicio = new swUniEmp.ServidorUniempleoSoapClient();
            servicio.ClientCredentials.UserName.UserName = "compramatic";
            servicio.ClientCredentials.UserName.Password = "d44REXbHVR";
            swUniEmp.SeguridadToken objSegu = new swUniEmp.SeguridadToken
            {
                username = "compramatic",
                Pass = "d44REXbHVR"
            };
            String token = servicio.AutenticacionUsuario(objSegu);
            //Validacion En Logica
            try
            {
                L_EmpresUniEmp logi = new L_EmpresUniEmp();
                logi.validar_token(token);
            }catch(Exception ex)
            {
                throw ex;
            }
            objSegu.Token_Autenticacion=token;
            List<JoinEmpresasR> list = JsonConvert.DeserializeObject<List<JoinEmpresasR>>(servicio.Empresas_Registradas(objSegu));
            GV_Empre.DataSource = list;
            GV_Empre.DataBind();

            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 42;
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
        catch(Exception ex)
        {
            throw ex;
        }
    }
}