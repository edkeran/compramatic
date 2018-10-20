using System;
using System.Data;
using Utilitarios;
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
                    int totalcliente = daoAdm.tot_clients();
                    int totalEmpresa = daoAdm.total_empr();
                    double totalVentas= daoAdm.tot_ventas();
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
