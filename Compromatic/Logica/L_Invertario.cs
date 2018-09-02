using System;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_Invertario
    {
        public String page_load(bool postback,Object Session)
        {
            if (!postback)
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
            }
            return "0";
        }

        public String Productos_ItemCommand(String command,String tb_cantidad,String comArg,String tb_alerta,DataTable Empresa, String redir )
        {
            if (command == "Modificar")
            {
                int cantidad = int.Parse(tb_cantidad);
                int id = int.Parse(comArg);
                int bajoInventario = int.Parse(tb_alerta);
                this.ModificarInventario(id, cantidad, bajoInventario, Empresa.Rows[0]["nomEmpresa"].ToString());
                return redir;
            }
            return "Inventario.aspx.cs";
        }

        private void ModificarInventario(int idProducto, int cantidad, int bajoInventario, String modif)
        {
            UEUProducto EU_Producto = new UEUProducto();
            DDAOProducto DAO_Producto = new DDAOProducto();

            EU_Producto.Id = idProducto;
            EU_Producto.Cantidad = cantidad;
            EU_Producto.BajoInventario = bajoInventario;
            DAO_Producto.ModificarInventario(EU_Producto, modif);
        }
    }
}
