using System.Collections.Generic;
using System.Web.Services;
using Logica;
using Newtonsoft.Json;
using Utilitarios;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

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
    public string traer_por_categoria(string token,int id_categoria)
    {
        if (validar_token_recibido(token))
        {
            L_WebService logi = new L_WebService();
            List<UEUVista_Tot_Prod> inf = logi.busqueda(id_categoria);
            string res = JsonConvert.SerializeObject(inf);
            return res;
        }
        else
        {
            return "ACCESO DENEGADO";
        }
        
    }

    private bool validar_token_recibido(string token)
    {
        if (token == "TOKEN_TEST")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //METODO PARA DAR TIEMPO DE VIDA AL TOKEN Y ACTUALIZARLO EN AMBOS PROYECTOS
    private void setear_token()
    {

    }

    
    //METODO PARA OBTENER TODAS LAS CATEGORIAS DEL PROYECTO
    [WebMethod]
    public string traer_categorias_productos()
    {
        L_WebService logi = new L_WebService();
        string res = JsonConvert.SerializeObject(logi.get_all_Cate());
        return res;
    }

}
