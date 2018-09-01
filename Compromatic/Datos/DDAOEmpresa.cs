using System;
using System.Data;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;

namespace Datos
{
    public class DDAOEmpresa
    {
        public Boolean ExistenciaCorreo(String correo)
        {
            Boolean existencia;
            DataTable Correo = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_existencia_empresa", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_correo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = correo;
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(Correo);
                existencia = bool.Parse(Correo.Rows[0][0].ToString());

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
                connection = null;
            }
            return existencia;
        }


        public DataTable LoginEmpresa(UEUEmpresa EU_Empresa)
        {
            DataTable Empresa = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_login_empresa", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_correo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Correo;
                command.Parameters.Add("_contraseña", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Contraseña;

                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(Empresa);

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
            return Empresa;
        }
        //METODO PARA CREAR UNA NUEVA EMPRESA
        public void CrearEmpresa(UEUEmpresa EU_Empresa, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_registro_empresa", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_nombreempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nombre;
                command.Parameters.Add("_telempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Numero;
                command.Parameters.Add("_correoempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Correo;
                command.Parameters.Add("_dirempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Direccion;
                command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
                command.Parameters.Add("_nomarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.NomArchivo;
                command.Parameters.Add("_rutaarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.RutaArchivo;
                command.Parameters.Add("_idtipo", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.IdTipo;
                command.Parameters.Add("_contraseña", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Contraseña;
                command.Parameters.Add("_fechainicio", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = EU_Empresa.FechaInicio;
                command.Parameters.Add("_fechafin", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = EU_Empresa.FechaFin;
                command.Parameters.Add("_idtipo_membresia", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.IdTipoMembresia;



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

        //METODO PARA CAMBIAR LA CONTRASEÑA DE LA EMPRESA
        public void CambiarContraseña(UEUEmpresa EU_Empresa, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_cambiar_contraseña_empresa", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
                command.Parameters.Add("_passempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Contraseña;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
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
        //METODO PARA ACTUALIZAR LOS DATOS DE LA EMPRESA
        public void ModificarEmpresa(UEUEmpresa EU_Empresa, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_modificar_empresa", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("idempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = EU_Empresa.Id;
                command.Parameters.Add("nombreempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nombre;
                command.Parameters.Add("telempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Numero;
                command.Parameters.Add("correoempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Correo;
                command.Parameters.Add("dirempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Direccion;
                command.Parameters.Add("nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
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
        //METODO PARA GUARDAR LOS ARCHIVOS DE LA EMPRESA
        public void SubirArchivo(UEUEmpresa EU_Empresa, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_registro_archivo_empresa", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
                command.Parameters.Add("_rutaarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.RutaArchivo;
                command.Parameters.Add("_nombrearchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.NomArchivo;
                command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;

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
        //Metodo para actualiza la Foto De la BD
        public void CambiarFoto(UEUEmpresa EU_Empresa, String modif)
        {
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conection.Open();
                NpgsqlCommand command = new NpgsqlCommand("sp_cambiar_foto_empresa", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_nitempresa", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.Nit;
                command.Parameters.Add("_nomarchivo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = EU_Empresa.NomArchivo;
                command.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
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
    }
}
