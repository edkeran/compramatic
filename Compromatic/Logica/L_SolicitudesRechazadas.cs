using System;
using System.Data;
using Datos;

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

        public void L_Modal(int data,String HL_1,String HL_2,String HL_3)
        {
            if (data <= 2)
            {
                //Titulo.Text = "No tiene documentos cargados";
                String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
                //HyperLink1.Enabled = false;
                //HyperLink2.Enabled = false;
                //HyperLink3.Enabled = false;

            }
            else
            {
                String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
                //HyperLink1.NavigateUrl = e.Rows[0]["rutaArchivo"].ToString() + ".pdf";
                //HyperLink2.NavigateUrl = e.Rows[1]["rutaArchivo"].ToString() + ".pdf";
                //HyperLink3.NavigateUrl = e.Rows[2]["rutaArchivo"].ToString() + ".pdf";
            }
        }
    }
}
