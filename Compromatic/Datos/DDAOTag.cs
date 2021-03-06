﻿using System;
using Npgsql;
using System.Configuration;
using System.Data;
using Utilitarios;

namespace Datos
{
    public class DDAOTag
    {
        public DataTable MostrarTags(UEUTag EU_Tag)
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

        public void EliminarTag(UEUTag EU_Tag, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("sp_borrar_palabraclave", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_idpalabra", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Tag.IdTag;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
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
