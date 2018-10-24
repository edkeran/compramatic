using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;
using NpgsqlTypes;

namespace Datos
{
    public class DDAOMembresia
    {
        //MIGRTADO
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
        //MIGRADO
        public DataTable MostrarTipos(int id)
        {
            DataTable Tipos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_tipo_membresia", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_id_tipo_membresia", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;


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

        //MIGRADO
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
    }
}
