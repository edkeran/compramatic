using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;

/// <summary>
/// Summary description for DAOMembresia
/// </summary>
public class DAOMembresia
{
    //Crear Una Nueva Membresia
    public void RegistrarMembresia(String fechainicio, String fechafin, int tipo,int idempresa,String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_registrar_membresia", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("_fechainicio",NpgsqlTypes.NpgsqlDbType.Varchar).Value = fechainicio;
            command.Parameters.Add("_fechafin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = fechafin;
            command.Parameters.Add("_idtipo", NpgsqlTypes.NpgsqlDbType.Integer).Value = tipo;
            command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = idempresa;
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
    public DataTable MostrarActual(int idEmpresa)
    {
        DataTable Tipos = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_membresia_actual", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idemp", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEmpresa;


            conection.Open();
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
            DA.Fill(Tipos);

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
        return Tipos;
    }

	public DataTable MostrarTipos()
    {
        DataTable Tipos = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_tipo_membresia", conection);
            command.CommandType = CommandType.StoredProcedure;


            conection.Open();
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
            DA.Fill(Tipos);

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
        return Tipos;
    }
    //FUNCION  MIGRADA
    public DataTable MostrarTipos(int id)
    {
        DataTable Tipos = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_tipo_membresia", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_tipo_membresia",NpgsqlTypes.NpgsqlDbType.Integer).Value = id;


            conection.Open();
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
            DA.Fill(Tipos);

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
        return Tipos;
    }
}