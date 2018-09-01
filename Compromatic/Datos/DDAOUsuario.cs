using System;
using System.Data;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;

namespace Datos
{
    public class DDAOUsuario
    {
        //FUNCION PARA REGISTRAR A UN NUEVO USUARIo
        public void RegistrarUsuario(UEUsuario user, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_registrar_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_nomusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.NomUsr;
                comando.Parameters.Add("_apeusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.ApelUsr;
                comando.Parameters.Add("_telusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.TelUsr;
                comando.Parameters.Add("_correousr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CorreoUsr;
                comando.Parameters.Add("_passusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.PassUsr;
                comando.Parameters.Add("_ccusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CcUsr;
                comando.Parameters.Add("_dirusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.DirUsr;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;

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

        //FUNCION PARA EL LOGGIN DEL USUARIO
        public DataTable Login(UEUsuario user)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("sp_login_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_correousr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CorreoUsr;
                comando.Parameters.Add("_passusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.PassUsr;

                conexion.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(comando);
                adapter.Fill(Usuario);

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
            return Usuario;
        }

        //FUNCION QUE BLOQUEA AL USUARIO
        public void BloqueoUser(UEUsuario user, int est, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_bloquear_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = user.IdUsr;
                comando.Parameters.Add("_est", NpgsqlTypes.NpgsqlDbType.Integer).Value = est;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
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

        //FUNCION QUE COMPRUEBA LOS EMAIL
        public int ComprobarCorreo(String correo)
        {
            int existencia;
            DataTable Correo = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_comprobarcorreo_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("_correousr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = correo;
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(Correo);
                if (Correo.Rows.Count == 0)
                {
                    existencia = 0;
                }
                else
                {
                    existencia = 1;
                }
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
            return existencia;
        }

        //Metodo Para Modificar La Informacion Del Usuario
        public void ModificarInf(UEUsuario user, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_modificar_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = user.IdUsr;
                comando.Parameters.Add("_nomusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.NomUsr;
                comando.Parameters.Add("_apeusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.ApelUsr;
                comando.Parameters.Add("_telusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.TelUsr;
                comando.Parameters.Add("_ccusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CcUsr;
                comando.Parameters.Add("_correousr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CorreoUsr;
                comando.Parameters.Add("_dirusr", NpgsqlTypes.NpgsqlDbType.Varchar, 30).Value = user.DirUsr;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;

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
        //Metodo Para Cambiar La Imagen de Un Usuario
        public void CambiarFoto(UEUsuario user, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_cambiarfoto_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = user.IdUsr;
                comando.Parameters.Add("_nomarch", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.NomArch;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
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
        //Metodo Para Cambiar La Contraseña
        public void CambiarPass(UEUsuario user, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_cambiarpass_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = user.IdUsr;
                comando.Parameters.Add("_passusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.PassUsr;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
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
        //Metodo Para Obtener El Historial De Compras Del Usuario
        public DataTable HistorialCompras(UEUsuario user, int estado)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("sp_obtener_historial_com", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = user.IdUsr;
                comando.Parameters.Add("estado", NpgsqlTypes.NpgsqlDbType.Integer).Value = estado;
                conexion.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(comando);
                adapter.Fill(Usuario);

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
            return Usuario;
        }
        //Metodo Para  Registrar La Nueva Puntuacion Hacia La Empresa
        public void RegistrarRango(UEURango rango, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_calificar_empresa_rango", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idemp", NpgsqlTypes.NpgsqlDbType.Integer).Value = rango.IdEmp;
                comando.Parameters.Add("_calif", NpgsqlTypes.NpgsqlDbType.Double).Value = rango.Rango;
                comando.Parameters.Add("_comentario", NpgsqlTypes.NpgsqlDbType.Varchar).Value = rango.Comentario;
                comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = rango.IdUsr;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
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
        //METODO PARA CALIFICAR A LA EMPRESA
        public void CalificarEmp(UEUEmpresa emp, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_calificar_empresa", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idemp", NpgsqlTypes.NpgsqlDbType.Integer).Value = emp.Id;
                comando.Parameters.Add("_calif", NpgsqlTypes.NpgsqlDbType.Double).Value = emp.Calificacion;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
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

        //BLOQUEAR A LA EMPRESA SI RECIBE UNA PESIMA PUNTUACION
        public void CambiarEstadoEmp(int emp, int est, String modif)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_bloquear_empresa", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("_idemp", NpgsqlTypes.NpgsqlDbType.Integer).Value = emp;
                comando.Parameters.Add("_est", NpgsqlTypes.NpgsqlDbType.Integer).Value = est;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = modif;
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

        //FUNCION PARA OBTENER LOS ULTIMOS PRODUCTOS VISITADOS POR EL USUARIO
        public DataTable ObtenerTopTen(int usr)
        {
            DataTable topten = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("sp_obtener_top_10", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = usr;
                conexion.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(comando);
                adapter.Fill(topten);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return topten;
        }
    }
}
