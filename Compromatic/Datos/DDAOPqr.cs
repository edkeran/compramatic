using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DDAOPqr
    {
        public DataTable MostrarMotivos()
        {
            DataTable Motivos = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_motivoq", connection);
                command.CommandType = CommandType.StoredProcedure;


                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(Motivos);

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
            return Motivos;
        }

        //MIGRADO
        public void QuejaUsr(UEUPqr pqr, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_registrar_pqrusr", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_desqueja", NpgsqlTypes.NpgsqlDbType.Varchar, 100).Value = pqr.Descripcion;
                command.Parameters.Add("_idusuario", NpgsqlTypes.NpgsqlDbType.Integer).Value = pqr.IdCliente;
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
        //MIGRADO
        public void RegistrarPqr(UEUPqr EU_Pqr, String modif)
        {

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_registrar_pqr", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_desqueja", NpgsqlTypes.NpgsqlDbType.Varchar, 100).Value = EU_Pqr.Descripcion;
                command.Parameters.Add("_idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Pqr.IdEmpresa;
                command.Parameters.Add("_idmotivo", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Pqr.Motivo;
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

        public DataTable MostrarMotivosReporte()
        {
            DataTable Motivos = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_mostrar_motivoreporte", connection);
                command.CommandType = CommandType.StoredProcedure;


                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(Motivos);

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
            return Motivos;
        }

        public DataTable MostrarPQRAdministradorSqlServer()
        {
            DataTable PQR = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Modelo_SQL_Server"].ConnectionString);
            String strSql = "dbo.sp_mostrarpqradministrador";
            SqlDataAdapter adap = new SqlDataAdapter(strSql,con);
            try
            {
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                adap.Fill(PQR);
            }
            catch (Exception er) {
                throw er;
            }
            return PQR;

        }


        public DataTable MostrarPQRAdministrador()
        {
            DataTable PQR = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("dbo.sp_mostrarpqradministrador", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(PQR);

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
            return PQR;
        }

        public DataTable MostrarPQRAempresa()
        {
            DataTable PQR = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_mostrarpqrempresa", connection);
                command.CommandType = CommandType.StoredProcedure;


                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(PQR);

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
            return PQR;
        }
        //MIGRADO
        public DataTable MostrarPQRCliente()
        {
            DataTable PQR = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_mostrarpqrcliente", connection);
                command.CommandType = CommandType.StoredProcedure;


                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(PQR);

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
            return PQR;
        }
    }
}
