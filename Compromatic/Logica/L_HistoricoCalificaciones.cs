using System;
using System.Collections.Generic;
using Utilitarios;
using DatosPersistencia;
using System.Data;

namespace Logica
{
    public class L_HistoricoCalificaciones
    {
        public String page_inicial(bool post,Object Session)
        {
            if (!post)
            {
                if (Session == null)
                {
                    return "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    return "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }
                if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
                {
                    return "PerfilEmpresa.aspx";
                    //Response.Redirect("PerfilEmpresa.aspx");
                }
                return "0";
                //CRS_Calificaciones.ReportDocument.SetDataSource(Calificaciones());
                //CRV_Calificaciones.ReportSource = CRS_Calificaciones;
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public void Calificaciones(Object idEmpresa,DataTable data)
        {
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            //DataTable historial = DAO_Empresa.MostrarCalificaciones(int.Parse(idEmpresa.ToString()));
            DataRow fila;
            DBReporteEmpresa daoRep = new DBReporteEmpresa();
            UEURango [] historial=daoRep.obtener_calificaciones(int.Parse(idEmpresa.ToString()));

            for (int i = 0; i < historial.Length; i++)
            {
                fila = data.NewRow();

                fila["Rango"] = historial[i].Rango;
                fila["Comentario"] = historial[i].Comentario;
                fila["FechaRango"] = historial[i].FechaRango;
                fila["nomUsuario"] = historial[i].Nom_usuario;
                data.Rows.Add(fila);
            }
        }
    }
}
