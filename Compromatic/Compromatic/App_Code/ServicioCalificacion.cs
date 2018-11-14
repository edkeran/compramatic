using System;
using System.Web;
using System.Web.Services;
using Seguridad;
using Newtonsoft.Json;
using Logica;
using System.Data;
using Utilitarios;

/// <summary>
/// Descripción breve de ServicioCalificacion
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioCalificacion : System.Web.Services.WebService
{
    public clsSeguridad SoapHeader;

    public ServicioCalificacion()
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
    //METODO PARA CALIFICAR A LA EMPRESA
    public string calificarEmpresa(string corre_Usr,int id_Empresa,string nomUser, string apell_usr, string direccion,string telefono,string cedula,double rang)
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
            L_ServicioCalificacion logi = new L_ServicioCalificacion();
            if (logi.validar_existencia(corre_Usr))
            {
                //Insertar Calificacion 
                logi.calificar_empresa(id_Empresa, nomUser, corre_Usr, rang);
                return "Calificacion Exitosa";
            }
            else
            {
                //Insertar Usuario A La DB como Nuevo Usuario
                //Por Defecto La Contraseña Sera 12345678
                UEUsuario user = new UEUsuario();
                user.NomUsr = nomUser;
                user.ApelUsr = apell_usr;
                user.TelUsr = telefono;
                user.CorreoUsr = corre_Usr;
                user.PassUsr = "12345678";
                user.CcUsr = cedula;
                user.DirUsr = direccion;
                String res = logi.insertar_Usuario(user);
                if (res != "Tu registro se ha sido realizado satisfactoriamente.")
                {
                    //CASO EN QUE EL USUAREIO NO EXISTE
                    return "Ha Ocurrido Un Error Inesperado. " + res;
                }
                else
                {
                    logi.calificar_empresa(id_Empresa, nomUser, corre_Usr, rang);
                    return res + "Calificacion Exitosa . Debido a que este Usuario No Existe En La DB de Compramatic Su Contraseña Temporal Es 12345678";
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
       
    }

    [WebMethod]
    //METODO PARA TRAER LAS EMPRESAS ACTIVAS POR MEDIO DE UN JSON 
    public string traerEmpresasActivas()
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
            DataTable data = logi.SolicitudesAceptadas();
            string retorno = JsonConvert.SerializeObject(data);
            return retorno;
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
