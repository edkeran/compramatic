using System;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_ReporteTotVenta
    {
        public void page_load(Object Session)
        {
            if (Session == null)
            {
                throw new ArgumentException("Valido");
            }
            else
            {
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 1)
                {
                    throw new ArgumentException("Valido");
                }
                //CRS_Ventas.ReportDocument.SetDataSource(obtenerVentas());
                //CRV_Ventas.ReportSource = CRS_Ventas;
            }
        }

        public void obtener_ventas(DataTable data)
        {
            DataRow fila;
            DDAOadministrador bdventa = new DDAOadministrador();
            DataTable historial = bdventa.MostrarVentasPorEmpresa();

            for (int i = 0; i < historial.Rows.Count; i++)
            {
                fila = data.NewRow();

                fila["nitEmp"] = historial.Rows[i]["nitEmpresa"].ToString();

                fila["nomEmp"] = historial.Rows[i]["nomEmpresa"].ToString();
                fila["calEmp"] = historial.Rows[i]["calificacionEmpresa"].ToString();
                fila["valorVentas"] = historial.Rows[i]["valor"].ToString();
                fila["totalVentas"] = historial.Rows[i]["ventas"].ToString();

                data.Rows.Add(fila);
            }
        }
    }
}
