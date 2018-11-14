using System;
using System.Web;
using System.Web.Services;
using Logica;
using Seguridad;

/// <summary>
/// Descripción breve de LogginUsr
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class LogginUsr : System.Web.Services.WebService
{
    public clsSeguridad SoapHeader;
    public LogginUsr()
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Test Publico";
    }


    //METODO PARA EL SERVICIO QUE DEBE DE VALIDAR QUE EL CLIENTE ESTE AUTENTICADO
    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string loggin_User(string correoUsr, string password)
    {
        try
        {
            if (SoapHeader == null)
            {
                throw new Exception("Requiere Validacion");
            }

            if (!SoapHeader.blCredencialesValidas(SoapHeader))
            {
                throw new Exception("Requiere Validacion");
            }
            L_Loggin_Usr_Service logi = new L_Loggin_Usr_Service();
            return logi.loggin_user(password, correoUsr);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //Metodo para autenticar a la Empresa Que solicita el Servicio
    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string AutenticacionUsuario()
    {
        try
        {
            if (SoapHeader == null)
            {
                return "-1";
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader.stToken, SoapHeader.nomEmp))
            {
                return "-1";
            }
            string stToken = Guid.NewGuid().ToString();
            //DATOS DE LA AUUTENTICACION GUARDADAS EN CACHE CAMBIAR POR DB
            HttpRuntime.Cache.Add(stToken,
                SoapHeader.stToken,
                null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                TimeSpan.FromMinutes(30),
                System.Web.Caching.CacheItemPriority.NotRemovable,
                null);

            return stToken;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
