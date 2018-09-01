using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Threading.Tasks;

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
    }
}
