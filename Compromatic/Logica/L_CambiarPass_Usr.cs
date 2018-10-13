using System;
using System.Data;
using DatosPersistencia;
using Utilitarios;

namespace Logica
{
    public class L_CambiarPass_Usr
    {
        public string page_load(Object Session)
        {
            if (Session == null)
            {
                //Response.Redirect("LoginUsr.aspx");
                return "LoginUsr.aspx";
            }
            else
            {
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
                {
                    //Response.Redirect("LoginUsr.aspx");
                    return "LoginUsr.aspx";
                }
                else
                {
                    //No Redirecciono
                    return "0";
                }
            }
        }
        //Metodo Para El Cambio De Contraseña
        public String cambiar_contrasena(DataTable datos,String pass1,String pass2,String pass3)
        {
            if (pass1 != datos.Rows[0]["passUsuario"].ToString())
            {
                //Modal("Contraseña erronea.");
                return "Contraseña erronea./0";
            }
            else if(pass2!=pass3)
            {
                return "La confirmación de contraseña no es correcta, recuerda que la contraseña nueva debe ser escrita dos veces para aprobar el cambio de contraseña./0";
            }
            else if (pass2.Length < 8)
            {
                //Modal("Contraseña nueva corta.");
                return "Contraseña nueva corta./0";
            }
            else if (pass1 == pass2 || pass1== pass3)
            {
                //Modal("Contraseña nueva es igual a la anterior.");
                return "Contraseña nueva es igual a la anterior./0";
            }
            else
            {
                DBUsr daoUser = new DBUsr();
                
                //DDAOUsuario cambiar = new DDAOUsuario();
                UEUsuario user = new UEUsuario();
                user.PassUsr = pass2;
                user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                daoUser.CambiarPass(user, datos.Rows[0]["nomUsuario"].ToString());
                return "Contraseña cambiada con éxito./LoginUsr.aspx";
            }
        }
    }
}
