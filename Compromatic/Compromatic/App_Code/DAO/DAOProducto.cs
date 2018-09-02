using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOProducto
/// </summary>
public class DAOProducto
{

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
    //METODO MIGRADO TO DDAOProducto
    public void ModificarInventario(EUProducto EU_Producto, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_modificar_inventario", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("_idproducto",NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Id;
            command.Parameters.Add("_cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Cantidad;
            command.Parameters.Add("_bajoinventario", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.BajoInventario;

            conection.Open();
            command.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            throw e;
        }
        finally
        {
            conection.Close();
        }
    }
    //METODO MIGRADO
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
    public void CompraProducto(EUVenta venta, String modif)
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

    public DataTable ProductosBajoI(int idEmpresa)
    {
        DataTable Productos = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_producto_bajoi", conection);
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

    //FUNCION MIGRADA
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

    public DataTable MostrarCategoria()
    {
        DataTable Categorias = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_categoria", conection);
            command.CommandType = CommandType.StoredProcedure;


            conection.Open();
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
            DA.Fill(Categorias);

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
        return Categorias;
    }
    //METODO MIGRADO A DDAOPRODUCTO
    public void GuardarProducto(EUProducto EU_Producto, String modif)
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
    //METODO MIGRADO A DDAOPRODUCTO
    public void EliminarProducto(EUProducto EU_Producto, String modif)
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
    //METODO MIGRADO
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
    //METODO MIGRADO
    public void ModificarProducto(EUProducto EU_Producto, String modif)
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
    //Metodo Migrado a DDAOProducto
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

    public void RegistrarFoto(EUProducto EU_Producto, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_registrar_fotoproducto", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.Id;
            command.Parameters.Add("_nomarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Producto.NomArchivo;
            command.Parameters.Add("_rutaarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Producto.RutaArchivo;


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

    internal void EliminarFoto(EUProducto EU_Producto)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_borrar_fotoproducto", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idfoto_producto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Producto.IdFoto;
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
}