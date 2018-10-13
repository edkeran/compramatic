using System;
using System.Data;
using Datos;
using DatosPersistencia;
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
                //DDAOMembresia DAO_Membresia = new DDAOMembresia();
                DB_Membresia daoMembresia = new DB_Membresia();
                //AQUI HAY UN PROBLEMA CON EL TEMA DE LA MEMBRESIA NO OLVIDAR TENGO 1 MES!!
                DataTable Membresia = new DataTable();
                //DAO_Membresia.MostrarTipos(1);
                Membresia = daoMembresia.mostrarTipos(1);
                resp.TB_Precio1 = "$" + Membresia.Rows[0]["Valor_mem"].ToString() + " COP";
                //VERIFICAR FUNCION IMPORTANTE
                //DAO_Membresia.MostrarActual(int.Parse(idEmpresa.ToString()));
                Membresia = daoMembresia.MostrarActual(int.Parse(idEmpresa.ToString()));
                resp.TB_Inicial1 = Membresia.Rows[0]["Fecha_inicio"].ToString();
                resp.TB_Final1 = Membresia.Rows[0]["Fecha_fin"].ToString();
                resp.Redirecion = "0";
                if (Membresia.Rows[0]["Estado_mem"].ToString().Equals("1"))
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
            DB_Membresia DAO_Membresia = new DB_Membresia();
            //DDAOMembresia DAO_Membresia = new DDAOMembresia();
            DataTable Membresia = new DataTable();
            Membresia = DAO_Membresia.mostrarTipos(int.Parse(value_men));
            return Membresia;
        }

        public String btn_comprar(Object Session,String TB_FechaInicio,String TB_FechaFinal,String DDL_Memebresia,Object idEmpresa)
        {
            DDAOMembresia DAO_Membresia = new DDAOMembresia();
            DB_Membresia daoMembresia= new DB_Membresia();
            DataTable Membresia = new DataTable();
            //DAO_Membresia.MostrarActual(int.Parse(idEmpresa.ToString()));
            Membresia = daoMembresia.MostrarActual2(int.Parse(idEmpresa.ToString()));
            if (Membresia.Rows.Count > 0)
            {
                return("Membresia Existente");
            }
            else
            {
                DataTable Empresa = (DataTable)Session;
                DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
                UEUMembresia encData = new UEUMembresia();
                encData.Fecha_inicio = TB_FechaInicio;
                encData.Fecha_fin = TB_FechaFinal;
                encData.Id_tipo_mem = int.Parse(DDL_Memebresia);
                encData.Id_empresa = int.Parse(idEmpresa.ToString());
                encData.ModifieBy = Empresa.Rows[0]["nomEmpresa"].ToString();
                encData.Estado_mem = 1;
                daoMembresia.RegistrarMembresia(encData);
                //DAO_Empresa.RegistrarMembresia(TB_FechaInicio, TB_FechaFinal, int.Parse(DDL_Memebresia), int.Parse(idEmpresa.ToString()), Empresa.Rows[0]["nomEmpresa"].ToString());
                return("Membresia Registrada");
            }
        }
    }
}
