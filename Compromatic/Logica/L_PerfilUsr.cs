using System;
using System.Data;
using Utilitarios;

namespace Logica
{
    public class L_PerfilUsr
    {
        public UEUsuario cargar_datos(Object Session)
        {
            UEUsuario user = new UEUsuario();
            
            if (Session == null)
            {
                user.Redireccion = "LoginUsr.aspx";
                return user;
            }
            else
            {
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
                {
                    user.Redireccion = "LoginUsr.aspx";
                    return user;
                }
                else
                {
                    //No DEBO REDIRECCIONAR
                    user.Redireccion = "0";
                    user.NomUsr = datos.Rows[0]["nomUsuario"].ToString();
                    user.ApelUsr = datos.Rows[0]["apeUsuario"].ToString();
                    user.CcUsr = datos.Rows[0]["ccUsuario"].ToString();
                    user.TelUsr = datos.Rows[0]["telUsuario"].ToString();
                    user.DirUsr = datos.Rows[0]["dirUsuario"].ToString();
                    user.CorreoUsr= datos.Rows[0]["correoUsuario"].ToString();
                    user.Calificacion= datos.Rows[0]["calificacionUsuario"].ToString();
                    user.RutaArch= datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
                    return user;
                }
            }
        }
    }
}
