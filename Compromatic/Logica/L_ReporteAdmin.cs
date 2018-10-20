using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_ReporteAdmin
    {
        public String page_load(Object Session,Object sesion)
        {
            if (Session == null)
            {
                return "LoginUsr.aspx";
                //Response.Redirect();
            }
            else
            {

                int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                { }
                else
                {
                    return "LoginUsr.aspx";
                    //Response.Redirect();
                }
                return "0";
            }
        }

        public DataTable images(int idProducto)
        {
            DB_Producto daoProducto = new DB_Producto();
            //DDAOProducto db = new DDAOProducto();
            DataTable fotos = daoProducto.get_picture_product(idProducto);
            return fotos;
        }

        public void Delete_image(int commadArg,String modif)
        {
            DB_Producto daoProducto = new DB_Producto();
            //DDAOProducto DAO_Producto = new DDAOProducto();
            UEUProducto EU_Producto = new UEUProducto();
            EU_Producto.Id = commadArg;
            EU_Producto.ModifBy = modif;
            daoProducto.delete_producto(EU_Producto);
            //DAO_Producto.EliminarProducto(EU_Producto, modif);
        }
    }
}
