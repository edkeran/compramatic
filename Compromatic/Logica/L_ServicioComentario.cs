using System;
using System.Collections.Generic;
using DatosPersistencia;
using Newtonsoft.Json;
using Utilitarios;

namespace Logica
{
    public class L_ServicioComentario
    {
        //INSERTAR COMENTARIO
        public void insertar_Comentario(string info,int id_empresa,string nomUser, string correoUser)
        {
            UEUComentEmpres coment = new UEUComentEmpres();
            coment.IdEmpres = id_empresa;
            coment.Comentario = info;
            coment.CorreoUser = correoUser;
            coment.NomUser = nomUser;
            DBEmpresa daoEmpresa = new DBEmpresa();
            daoEmpresa.CrearComentario(coment);
        }

        public String load_companies()
        {
            try
            {
                DBEmpresa daoEmpresa = new DBEmpresa();
                return JsonConvert.SerializeObject(daoEmpresa.get_active_comp());
            }catch(Exception ex){
                return "Ha Ocurrido Un Error Inesperado" + ex.Message;
            }
        }
    }
}
