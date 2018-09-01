using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DDAOHome
    {
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
}
