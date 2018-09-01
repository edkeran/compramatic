using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;

namespace Datos
{
    public class DDAOadministrador
    {

        public DataTable MostrarEmpresaId(int id)
        {
            DataTable Empresa = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrar_empresa_id", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idemp", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Empresa);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return Empresa;
        }
    }
}
