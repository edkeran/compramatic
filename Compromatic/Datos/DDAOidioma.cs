using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using Utilitarios;

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

        //FUNCION PARA EL CAMBIO DE LOS CONTROLES DE LOS FORMULARIOS
        public DataTable Controles(int id_form,int id_idioma)
        {
            DataTable pdtos = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.fn_obtener_controles", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_form", NpgsqlDbType.Integer).Value = id_form;
                dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = id_idioma;
                connection.Open();
                dataAdapter.Fill(pdtos);

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
        //FUNCION PARA INSERTAR UN NUEVO IDIOMA
        public void insertar_idioma(String idioma,String termi)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("idioma.fn_insertar_idioma", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_termina", NpgsqlTypes.NpgsqlDbType.Varchar).Value = termi;
                comando.Parameters.Add("_idioma", NpgsqlTypes.NpgsqlDbType.Varchar).Value = idioma;
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
        }
        //FUNCION PARA INSERTAR UNA TRADUCCION
        public void insertar_traduccion(UEUTraduccion data)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("idioma.fn_insertar_traduccion", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_text", NpgsqlTypes.NpgsqlDbType.Varchar).Value = data.Texto;
                comando.Parameters.Add("_nom_contr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = data.Control;
                comando.Parameters.Add("_idioma", NpgsqlTypes.NpgsqlDbType.Integer).Value = data.Idioma;
                comando.Parameters.Add("_form", NpgsqlTypes.NpgsqlDbType.Integer).Value = data.Form;
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
