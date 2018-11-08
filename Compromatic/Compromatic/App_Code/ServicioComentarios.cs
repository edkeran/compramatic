using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica;

/// <summary>
/// Descripción breve de ServicioComentarios
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioComentarios : System.Web.Services.WebService
{

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
    public string InsertarDudasEmpresa(String mensaje,int idEmpre,string nomUser, string correoUser)
    {
        L_ServicioComentario logi = new L_ServicioComentario();
        try
        {
            logi.insertar_Comentario(mensaje, idEmpre,nomUser,correoUser);
            return "Comentario Enviado Correctamente";
        }catch(Exception ex)
        {
            //ENVIAR MENSAJE DE ERROR
            return "Ha Ocurrido Un Error Inesperado " + ex.Message;
        }

    }

    [WebMethod]
    public string cargar_empresas()
    {
        L_ServicioComentario logi = new L_ServicioComentario();
        return logi.load_companies();
    }

    private bool ValidarToken(String token)
    {
        if (token == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
