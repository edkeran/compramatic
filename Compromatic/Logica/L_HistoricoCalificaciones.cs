using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
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
            //DataSet compras = new DataSet();
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            DataTable historial = DAO_Empresa.MostrarCalificaciones(int.Parse(idEmpresa.ToString()));
            //DataTable data = new DataTable();
            //data = compras.Calificaciones;
            DataRow fila;

            for (int i = 0; i < historial.Rows.Count; i++)
            {
                fila = data.NewRow();

                fila["Rango"] = historial.Rows[i]["rango"].ToString();
                fila["Comentario"] = historial.Rows[i]["comentarios"].ToString();
                fila["FechaRango"] = historial.Rows[i]["fechaRango"].ToString();
                fila["nomUsuario"] = historial.Rows[i]["nomUsuario"].ToString();
                data.Rows.Add(fila);
            }
        }
    }
}
