using System;
using System.Data;
using Utilitarios;
//using Datos;
using DatosPersistencia;


namespace Logica
{
    public class L_MasterBoardUsr
    {
        public U_aux_master_Usr page_load(Object Session)
        {
            U_aux_master_Usr response = new U_aux_master_Usr();
            if (Session == null)
            {
                //Response.Redirect("LoginUsr.aspx");
                UEUsuario user = new UEUsuario();
                user.RutaArch = "";
                user.NomArch = "";
                user.NomUsr = "";
                user.ApelUsr = "";
                response.User = user;
                response.Response = "LoginUsr.aspx";
                return response;
            }
            else
            {
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
                {
                    //Redireccionar
                    //Response.Redirect("LoginUsr.aspx");
                    UEUsuario user = new UEUsuario();
                    user.RutaArch = "";
                    user.NomArch = "";
                    user.NomUsr = "";
                    user.ApelUsr = "";
                    response.User = user;
                    response.Response = "LoginUsr.aspx";
                    return response;
                }
                else
                {
                    UEUsuario user = new UEUsuario();
                    user.RutaArch = datos.Rows[0]["rutaArchivo"].ToString();
                    user.NomArch = datos.Rows[0]["nomArchivo"].ToString();
                    user.NomUsr = datos.Rows[0]["nomUsuario"].ToString();
                    user.ApelUsr = datos.Rows[0]["apeUsuario"].ToString();
                    response.User = user;
                    response.Response = "0";
                    return response;
                }
            }
        }

        public void btnSi_Click(UEUsuario user, int value, String nom_usuario)
        {
            DBUsr daoUsuario = new DBUsr();
            //DDAOUsuario db = new DDAOUsuario();
            //db.BloqueoUser(user, value, nom_usuario);
            daoUsuario.bloquear_cuenta(user, value, nom_usuario);
        }

        public void btn_enviar(UEUPqr pqr,String nom_usr)
        {
            DB_ReasosnsPQR daoQueja = new DB_ReasosnsPQR();
            //DDAOPqr queja = new DDAOPqr();
            daoQueja.quejaUsr(pqr,nom_usr);
        }

        public void cerrar_session_usuario(DataTable sesion)
        {
            DBUsr daoUsuario = new DBUsr();
            //DDAOUsuario DB = new DDAOUsuario();
            UEUsuario data = new UEUsuario();
            int ID = int.Parse(sesion.Rows[0]["idUsuario"].ToString());
            data.IdUsr = ID;
            int Session = daoUsuario.obtener_sessiones_abiertas(data.IdUsr);
            Session = Session - 1;
            data.Sessiones = Session;
            daoUsuario.update_session(data);
        }
    }
}
