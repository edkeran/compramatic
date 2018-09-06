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

namespace Datos
{
    public class DDAOPqr
    {
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
    }
}
