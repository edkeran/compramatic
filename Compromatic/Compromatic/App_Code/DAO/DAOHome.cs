using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOHome
/// </summary>
public class DAOHome
{
	public DAOHome()
	{
		
	}
    //FUNCION MIGRADA
    public DataTable Buscador(String busq)
    {
        DataTable pdtos = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_buscador", connection);
            command.Parameters.Add("_text", NpgsqlTypes.NpgsqlDbType.Varchar).Value = busq;
            command.CommandType = CommandType.StoredProcedure;


            connection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(pdtos);

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
        return pdtos;

    }
}