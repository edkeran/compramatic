using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

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
                    DDAOadministrador user = new DDAOadministrador();

                    DataTable not = user.LlenarNotificacion();
                    DataTable notAcep = user.LlenarNotificacionAceptadas();
                    DataTable notRecha = user.LlenarNotificacionRechazada();
                    if (not.Rows.Count == 0)
                    {
                        response.Numero_noti1 = "0";
                        //Numero_noti.Text = "0";
                    }
                    if (notAcep.Rows.Count == 0)
                    {
                        response.CantidadAceptadas = "0";
                        //cantidadAceptadas.Text = "0";
                    }
                    if (notRecha.Rows.Count == 0)
                    {
                        response.CantidadRechazadas = "0";
                        //cantidadRechazadas.Text = "0";
                    }
                    else
                    {
                        response.Numero_noti1=not.Rows[0]["Activas"].ToString();
                        response.CantidadAceptadas=notAcep.Rows[0]["Activas"].ToString();
                        response.CantidadRechazadas=notRecha.Rows[0]["Activas"].ToString();
                        response.CantidadPendientes=not.Rows[0]["Activas"].ToString();
                        response.TotalAceptadas1=notAcep.Rows[0]["Activas"].ToString();
                        response.TotalRechazadas1=notRecha.Rows[0]["Activas"].ToString();
                        response.TotalPendientes1=not.Rows[0]["Activas"].ToString();
                    }
                    response.TotalSolicitudes1=((int.Parse(notAcep.Rows[0]["Activas"].ToString())) + (int.Parse(notRecha.Rows[0]["Activas"].ToString())) + (int.Parse(not.Rows[0]["Activas"].ToString()))).ToString();
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
