using System;
using System.Data;
using Utilitarios;
using Datos;

namespace Logica
{
    public class L_AdministrarProducto
    {
        public void page_load(bool postback,Object Session,Object id_producto)
        {
            DDAOProducto DAO_Producto = new DDAOProducto();
            if (!postback)
            {
                if (Session == null) {
                    // Response.Redirect("LoginUsr.aspx");
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    //Response.Redirect("LoginUsr.aspx");
                }
                if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
                {
                    //Response.Redirect("PerfilEmpresa.aspx");
                }
                DataTable Productos = DAO_Producto.MostrarProducto(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
            }
            if (id_producto != null)
            {
                //idProducto.Text = id_producto.ToString();
            }
        }
    }
}
