using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOTag
/// </summary>
public class DAOTag
{
    public DataTable MostrarTags(EUTag EU_Tag)
    {
        DataTable Tags = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_palabraclave", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Tag.IdProducto;
            conection.Open();
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter(command);
            DA.Fill(Tags);

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

        return Tags;
    }
    //METODO MIGRADO
    public void AgregarTag(EUTag EU_Tag, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_registrar_palabraclave", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
            command.Parameters.Add("_palabra", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Tag.Palabra;
            command.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Tag.IdProducto;
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
    public void EliminarTag(EUTag EU_Tag, String modif)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {

            NpgsqlCommand command = new NpgsqlCommand("sp_borrar_palabraclave", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_idpalabra", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Tag.IdTag;
            command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Integer).Value = modif;
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