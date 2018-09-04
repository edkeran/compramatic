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
                    DDAOadministrador user = new DDAOadministrador();
                    DataTable totalcliente = user.MostrarTotalClientes();
                    DataTable TotalEmpresa = user.MostrarTotalEmpresas();
                    DataTable totalVentas = user.MostrarTotalVentas();
                    DataTable not = user.LlenarNotificacion();
                    DataTable notAcep = user.LlenarNotificacionAceptadas();
                    DataTable notRecha = user.LlenarNotificacionRechazada();
                    respo.Redireccion = "0";
                    respo.L_Usuarios1 = totalcliente.Rows[0]["count"].ToString();
                    respo.L_Empresas1 = TotalEmpresa.Rows[0]["count"].ToString();
                    respo.L_totalVentas1 = totalVentas.Rows[0]["valor"].ToString();
                    respo.L_Pqr1 = ((int.Parse(notAcep.Rows[0]["Activas"].ToString())) + (int.Parse(notRecha.Rows[0]["Activas"].ToString())) + (int.Parse(not.Rows[0]["Activas"].ToString()))).ToString();
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
