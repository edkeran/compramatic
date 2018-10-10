using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
using System.Data;
using DatosPersistencia;

namespace Logica
{
    public class L_Store
    {
       public DataTable L_Page_Load(bool postback,Object session,DataTable productos)
        {
            if (!postback)
            {
                if (session != null)
                {
                    DataTable produc = new DataTable();
                    produc = (DataTable)session;
                    return produc;
                }
                else
                {
                    DB_Producto daoProd = new DB_Producto();
                    //DDAOProducto DAO_Producto = new DDAOProducto();
                    //DataTable response = DAO_Producto.TodoProductos();
                    //return response;
                    return daoProd.get_all_products();
                }
            }
            else
            {
                return productos;
            }
        }

        public DataTable LoadProduct(int comando)
        {
            DDAOProducto pdto = new DDAOProducto();
            return pdto.ProductosDetalle(comando);
        }
    }
}
