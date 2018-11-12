using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosPersistencia;
using Utilitarios;
using Newtonsoft.Json;

namespace Logica
{
    public class L_Loggin_Usr_Service
    {
        public string loggin_user(string pass, string correo)
        {
            UEUsuario user = new UEUsuario();
            user.PassUsr = pass;
            user.CorreoUsr = correo;
            DBUsr daoUser = new DBUsr();
            DataTable res=daoUser.loggin_user(user);
            string data="";
            if (res.Rows.Count > 0)
            {
                data = JsonConvert.SerializeObject(res);
            }
            else
            {
                data = "Usuario O Contraseña Invalidos";
            }
            return data;
        }
    }
}
