using System.Collections.Generic;
using System.Web.Services;
using Logica;
using Newtonsoft.Json;
using Utilitarios;
using Seguridad;
using System;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public clsSeguridad SoapHeader;
    public WebService()
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
    public string traer_por_categoria(int id_categoria)
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
                L_WebService logi = new L_WebService();
                List<UEUVista_Tot_Prod> inf = logi.busqueda(id_categoria);
                foreach(UEUVista_Tot_Prod aux in inf)
                {
                    aux._foto = "compramatic.hopto.org:88/Archivos/FotosProductos/" + aux._foto;
                }
                ListToDataTable conv = new ListToDataTable();
                DataTable retorn = conv.ToDataTable(inf);
                string res = JsonConvert.SerializeObject(retorn);
                DataTable test = JsonConvert.DeserializeObject<DataTable>(res);
                return res;
            }
            catch (Exception ex)
            {

                return "Ha Ocurrido Un Error Inesperado " + ex.Message;
            }
           
        }
        catch (Exception ex)
        {

            throw ex;
        }
          
    }
    
    //METODO PARA OBTENER TODAS LAS CATEGORIAS DEL PROYECTO
    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string traer_categorias_productos()
    {
        try
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
                L_WebService logi = new L_WebService();
                string res = JsonConvert.SerializeObject(logi.get_all_Cate());
                return res;
            }
            catch (Exception ex)
            {

                return "Ha Ocurrido Un Error Inesperado " + ex.Message;
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
