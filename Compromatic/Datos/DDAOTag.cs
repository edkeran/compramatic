using System;
using Npgsql;
using System.Configuration;
using System.Data;
using Utilitarios;

namespace Datos
{
    public class DDAOTag
    {
        public void AgregarTag(UEUTag EU_Tag, String modif)
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
    }
}
