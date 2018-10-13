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
    public class L_HistorialUsr
    {
        public String page_load(Object Session)
        {
            if (Session == null)
            {
                throw new System.ArgumentException("valido");
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
                {
                    throw new System.ArgumentException("valido");
                }
                return "0";
            }
        }

        public void validarExcepcion(String msg)
        {
            if (msg.Equals("valido"))
            {
                return;
            }
            else
            {
                throw new System.ArgumentException("Error Inesperado", "Error");
            }
        }

        public void obtenerCompras(Object Session,DataTable data)
        {
            DataTable datos = (DataTable)Session;
            UEUsuario user = new UEUsuario();
            DDAOUsuario bdcompra = new DDAOUsuario();
            user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
            DataTable historial = bdcompra.HistorialCompras(user, 4);
            DataRow fila;
            for (int i = 0; i < historial.Rows.Count; i++)
            {
                fila = data.NewRow();

                fila["idVenta"] = historial.Rows[i]["idVenta"].ToString();
                String muestra = fila["idVenta"].ToString();
                fila["fechaVenta"] = historial.Rows[i]["fechaVenta"].ToString();
                String muestra1 = fila["fechaVenta"].ToString();
                fila["fechaEntrega"] = historial.Rows[i]["fechaEntrega"].ToString();
                String muestra2 = fila["fechaEntrega"].ToString();
                fila["cantVenta"] = historial.Rows[i]["cantVenta"].ToString();
                String muestra3 = fila["cantVenta"].ToString();
                fila["estadoVenta"] = historial.Rows[i]["estadoVenta"].ToString();
                String muestra4 = fila["estadoVenta"].ToString();
                fila["valorVenta"] = historial.Rows[i]["valorVenta"].ToString();
                String muestra5 = fila["valorVenta"].ToString();
                fila["nomProducto"] = historial.Rows[i]["nomProducto"].ToString();
                String muestra6 = fila["nomProducto"].ToString();
                fila["nomEmpresa"] = historial.Rows[i]["nomEmpresa"].ToString();
                String muestra7 = fila["nomEmpresa"].ToString();
                data.Rows.Add(fila);
            }
        }
    }
}
