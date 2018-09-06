using System;
using System.Collections.Generic;
using System.Data;
using Utilitarios;
using Datos;

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
            DDAOProducto db = new DDAOProducto();
            DataTable fotos = db.MostrarFotoProducto(idProducto);
            return fotos;
        }

        public void Delete_image(int commadArg,String modif)
        {
            DDAOProducto DAO_Producto = new DDAOProducto();
            UEUProducto EU_Producto = new UEUProducto();
            EU_Producto.Id = commadArg;
            DAO_Producto.EliminarProducto(EU_Producto, modif);
        }
    }
}
