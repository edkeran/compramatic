using System;
using System.Data;
using Utilitarios;
using System.Collections.Generic;
using System.IO;
using DatosPersistencia;

namespace Logica
{
    public class L_AdministrarProducto
    {
        public U_aux_AdminProd page_load(bool postback,Object Session,Object id_producto)
        {
            //DDAOProducto DAO_Producto = new DDAOProducto();
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
                DB_Producto daoProd = new DB_Producto();
                List<UEUProducto> products = daoProd.traer_productos(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Products = products;
                //DataTable Productos = DAO_Producto.MostrarProducto(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                //response.Productos = Productos;
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
            //DDAOTag DAO_Tag = new DDAOTag();
            DB_Producto daoTag = new DB_Producto();
            UEUTag EU_Tag = new UEUTag();
            EU_Tag.Palabra = palabra;
            EU_Tag.IdProducto = idProducto;
            EU_Tag.ModifiedBy = modif;
            daoTag.añadir_tag(EU_Tag);
            //DAO_Tag.AgregarTag(EU_Tag, modif);
        }

        public String BTN_Modificar_Click(String idproducto,String nombre,String cantidad,String precio,String descripcion,string ddl_categoria,DataTable Empresa)
        {
            if (idproducto == "0")
            {
                return "Seleccione un producto";
            }
            else
            {
                //verificar funcion para hacer el update
                this.ModificarProducto(nombre, int.Parse(cantidad), Double.Parse(precio), descripcion, int.Parse(ddl_categoria), int.Parse(idproducto), Empresa.Rows[0]["nomEmpresa"].ToString());
                return "0";
            }
        }

        private void ModificarProducto(String nombre, int cantidad, double precio, String descripcion, int categoria, int idProducto, String modif)
        {

            //DDAOProducto DAO_Producto = new DDAOProducto();
            UEUProducto EU_Producto = new UEUProducto();
            DB_Producto daoProducto = new DB_Producto();
            EU_Producto.Nombre = nombre;
            EU_Producto.Cantidad = cantidad;
            EU_Producto.Precio = precio;
            EU_Producto.Descripcion = descripcion;
            EU_Producto.Categoria = categoria;
            EU_Producto.Id = idProducto;
            EU_Producto.ModifBy = modif;
            daoProducto.actualizar_producto(EU_Producto);
            //DAO_Producto.ModificarProducto(EU_Producto, modif);
        }

        public String BTN_BorrarTag_Click(String idProducto,Object Session,String ddl_tags)
        {
            if (idProducto == "0")
            {
                //Modal("Seleccione un producto");
                return "Seleccione un producto";
            }
            DataTable Empresa = (DataTable)Session;
            this.BorrarPalabra(int.Parse(ddl_tags), Empresa.Rows[0]["nomEmpresa"].ToString());
            //Response.Redirect(Request.Url.AbsoluteUri);
            return "0";
        }

        private void BorrarPalabra(int idPalabra, String modif)
        {
            //DDAOTag DAO_Tag = new DDAOTag();
            DB_Producto daoTag = new DB_Producto();
            UEUTag EU_Tag = new UEUTag();
            EU_Tag.IdTag = idPalabra;
            daoTag.delete_tag(EU_Tag);
            //DAO_Tag.EliminarTag(EU_Tag, modif);
        }

        public UEUProducto Prueba1_ItemCommand(String comandName, DataTable Empresa,  List<UEUProducto> products, int itemIndex)
        {
            ListToDataTable conv = new ListToDataTable();
            DataTable Productos=conv.ToDataTable<UEUProducto>(products);
            UEUProducto response = new UEUProducto();
            if (comandName == "Delete")
            {
                this.BorrarProducto(int.Parse(Productos.Rows[itemIndex]["Id"].ToString()), Empresa.Rows[0]["nomEmpresa"].ToString());
                response.Id = 0;
                response.Redireccion= "0";
                throw new System.ArgumentException("Valido");
            }

            if (comandName == "Select")
            {
                //CAMBIAR CUANDO SE CAMBIE EL TRAER PRODUCTOS
                response.Id = int.Parse(Productos.Rows[itemIndex]["Id"].ToString());
                response.Nombre = Productos.Rows[itemIndex]["Nombre"].ToString();
                response.Cantidad=int.Parse(Productos.Rows[itemIndex]["Cantidad"].ToString());
                response.Precio = int.Parse(Productos.Rows[itemIndex]["Precio"].ToString());
                response.Descripcion = Productos.Rows[itemIndex]["Descripcion"].ToString();
                response.Categoria = int.Parse(Productos.Rows[itemIndex]["Categoria"].ToString());
                response.BajoInventario = int.Parse(Productos.Rows[itemIndex]["BajoInventario"].ToString());
                //Session["IdProducto"] = Productos.Rows[itemIndex]["idProducto"].ToString();
                response.Redireccion = "98";
                return response;
            }
            response.Redireccion = "98";
            return response;
        }

        private void BorrarProducto(int idProducto, String modif)
        {
            //DDAOProducto DAO_Producto = new DDAOProducto();
            DB_Producto daoProdu = new DB_Producto();
            UEUProducto EU_Producto = new UEUProducto();

            EU_Producto.Id = idProducto;
            EU_Producto.ModifBy = modif;

            daoProdu.delete_producto(EU_Producto);
            //DAO_Producto.EliminarProducto(EU_Producto, modif);
        }

        public void validarException(String msg)
        {
            if (!msg.Equals("Valido"))
            {
                //NO ES VALIDO 
                throw new ArgumentException(msg);
            }
        }

        public String BTN_ModificarAlerta_Click(DataTable Empresa,String idProducto,String tb_NuevaAlerta)
        {
            if (idProducto == "0")
            {
                //Modal("Seleccione un producto");
                return "Seleccione un producto";
            }
            //VAMOS A MODIFICAR LA ALERTA DEL PRODUCTO
            UEUProducto prod = new UEUProducto();
            prod.Id = int.Parse(idProducto);
            prod.BajoInventario = int.Parse(tb_NuevaAlerta);
            prod.ModifBy = Empresa.Rows[0]["nomEmpresa"].ToString();
            //DDAOProducto DAO_Producto = new DDAOProducto();
            //DAO_Producto.ModificarAlerta(int.Parse(idProducto), int.Parse(tb_NuevaAlerta), Empresa.Rows[0]["nomEmpresa"].ToString());
            DB_Producto daoProducto = new DB_Producto();
            daoProducto.modify_alert(prod);
            //Response.Redirect(Request.Url.AbsoluteUri);
            return "0";
        }

        public String AgregarFotosProd(int TableImagenes,String idProducto,int numFotos,Object Session,String saveLocation, IList <Stream> Fotos,String extension, String nombreArchivo)
        {
            int limite = 5 - TableImagenes;
            if (idProducto == "0")
            {
                //Modal();
                return "Seleccione un producto/0";
            }
            if (numFotos > limite)
            {
                //Modal("Limite de fotos excedido");
                return "Limite de fotos excedido/0";
            }
            DataTable Empresa = (DataTable)Session;
            foreach (Stream postedFile in Fotos)
            {

                if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
                {

                    try
                    {
                        using (var stream = new FileStream(saveLocation, FileMode.Create))
                        {
                            Stream inputStream = postedFile;
                            inputStream.CopyTo(stream);
                        }
                        this.RegistrarFoto(int.Parse(idProducto), nombreArchivo, "../Archivos/FotosProductos/" + nombreArchivo, Empresa.Rows[0]["nomEmpresa"].ToString());
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    return "Formato Incorrecto/0";
                }
            }
            return "sa/AdministrarProducto.aspx";
            //Response.Redirect(Request.Url.AbsoluteUri);
        }

        public void RegistrarFoto(int idProducto, String nombreArchivo, String rutaArchivo, String modif)
        {
            DB_Producto daoProducto = new DB_Producto();
            UEUFotoProd foto = new UEUFotoProd();
            foto.Id_Product = idProducto;
            foto.NomArchi = nombreArchivo;
            foto.RutaArchi = rutaArchivo;
            foto.Modif_By = modif;
            daoProducto.subir_fotos(foto);
            //DDAOProducto DAO_Producto = new DDAOProducto();
            //UEUProducto EU_Producto = new UEUProducto();

            //EU_Producto.Id = idProducto;
            //EU_Producto.NomArchivo = nombreArchivo;
            //EU_Producto.RutaArchivo = rutaArchivo;

            //DAO_Producto.RegistrarFoto(EU_Producto, modif);
        }


        public DataTable MostrarFoto(int idProducto)
        {
            DB_Producto daoProducto = new DB_Producto();
            //DDAOProducto DAO_Producto = new DDAOProducto();
            DataTable Fotos = daoProducto.get_picture_product(idProducto);
            return Fotos;
        }


        public void BorrarFoto(int idFoto)
        {
            DB_Producto daoProducto = new DB_Producto();
            
            //DDAOProducto DAO_Producto = new DDAOProducto();
            UEUProducto EU_Producto = new UEUProducto();
            EU_Producto.IdFoto = idFoto;
            daoProducto.delete_picture(EU_Producto);
            //DAO_Producto.EliminarFoto(EU_Producto);
        }
    }
}
