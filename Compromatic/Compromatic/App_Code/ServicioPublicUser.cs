using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilitarios;
using Seguridad;
using Logica;

/// <summary>
/// Descripción breve de ServicioPublicUser
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioPublicUser : System.Web.Services.WebService
{
    public clsSeguridad SoapHeader;
    public ServicioPublicUser()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string publicar_Compramatic(string nomUser, string publicacion, string emailUser)
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
            try
            {
                UEUPublic_User publica = new UEUPublic_User();
                publica.NombreUs = nomUser;
                publica.Publicacion = publicacion;
                publica.Email_user = emailUser;
                //A Terminar este servicio :(
                L_Serv_Public_User logi = new L_Serv_Public_User();
                logi.crear_Publicacion(publica);
                return "Publicacion Correctamente Insertada";
            }
            catch (Exception ex)
            {

                return "Ha Ocurrido Un Error Inesperado "+ex.Message;
            }
           
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
            if (!SoapHeader.blCredencialesValidas(SoapHeader.stToken,SoapHeader.nomEmp))
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
