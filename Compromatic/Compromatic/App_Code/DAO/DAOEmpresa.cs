using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOEmpresa
/// </summary>
public class DAOEmpresa
{
    //METODO MIGRADO
    public void RegistrarMembresia(String fechaInicio, String fechaFinal, int tipo, int idEmpresa, String modif)
    {
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_registrar_membresia", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_fechainicio", NpgsqlTypes.NpgsqlDbType.Integer).Value = fechaInicio;
            command.Parameters.Add("_fechafin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = fechaInicio;
            command.Parameters.Add("_idtipo", NpgsqlTypes.NpgsqlDbType.Integer).Value = tipo;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
    }
    //METODO MIGRADO
    public void CalificarCliente(double rango, String comentario, int idEmpresa, int idCliente, int idVenta, String modif)
    {
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_calificar_cliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_rango", NpgsqlTypes.NpgsqlDbType.Integer).Value = rango;
            command.Parameters.Add("_comentario", NpgsqlTypes.NpgsqlDbType.Varchar).Value = comentario;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            command.Parameters.Add("_idcliente", NpgsqlTypes.NpgsqlDbType.Integer).Value = idCliente;
            command.Parameters.Add("_idventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idVenta;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
    }
    //METODO MIGRADO
    public DataTable MostrarCalificaciones(int idEmpresa)
    {
        DataTable Calificaciones = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_calificaciones", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(Calificaciones);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return Calificaciones;
    }
    //METODO MIGRADO
    public void RechazarVenta(int idVenta, String modif)
    {

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_rechazar_venta", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idVenta;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

    }
    //METODO MIGRADO
    public int AprobarVenta(int idVenta, String usuario)
    {

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        DataTable aux = new DataTable();
        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_aprobar_venta", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idVenta;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(aux);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return int.Parse(aux.Rows[0][0].ToString());
    }

    //METODO MIGRADO
    public DataTable PeticionesCompra(int idEmpresa)
    {
        DataTable Peticiones = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_solicitud_venta", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(Peticiones);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return Peticiones;
    }
    //METODO MIGRADO
    public DataTable PeticionCompra(int idVenta)
    {
        DataTable Peticiones = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_venta", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idventa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idVenta;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(Peticiones);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return Peticiones;
    }
    //METODO MIGRADO
    public DataTable PeticionesEnProceso(int idEmpresa)
    {
        DataTable Peticiones = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_solicitud_enproceso", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(Peticiones);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return Peticiones;
    }
    //METODO MIGRADO
    public DataTable PeticionesFinalizadas(int idEmpresa)
    {
        DataTable Peticiones = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_venta_finalizada", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(Peticiones);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return Peticiones;
    }
    //METODO MIGRADO
    public DataTable PeticionesHechas(int idEmpresa)
    {
        DataTable Peticiones = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_venta_hecha", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(Peticiones);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }

        return Peticiones;
    }
    //FUNCION MIGRADA
    public Boolean ExistenciaCorreo(String correo)
    {
        Boolean existencia;
        DataTable Correo = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_existencia_empresa", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_correo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = correo;
            connection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(Correo);
            existencia = bool.Parse(Correo.Rows[0][0].ToString());

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        return existencia;
    }

    //METODO MOVIDO A DATOS EN DDAOEmpresa
    public DataTable LoginEmpresa(EUEmpresa EU_Empresa)
    {
        DataTable Empresa = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_login_empresa", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_correo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Correo;
            command.Parameters.Add("_contraseña", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Contraseña;

            connection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(Empresa);

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        return Empresa;
    }
    //METODO MIGRADO
    public void CrearEmpresa(EUEmpresa EU_Empresa, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand("sp_registro_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("_nombreempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nombre;
            command.Parameters.Add("_telempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Numero;
            command.Parameters.Add("_correoempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Correo;
            command.Parameters.Add("_dirempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Direccion;
            command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
            command.Parameters.Add("_nomarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.NomArchivo;
            command.Parameters.Add("_rutaarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.RutaArchivo;
            command.Parameters.Add("_idtipo", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.IdTipo;
            command.Parameters.Add("_contraseña", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Contraseña;
            command.Parameters.Add("_fechainicio", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = EU_Empresa.FechaInicio;
            command.Parameters.Add("_fechafin", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = EU_Empresa.FechaFin;
            command.Parameters.Add("_idtipo_membresia", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.IdTipoMembresia;
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
    public DataTable MostrarArchivos(EUEmpresa EU_Empresa)
    {
        DataTable Archivos = new DataTable();

        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrararchivos_solicitud", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;


            connection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(Archivos);

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        return Archivos;
    }
    //METODO MIGRADO
    public void SubirArchivo(EUEmpresa EU_Empresa, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand("sp_registro_archivo_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("_rutaarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.RutaArchivo;
            command.Parameters.Add("_nombrearchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.NomArchivo;
            command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;

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

    public void BorrarArchivo(EUEmpresa EU_Empresa, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand("sp_borrar_archivo_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idarchivo", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.Id;
            command.Parameters.Add("_mmodif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;

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
    public void CambiarContraseña(EUEmpresa EU_Empresa, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand("sp_cambiar_contraseña_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
            command.Parameters.Add("_passempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Contraseña;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
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
    public void CambiarFoto(EUEmpresa EU_Empresa, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand("sp_cambiar_foto_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
            command.Parameters.Add("_nomarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.NomArchivo;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
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
    public void ModificarEmpresa(EUEmpresa EU_Empresa, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand("sp_modificar_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.Id;
            command.Parameters.Add("nombreempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nombre;
            command.Parameters.Add("telempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Numero;
            command.Parameters.Add("correoempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Correo;
            command.Parameters.Add("dirempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Direccion;
            command.Parameters.Add("nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
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