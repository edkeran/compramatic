using System;
using System.Data;
using DatosPersistencia;
using Utilitarios;

namespace Logica
{
    public class L_verProducto
    {
        public UEUProducto page_load(bool post,Object VerProducto,Object Session)
        {
            UEUProducto respo = new UEUProducto();
            if (!post)
            {

                if (VerProducto == null)
                {
                    respo.Redireccion = "Home.aspx";
                    return respo;
                    //Response.Redirect();
                }
                else
                {
                    DataTable Fotos = new DataTable();
                    //DDAOProducto DAO_Producto = new DDAOProducto();
                    DB_Producto daoProducto = new DB_Producto();
                    DataTable producto = (DataTable)VerProducto;
                    respo.Nombre = producto.Rows[0]["nomProducto"].ToString();
                    respo.Descripcion = producto.Rows[0]["desProducto"].ToString();
                    respo.PrecioString = "$" + producto.Rows[0]["precioProducto"].ToString();
                    respo.NomEmp = producto.Rows[0]["nomEmpresa"].ToString();
                    respo.Cantidad = int.Parse(producto.Rows[0]["canProducto"].ToString());
                    respo.NomCategoria = producto.Rows[0]["nomCategoria"].ToString();
                    //DAO_Producto.MostrarFotoProducto(int.Parse(producto.Rows[0]["idProducto"].ToString()));
                    Fotos = daoProducto.get_picture_product(int.Parse(producto.Rows[0]["idProducto"].ToString()));
                    respo.Fotos = Fotos;
                    //RP_FotosProductos.DataSource = Fotos;
                    //RP_FotosProductos.DataBind();
                    if (Session != null)
                    {
                        //ACTUALIZAR EL TOP 10
                        DataTable user = (DataTable)Session;
                        if (user.Rows[0]["idTipo"].ToString() == "3")
                        {
                            DBUsr daoUser = new DBUsr();
                            //DDAOUsuario top = new DDAOUsuario();
                            daoUser.insertar_top_10(int.Parse(producto.Rows[0]["idProducto"].ToString()), int.Parse(user.Rows[0]["idUsuario"].ToString()), user.Rows[0]["nomUsuario"].ToString());
                            //top.Top10(int.Parse(producto.Rows[0]["idProducto"].ToString()), int.Parse(user.Rows[0]["idUsuario"].ToString()), user.Rows[0]["nomUsuario"].ToString());
                        }
                    }
                    return respo;
                }
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public UAuxVenta BTN_ComprarProducto_Click(Object Session,Object VerProducto,String tb_CantidadVenta,String LB_CantidadProducto,bool post)
        {
            UAuxVenta reponde = new UAuxVenta();
            if (post)
            {
                if (Session == null)
                {
                    reponde.Valido = true;
                    reponde.Msg = "Tienes que iniciar sesion para comprar.";
                    //BTN_Modal.Visible = true;
                    //Modal("Tienes que iniciar sesion para comprar.");

                }
                else
                {
                    DataTable user = (DataTable)Session;
                    DataTable producto = (DataTable)VerProducto;
                    if (tb_CantidadVenta.Length == 0)
                    {
                        reponde.Valido = false;
                        reponde.Msg = "Tienes que especificar la cantidad de productos a comprar.";
                        //Modal("Tienes que especificar la cantidad de productos a comprar.");
                    }
                    else if (user.Rows[0]["idTipo"].ToString() != "3")
                    {
                        reponde.Valido = false;
                        reponde.Msg = "Solo los clientes pueden hacer petición de compra.";
                        //Modal("Solo los clientes pueden hacer petición de compra.");
                    }
                    else if ((int.Parse(tb_CantidadVenta)) > (int.Parse(LB_CantidadProducto)))
                    {
                        reponde.Valido = false;
                        reponde.Msg = "Solicitaste una cantidad que excede nuestro límite de inventario, reduce tu cantidad de productos a comprar.";
                        //Modal("Solicitaste una cantidad que excede nuestro límite de inventario, reduce tu cantidad de productos a comprar.");
                    }

                    else if (int.Parse(LB_CantidadProducto) == 0)
                    {
                        reponde.Valido = false;
                        reponde.Msg = "El producto está agotado, intentalo después.";
                        //Modal("El producto está agotado, intentalo después.");
                    }
                    else
                    {
                        UEUVenta venta = new UEUVenta();
                        venta.IdUsr = int.Parse(user.Rows[0]["idUsuario"].ToString());
                        int valor = int.Parse(tb_CantidadVenta) * int.Parse(producto.Rows[0]["precioProducto"].ToString());
                        reponde.Valido = false;
                        reponde.BtnYes = true;
                        reponde.Msg = "Tu solicitud de compra ha sido enviada, por valor de $" + valor.ToString() + ", la empresa revisará los parámetros y decidirá aceptar o rechazar tu compra. Deseas confirmar esta compra?";
                        //BTN_Yes.Visible = true;
                        //Modal("Tu solicitud de compra ha sido enviada, por valor de $" + valor.ToString() + ", la empresa revisará los parámetros y decidirá aceptar o rechazar tu compra. Deseas confirmar esta compra?");
                    }
                }
            }
            else
            {
                reponde=null;
            }
            
            return reponde;
        }

        public UAuxVenta BTN_Reportar_Click(Object Session,Object VerProducto,String DDL_Reportes)
        {
            UAuxVenta response = new UAuxVenta();
            if (Session == null)
            {
                response.Valido = false;
                response.Msg = "Tienes que iniciar sesion para reportar este producto.";
                return response;
                //BTN_Modal.Visible = true;
                //Modal("Tienes que iniciar sesion para reportar este producto.");
            }
            else
            {
                DataTable validacion = (DataTable)Session;
                if (validacion.Rows[0]["idTipo"].ToString() != "3")
                {
                    response.Valido = false;
                    response.Msg = "Solo los usuarios pueden reportar.";
                    return response;
                    //Modal("Solo los usuarios pueden reportar.");
                    //return;
                }
                DataTable user = (DataTable)Session;
                DataTable producto = (DataTable)VerProducto;
                //DDAOUsuario reporte = new DDAOUsuario();
                DBUsr daoUsuario = new DBUsr();
                int comprobar = daoUsuario.ComprobarReporte(int.Parse(user.Rows[0]["idUsuario"].ToString()), int.Parse(producto.Rows[0]["idProducto"].ToString()));
                if (comprobar == 1)
                {
                    response.Valido = false;
                    response.Msg = "Ya has reportado este producto con anterioridad.";
                    //Modal("Ya has reportado este producto con anterioridad.");
                }
                else
                {
                    daoUsuario.ReportarProducto(int.Parse(DDL_Reportes), int.Parse(user.Rows[0]["idUsuario"].ToString()), int.Parse(producto.Rows[0]["idProducto"].ToString()), user.Rows[0]["nomUsuario"].ToString());
                    daoUsuario.Bloquear_producto(user.Rows[0]["nomUsuario"].ToString(), int.Parse(producto.Rows[0]["idProducto"].ToString()));
                    response.Valido = false;
                    response.Msg = "Se ha enviado tu reporte a nuestro sistema.";
                    //Modal("Se ha enviado tu reporte a nuestro sistema.");
                    return response;
                }
                return response;
            }
        }

        public void BTN_Yes_Click(Object Session,Object VerProducto,String TB_CantidadVenta)
        {
            DataTable user = (DataTable)Session;
            DataTable producto = (DataTable)VerProducto;
            UEUVenta venta = new UEUVenta();
            venta.IdUsr = int.Parse(user.Rows[0]["idUsuario"].ToString());
            venta.Cantidad = int.Parse(TB_CantidadVenta);
            int valor = int.Parse(TB_CantidadVenta) * int.Parse(producto.Rows[0]["precioProducto"].ToString());
            venta.Valor = valor;
            venta.IdProducto = int.Parse(producto.Rows[0]["idProducto"].ToString());
            venta.EstadoVenta = 1;
            DB_Producto daoProducto = new DB_Producto();
            //DDAOProducto compra = new DDAOProducto();
            daoProducto.CompraProducto(venta, user.Rows[0]["nomUsuario"].ToString());
        }
    }
}
