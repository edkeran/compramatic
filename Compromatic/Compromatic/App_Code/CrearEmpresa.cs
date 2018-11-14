using System;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Logica;
using Utilitarios;
using System.Data;
using Seguridad;

/// <summary>
/// Descripción breve de CrearEmpresa
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class CrearEmpresa : System.Web.Services.WebService
{
    public clsSeguridad SoapHeader;

    public CrearEmpresa()
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
    //DEBO REUNIRME CON UNIEMPLEO PARA REALIZAR ESTO CORRECTAMENTE PUES TODOS LOS PROYECTOS DEBEN TENER ESTA MISMA CLASE
    //POR DEFECTO LA EMPRESA TENDRA LA IMAGEN DEL USUARIO DESONOCIDO
    public string create_company(string JSON_DATA)
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
            UEUEmpresa empre = JsonConvert.DeserializeObject<UEUEmpresa>(JSON_DATA);
            //SE CARGA LA IMAGEN POR DEFECTO 
            empre.RutaArchivo = "../Archivos/FotosPerfil/";
            empre.NomArchivo = "PerfilUsrDefault.png";
            L_Registro_Empesa_Serv Logi = new L_Registro_Empesa_Serv();
            string res = Logi.registrar_Empresa(empre);
            return res;
        }
        catch (Exception ex)
        {
            return "Ha Ocurrido Un Error Inesperado "+ex.Message;
        }
        
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    //METODO PARA TRAER LAS MEMBRESIAS
    public string get_memberships()
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
            L_Componentes logi = new L_Componentes();
            DataTable Membresias = logi.Membresia();
            string data = JsonConvert.SerializeObject(Membresias);
            return data;
        }
        catch (Exception ex)
        {
            return "Ha Ocurrido Un Error Inesperado "+ex.Message;
        }
        
    }

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
