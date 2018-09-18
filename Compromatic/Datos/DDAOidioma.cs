using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;

namespace Datos
{
    public class DDAOidioma
    {
        public DataTable obtenerIdioma(Int32 formulario, Int32 idioma)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.fn_obtener_idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_formulario_id", NpgsqlDbType.Integer).Value = formulario;
                dataAdapter.SelectCommand.Parameters.Add("_idioma_id", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Usuario;
        }

        public DataTable vereditidioma()
        {
            DataTable Competencia = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.fn_vereditidioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Competencia);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Competencia;
        }



        public DataTable textoedit(Int32 id, String texto)
        {
            DataTable Competencia = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.fn_textoedit", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_texto", NpgsqlDbType.Integer).Value = texto;

                conection.Open();
                dataAdapter.Fill(Competencia);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Competencia;
        }

        public DataTable Idiomas()
        {
            DataTable pdtos = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("idioma.fn_get_idiomas", connection);
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

        public DataTable Formularios()
        {
            DataTable pdtos = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("idioma.fn_get_formularios", connection);
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
