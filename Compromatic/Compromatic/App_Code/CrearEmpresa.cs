using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Utilitarios;

/// <summary>
/// Descripción breve de CrearEmpresa
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class CrearEmpresa : System.Web.Services.WebService
{

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
    //DEBO REUNIRME CON UNIEMPLEO PARA REALIZAR ESTO CORRECTAMENTE PUES TODOS LOS PROYECTOS DEBEN TENER ESTA MISMA CLASE
    public void create_company(string JSON_DATA)
    {
        UEUEmpresa empre = JsonConvert.DeserializeObject<UEUEmpresa>(JSON_DATA);

    }

}
