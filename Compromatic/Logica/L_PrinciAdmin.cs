using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using DatosPersistencia;

namespace Logica
{
    public class L_PrinciAdmin
    {
        public UAuxPrinciAdmin page_load(Object Session)
        {
            UAuxPrinciAdmin respo = new UAuxPrinciAdmin();
            if (Session == null)
            {
                respo.Redireccion = "LoginUsr.aspx";
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                if (int.Parse(((DataTable)(Session)).Rows[0]["idTipo"].ToString()) == 1)
                {

                    int num = int.Parse(((DataTable)(Session)).Rows[0]["idTipo"].ToString());
                    //LLAMAMOS A LA NUEVA DB
                    DB_Admin daoAdm = new DB_Admin();
                    DDAOadministrador user = new DDAOadministrador();
                    int totalcliente = daoAdm.tot_clients();
                    int totalEmpresa = daoAdm.total_empr();
                    int totalVentas= daoAdm.tot_ventas();
                    //DataTable totalcliente = user.MostrarTotalClientes();
                    //DataTable TotalEmpresa = user.MostrarTotalEmpresas();
                    //DataTable totalVentas = user.MostrarTotalVentas();
                    //totalcliente.Rows[0]["count"].ToString();
                    //TotalEmpresa.Rows[0]["count"].ToString();
                    //totalVentas.Rows[0]["valor"].ToString();
                    //DataTable not = user.LlenarNotificacion();
                    //DataTable notAcep = user.LlenarNotificacionAceptadas();
                    //DataTable notRecha = user.LlenarNotificacionRechazada();
                    int not = daoAdm.llenar_notificacion();
                    int notAcep = daoAdm.llenar_notificacionAccept();
                    int notRecha = daoAdm.llenar_notificacionRechaz();
                    respo.Redireccion = "0";
                    respo.L_Usuarios1 = totalcliente.ToString();
                    respo.L_Empresas1 = totalEmpresa.ToString();
                    respo.L_totalVentas1 = totalVentas.ToString("C");
                    respo.L_Pqr1 = (notAcep + notRecha + not).ToString();
                }

                else
                {
                    respo.Redireccion = "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
            return respo;
        }
    }
}
