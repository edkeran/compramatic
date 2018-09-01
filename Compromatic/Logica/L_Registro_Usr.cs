using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_Registro_Usr
    {
        public String validaciones_Register(String Email,String pass1,String pass2, bool check,UEUsuario user)
        {
            DDAOUsuario db = new DDAOUsuario();
            if (db.ComprobarCorreo(Email)== 1){
                return "El correo ya existe.";
            }else if(!(pass1 == pass2))
            {
                return "Las contraseñas no coinciden.";
            }else if (check == false)
            {
                return "No has confirmado tu registro.";
            }else if (pass1.Length < 8)
            {
                return "Contraseña muy corta.";
            }
            else
            {
                //PASO TODAS LAS VALIDACIONES Y POR LO TANTO DEBO RECIBIR TAMBIEN UN OBJETO
                DDAOUsuario accion = new DDAOUsuario();
                accion.RegistrarUsuario(user, "");
                return "Tu registro se ha sido realizado satisfactoriamente.";
            }
        }

    }
}
