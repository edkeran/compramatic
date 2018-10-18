using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_MasterAdmin
    {
        public U_AuxMasterAdmin page_load(Object Session)
        {
            U_AuxMasterAdmin response = new U_AuxMasterAdmin();
            if (Session== null)
            {
                response.Redireccion = "LoginUsr.aspx";
                //Response.Redirect();
            }
            else
            {
                int num = int.Parse(((DataTable)(Session)).Rows[0]["idTipo"].ToString());
                if (int.Parse(((DataTable)(Session)).Rows[0]["idTipo"].ToString()) == 1)
                {
                    //DDAOadministrador user = new DDAOadministrador();

                    //DataTable not = user.LlenarNotificacion();
                    //DataTable notAcep = user.LlenarNotificacionAceptadas();
                    //DataTable notRecha = user.LlenarNotificacionRechazada();

                    //REEMPLAZO
                    DB_Admin dao_Admin = new DB_Admin();
                    int not = dao_Admin.llenar_notificacion();
                    int notAcep = dao_Admin.llenar_notificacionAccept();
                    int notRecha = dao_Admin.llenar_notificacionRechaz();

                    if (not == 0)
                    {
                        response.Numero_noti1 = "0";
                        //Numero_noti.Text = "0";
                    }
                    if (notAcep == 0)
                    {
                        response.CantidadAceptadas = "0";
                        //cantidadAceptadas.Text = "0";
                    }
                    if (notRecha == 0)
                    {
                        response.CantidadRechazadas = "0";
                        //cantidadRechazadas.Text = "0";
                    }
                    else
                    {
                        response.Numero_noti1=not.ToString();
                        response.CantidadAceptadas=notAcep.ToString();
                        response.CantidadRechazadas=notRecha.ToString();
                        response.CantidadPendientes=not.ToString();
                        response.TotalAceptadas1=notAcep.ToString();
                        response.TotalRechazadas1=notRecha.ToString();
                        response.TotalPendientes1=not.ToString();
                    }
                    response.TotalSolicitudes1=(notAcep + notRecha + not).ToString();
                    String img = ((DataTable)(Session)).Rows[0]["rutaArchivo"].ToString() + ((DataTable)(Session)).Rows[0]["nomArchivo"].ToString();
                    response.FotoPerfil1 = img;
                    response.NombrePerfil1= ((DataTable)(Session)).Rows[0]["nomUsuario"].ToString() + " " + ((DataTable)(Session)).Rows[0]["apeUsuario"].ToString();
                    response.NombrePerfil21= ((DataTable)(Session)).Rows[0]["nomUsuario"].ToString();
                    response.Redireccion = "0";
                }
                else
                {
                    response.Redireccion = "LoginUsr.aspx";
                    //Response.Redirect();
                }
            }
            return response;
        }
    }
}
