using System;
using System.Data;
using DatosPersistencia;

namespace Logica
{
    public class L_SolicitudesPendientes
    {
        public String page_load(Object Session,Object sesion)
        {
            if (Session == null)
            {
                return("LoginUsr.aspx");
            }
            else
            {

                int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                { }
                else
                {
                    return("LoginUsr.aspx");
                }
            }
            return "0";
        }

        public DataTable GV_1(int id)
        {
            DB_Admin daoAdmin = new DB_Admin();
            //DDAOadministrador conexion = new DDAOadministrador();
            DataTable consulta = daoAdmin.ArchivosEmpresa(id);
            return consulta;
        }

       public void GV1_RowCommand(String CommandName,int id,String CommandArgument,Object sesion)
        {
            if (CommandName == "aceptar")
            {
                int index = Convert.ToInt32(CommandArgument);
                DB_Admin conexion = new DB_Admin();
                //DDAOadministrador conexion = new DDAOadministrador();
                conexion.ModificarEstados(id, 1, 0, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //Response.Redirect("SolicitudesPendientes.aspx");
                //GridView1.DataBind();
            }
            if (CommandName == "rechazar")
            {
                int index = Convert.ToInt32(CommandArgument);
                DB_Admin conexion = new DB_Admin();
                //DDAOadministrador conexion = new DDAOadministrador();
                conexion.ModificarEstados(id, 0, 3, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //GridView1.DataBind();
                //Response.Redirect("SolicitudesPendientes.aspx");
            }
        }
    }
}
