using System;
using System.Data;
using Utilitarios;
using Datos;


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
            DDAOUsuario db = new DDAOUsuario();
            db.BloqueoUser(user, value, nom_usuario);
        }

        public void btn_enviar(UEUPqr pqr,String nom_usr)
        {
            DDAOPqr queja = new DDAOPqr();
            queja.QuejaUsr(pqr,nom_usr);
        }
    }
}
