using System;
using System.Data;
using Utilitarios;
using Datos;

namespace Logica
{
    public class L_AdministrarProducto
    {
        public U_aux_AdminProd page_load(bool postback,Object Session,Object id_producto)
        {
            DDAOProducto DAO_Producto = new DDAOProducto();
            U_aux_AdminProd response = new U_aux_AdminProd();
            if (!postback)
            {
                if (Session == null) {
                    response.Redir = "LoginUsr.aspx";
                    return response;
                    // Response.Redirect("LoginUsr.aspx");
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    response.Redir = "LoginUsr.aspx";
                    return response;
                    //Response.Redirect("LoginUsr.aspx");
                }
                if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
                {
                    response.Redir = "PerfilEmpresa.aspx";
                    return response;
                    //Response.Redirect("PerfilEmpresa.aspx");
                }
                DataTable Productos = DAO_Producto.MostrarProducto(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Productos = Productos;
            }
            else
            {
                if (id_producto != null)
                {
                     throw new System.ArgumentException(id_producto.ToString()); 
                }else throw new System.ArgumentException("0");
            }
            if (id_producto != null)
            {
                response.IdProducto = id_producto.ToString();
            }
            return response;
        }

        public String BTN_AñadirTag_Click(String id_Producto,String palabra,String modif)
        {
            if (id_Producto == "0")
            {
                //Modal("Seleccione un producto");
                return "Seleccione un producto";
            }
            else
            {
                RegistrarPalabra(palabra, int.Parse(id_Producto), modif);
                return "0";
            }
        }

        private void RegistrarPalabra(String palabra, int idProducto, String modif)
        {
            DDAOTag DAO_Tag = new DDAOTag();
            UEUTag EU_Tag = new UEUTag();
            EU_Tag.Palabra = palabra;
            EU_Tag.IdProducto = idProducto;
            DAO_Tag.AgregarTag(EU_Tag, modif);
        }

        public String BTN_Modificar_Click(String idproducto,String nombre,String cantidad,String precio,String descripcion,string ddl_categoria,DataTable Empresa)
        {
            if (idproducto == "0")
            {
                //Modal();
                return "Seleccione un producto";
            }
            else
            {
                this.ModificarProducto(nombre, int.Parse(cantidad), Double.Parse(precio), descripcion, int.Parse(ddl_categoria), int.Parse(idproducto), Empresa.Rows[0]["nomEmpresa"].ToString());
                //Modal("Modificacion Exitosa");
                return "0";
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        private void ModificarProducto(String nombre, int cantidad, double precio, String descripcion, int categoria, int idProducto, String modif)
        {

            DDAOProducto DAO_Producto = new DDAOProducto();
            UEUProducto EU_Producto = new UEUProducto();

            EU_Producto.Nombre = nombre;
            EU_Producto.Cantidad = cantidad;
            EU_Producto.Precio = precio;
            EU_Producto.Descripcion = descripcion;
            EU_Producto.Categoria = categoria;
            EU_Producto.Id = idProducto;

            DAO_Producto.ModificarProducto(EU_Producto, modif);
        }

        public void BTN_BorrarTag_Click(String idProducto,Object Session)
        {
            if (idProducto == "0")
            {
                //Modal("Seleccione un producto");
                //return;
            }
            DataTable Empresa = (DataTable)Session;
            IADTag IAD_Tag = new IADTag();
            IAD_Tag.BorrarPalabra(int.Parse(DDL_Tags.SelectedValue), Empresa.Rows[0]["nomEmpresa"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}
