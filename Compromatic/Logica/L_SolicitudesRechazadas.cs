using System;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_SolicitudesRechazadas
    {
        public String page_load(Object Session,Object sesion)
        {
            if (Session == null)
            {
                return "LoginUsr.aspx";
            }
            else
            {

                int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                { }
                else
                {
                    return "LoginUsr.aspx";
                }
                return "0";
            }
        }

        public DataTable GV_1(int id)
        {
            DDAOadministrador conexion = new DDAOadministrador();
            DataTable consulta = conexion.ArchivosEmpresa(id);
            return consulta;
        }

        public U_Aux_SoliciRechaza L_Modal(int data,DataTable e)
        {
            String[] respo = new String[4];
            bool[] enables = new bool[3];
            U_Aux_SoliciRechaza info = new U_Aux_SoliciRechaza();
            if (data <= 2)
            {
                respo[0] = "No tiene documentos cargados";
                respo[1] = "";
                respo[2] = "";
                respo[3] = "";
                enables[0] = false;
                enables[1] = false;
                enables[2] = false;
            }
            else
            {
                respo[0] = "";
                respo[1] = e.Rows[0]["rutaArchivo"].ToString() + ".pdf";
                respo[2] = e.Rows[1]["rutaArchivo"].ToString() + ".pdf";
                respo[3] = e.Rows[2]["rutaArchivo"].ToString() + ".pdf";
                //HyperLink1.NavigateUrl = ;
                //HyperLink2.NavigateUrl = ;
                //HyperLink3.NavigateUrl = ;
                enables[0] = true;
                enables[1] = true;
                enables[2] = true;
            }
            info.Respo = respo;
            info.Enables = enables;
            return info;
        }
    }
}
