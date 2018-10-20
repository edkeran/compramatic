using System;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_Registro_Usr
    {
        public String validaciones_Register(String Email,String pass1,String pass2, bool check,UEUsuario user)
        {
            DBUsr daoUsuario = new DBUsr();
            //DDAOUsuario db = new DDAOUsuario();
            if (daoUsuario.comprobar_correo(Email)== 1){
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
                //DDAOUsuario accion = new DDAOUsuario();
                DBUsr daBase = new DBUsr();
                user.IdTipo = 3;
                user.RutaArch = "../Archivos/FotosPerfil/";
                user.NomArch = "PerfilUsrDefault.png";
                user.ModifBy = "";
                user.Sessiones = 0;
                user.EstUsr = 1;
                user.Calificacion2=5;
                //accion.RegistrarUsuario(user, "");
                daBase.insertarUsuarioPersistencia(user);
                return "Tu registro se ha sido realizado satisfactoriamente.";
            }
        }

    }
}
