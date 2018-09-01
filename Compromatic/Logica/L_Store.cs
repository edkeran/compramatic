using System;
using System.Collections.Generic;
using Utilitarios;
using Datos;
using System.Data;

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
                    DDAOProducto DAO_Producto = new DDAOProducto();
                    DataTable response = DAO_Producto.TodoProductos();
                    return response;
                }
            }
            else
            {
                return productos;
            }
        }
    }
}
