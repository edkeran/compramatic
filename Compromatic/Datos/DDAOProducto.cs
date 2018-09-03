using System;
using System.Data;
using Npgsql;
using System.Configuration;
using Utilitarios;

namespace Datos
{
    public class DDAOProducto
    {
        public DataTable TodoProductos()
        {
            DataTable Productos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_todos_productos", conection);
                command.CommandType = CommandType.StoredProcedure;


                conection.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
                DA.Fill(Productos);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Productos;
        }

        //METODO PARA CONFIRMAR QUE EL PRODUCTO HA SIDO ENVIADO SATISFACTORIAMENTE
        public void ConfirmarRecibido(int idVenta, int estado, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_modificar_estado_venta", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_idventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idVenta;
                command.Parameters.Add("_estadoventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = estado;
                conection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conection.Close();
            }
        }
        //METODO QUE TRAE INFORMACION ACERCA DEL PRODUCTO SELECCIONADO
        public DataTable ProductosDetalle(int idPdto)
        {
            DataTable Producto = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_producto_detalles", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = idPdto;

                conection.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
                DA.Fill(Producto);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Producto;
        }

        //Metodo Para Crear Un Nuevo Producto
        public void GuardarProducto(UEUProducto EU_Producto, String modif)
        {

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_registrar_producto", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_nomproducto", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Producto.Nombre;
                command.Parameters.Add("_canproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Cantidad;
                command.Parameters.Add("_precioproducto", NpgsqlTypes.NpgsqlDbType.Double).Value = EU_Producto.Precio;
                command.Parameters.Add("_desproducto", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Producto.Descripcion;
                command.Parameters.Add("_idcategoria", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Categoria;
                command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.IdEmpresa;
                conection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
        }
        //Metodo para modificar las existencias del producto
        public void ModificarInventario(UEUProducto EU_Producto, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_modificar_inventario", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Id;
                command.Parameters.Add("_cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Cantidad;
                command.Parameters.Add("_bajoinventario", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.BajoInventario;

                conection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conection.Close();
            }
        }

        //Metodo Para Mostrar Los Productos De La Correspondiente Empresa
        public DataTable MostrarProducto(int idEmpresa)
        {
            DataTable Productos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_producto", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;


                conection.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
                DA.Fill(Productos);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Productos;
        }
        //metodo para modificar un producto existenete
        public void ModificarProducto(UEUProducto EU_Producto, String modif)
        {

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_modificar_producto", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Id;
                command.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Producto.Nombre;
                command.Parameters.Add("_cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Cantidad;
                command.Parameters.Add("_precio", NpgsqlTypes.NpgsqlDbType.Double).Value = EU_Producto.Precio;
                command.Parameters.Add("_descripcion", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Producto.Descripcion;
                command.Parameters.Add("_idcategoria", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Categoria;
                conection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
        }
        //metodo para eliminar un producto
        public void EliminarProducto(UEUProducto EU_Producto, String modif)
        {

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_borrar_producto", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Id;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Varchar).Value = modif;
                conection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
        }

        public void ModificarAlerta(int id, int alerta, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_modificar_alerta", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                command.Parameters.Add("_nueva", NpgsqlTypes.NpgsqlDbType.Integer).Value = alerta;

                conection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conection.Close();
            }
        }

        public DataTable MostrarFotoProducto(int idProducto)
        {
            DataTable FotosProducto = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_fotoproducto", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = idProducto;


                conection.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
                DA.Fill(FotosProducto);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return FotosProducto;
        }

        public void CompraProducto(UEUVenta venta, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_comprar_producto", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = venta.IdProducto;
                command.Parameters.Add("_canventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = venta.Cantidad;
                command.Parameters.Add("_valorventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = venta.Valor;
                command.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = venta.IdUsr;
                command.Parameters.Add("_estadoventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = venta.EstadoVenta;

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conection.Close();
            }
        }

    }
}
