using System;
using System.Data;
using Datos;
using Utilitarios;
using DatosPersistencia;

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
            }
        }

        public void obtener_ventas(DataTable data)
        {
            DataRow fila;
            DDAOadministrador bdventa = new DDAOadministrador();
            DB_ReporteAdmin daoTest = new DB_ReporteAdmin();
            vistaReporteAdmin [] historial = daoTest.crear_vista_reporte();
  
            for (int i = 0; i < historial.Length; i++)
            {
                //FILA ES DATA
                fila = data.NewRow();

                fila["nitEmp"] = historial[i].Nit_empresa;

                fila["nomEmp"] = historial[i].Nom_empresa;
                fila["calEmp"] = historial[i].Cal_empresa;
                fila["valorVentas"] = historial[i].Valor;
                fila["totalVentas"] = historial[i].Ventas;

                data.Rows.Add(fila);
            }
        }
    }
}
