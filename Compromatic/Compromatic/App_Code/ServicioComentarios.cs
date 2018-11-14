using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica;
using Seguridad;

/// <summary>
/// Descripción breve de ServicioComentarios
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioComentarios : System.Web.Services.WebService
{
    public clsSeguridad SoapHeader;

    public ServicioComentarios()
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
    public string InsertarDudasEmpresa(String mensaje,int idEmpre,string nomUser, string correoUser)
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
            L_ServicioComentario logi = new L_ServicioComentario();
            try
            {
                logi.insertar_Comentario(mensaje, idEmpre, nomUser, correoUser);
                return "Comentario Enviado Correctamente";
            }
            catch (Exception ex)
            {
                //ENVIAR MENSAJE DE ERROR
                return "Ha Ocurrido Un Error Inesperado " + ex.Message;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string cargar_empresas()
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
            L_ServicioComentario logi = new L_ServicioComentario();
            return logi.load_companies();
        }
        catch(Exception ex)
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
