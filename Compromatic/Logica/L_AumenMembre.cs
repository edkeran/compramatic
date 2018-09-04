using System;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_AumenMembre
    {
        public U_AuxAumMemb page_load(bool post,Object Session,Object idEmpresa)
        {
            U_AuxAumMemb resp = new U_AuxAumMemb();
            if (!post)
            {
                if (Session == null)
                {
                    resp.Redirecion = "LoginUsr.aspx";
                    //Response.Redirect();
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    resp.Redirecion = "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }

                DateTime Fecha = DateTime.Now.Date;
                resp.TB_FechaInicio1= Fecha.ToShortDateString();
                Fecha = Fecha.AddMonths(1);
                resp.TB_FechaFinal1 = Fecha.ToShortDateString();
                DDAOMembresia DAO_Membresia = new DDAOMembresia();

                //AQUI HAY UN PROBLEMA CON EL TEMA DE LA MEMBRESIA
                DataTable Membresia = new DataTable();
                Membresia = DAO_Membresia.MostrarTipos(1);
                resp.TB_Precio1 = "$" + Membresia.Rows[0]["valorMembresia"].ToString() + " COP";
                //VERIFICAR FUNCION
                Membresia = DAO_Membresia.MostrarActual(int.Parse(idEmpresa.ToString()));
                resp.TB_Inicial1 = Membresia.Rows[0]["fechaInicio"].ToString();
                resp.TB_Final1 = Membresia.Rows[0]["fechaFin"].ToString();
                resp.Redirecion = "0";
                if (Membresia.Rows[0]["estadoMembresia"].ToString().Equals("1"))
                {
                    resp.TB_Plan1 = "Activo";
                    //TB_Plan.Text = "Activo";
                }
                else
                {
                    resp.TB_Plan1 = "Vencida";
                    //TB_Plan.Text = "Vencida";
                }
                return resp;
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public DataTable ddl_membresia_event(String value_men)
        {
            DDAOMembresia DAO_Membresia = new DDAOMembresia();
            DataTable Membresia = new DataTable();
            Membresia = DAO_Membresia.MostrarTipos(int.Parse(value_men));
            return Membresia;
        }

        public String btn_comprar(Object Session,String TB_FechaInicio,String TB_FechaFinal,String DDL_Memebresia,Object idEmpresa)
        {
            DDAOMembresia DAO_Membresia = new DDAOMembresia();
            DataTable Membresia = new DataTable();
            Membresia = DAO_Membresia.MostrarActual(int.Parse(idEmpresa.ToString()));
            if (Membresia.Rows.Count > 0)
            {
                return("Membresia Existente");
            }
            else
            {
                DataTable Empresa = (DataTable)Session;
                DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
                DAO_Empresa.RegistrarMembresia(TB_FechaInicio, TB_FechaFinal, int.Parse(DDL_Memebresia), int.Parse(idEmpresa.ToString()), Empresa.Rows[0]["nomEmpresa"].ToString());
                return("Membresia Registrada");
            }
        }
    }
}
