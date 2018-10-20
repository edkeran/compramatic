using System;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;
using Utilitarios;

namespace Datos
{
    public class DDAOadministrador
    {
        //MIGRADO
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

        public DataTable MostrarClientes(int idBusqueda)
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrarcliente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("idconsulta", NpgsqlTypes.NpgsqlDbType.Integer).Value = idBusqueda;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        //MIGRADO
        public DataTable MostrarTotalClientes()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrartotalcliente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        //MIGRADO
        public DataTable MostrarTotalVentas()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrartotalventas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        //MIGRADO
        public DataTable MostrarTotalEmpresas()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrartotalempresas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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

        public DataTable MostrarEmpresas(int idBusqueda)
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrarempresa", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("idconsulta", NpgsqlTypes.NpgsqlDbType.Integer).Value = idBusqueda;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        //MIGRADO
        public DataTable LlenarNotificacion()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_llenarnotificacion", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public DataTable LlenarNotificacionAceptadas()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_llenarnotificacionaceptadas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public DataTable LlenarNotificacionRechazada()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_llenarnotificacionrechazadas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public DataTable MostrarMembresias()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_Tipo_membresia", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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

        public DataTable SolicitudesPendientes()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_solicitudespendientes", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public DataTable SolicitudesAceptadas()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_solicitudesaceptadas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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

        public DataTable SolicitudesRechazadas()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_solicitudesrechazadas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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

        public DataTable ArchivosEmpresa(int id)
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrararchivos_cargadosempresa", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        //MIGRADFO
        public void ModificarEstados(int id, int estadoEmpresa, int estadoSolicitud, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_modificarestadoempresa", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                comando.Parameters.Add("estadosolicitud", NpgsqlTypes.NpgsqlDbType.Integer).Value = estadoSolicitud;
                comando.Parameters.Add("estadoempresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = estadoEmpresa;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }

        public DataTable MostrarVentasPorEmpresa()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrarventasporempresa", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public DataTable MostrarVentasPorCategoria()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrarresultadoscategoria", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public DataTable MostrarCategorias()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrar_categoria", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public void registrarCategoria(String nomCategoria, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_registrarcategoria", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nomcategoria", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nomCategoria;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        public void registrarMembresia(String nomCategoria, int tiempo, double valor, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_registrarmembresia", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nomCategoria;
                comando.Parameters.Add("tiempo", NpgsqlTypes.NpgsqlDbType.Integer).Value = tiempo;
                comando.Parameters.Add("valor", NpgsqlTypes.NpgsqlDbType.Double).Value = valor;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        public void registrarQueja(String nom, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_registrarqueja", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nom", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nom;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        public void registrarReporte(String nom, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_registrarreporte", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nom", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nom;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        //METODO MIGRADO
        public DataTable verificarCategoria(String nomCategoria)
        {
            DataTable Consulta = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_verificarcategoria", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nomcategoria", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nomCategoria;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Consulta);
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
            return Consulta;
        }
        //MIGRADO
        public DataTable verificarMembresia(String nomMembresia)
        {
            DataTable Consulta = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_verificarmembresia", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nommembresia", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nomMembresia;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Consulta);
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
            return Consulta;
        }

        //METODO MIGRADO
        public DataTable verificarQueja(String nomQueja)
        {
            DataTable Consulta = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_verificarqueja", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nomqueja", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nomQueja;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Consulta);
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
            return Consulta;
        }
        //MIGRADO
        public DataTable verificarReporte(String nomReporte)
        {
            DataTable Consulta = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_verificarreporte", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nomreporte", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nomReporte;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Consulta);
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
            return Consulta;
        }
        //MIGRADO
        public DataTable Reportes()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrarreportes", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        //MIGRADO
        public DataTable Membresia()
        {
            DataTable Usuario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_mostrarmembresia", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(comando);
                dataAdapter.Fill(Usuario);

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
        public void ModificarCategorias(String nom, String ant, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_modificarcategoria", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nom", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nom;
                comando.Parameters.Add("ant", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ant;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        public void ModificarMembresia(String nom, String ant, int dur, Double valor, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_modificarmembresia", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nom", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nom;
                comando.Parameters.Add("duracion", NpgsqlTypes.NpgsqlDbType.Integer).Value = dur;
                comando.Parameters.Add("valor", NpgsqlTypes.NpgsqlDbType.Double).Value = valor;
                comando.Parameters.Add("ant", NpgsqlTypes.NpgsqlDbType.Varchar).Value = ant;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        public void ModificarMotivoQueja(String nom, int id, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_modificarmotivoqueja", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nom", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nom;
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
        public void ModificarMotivoReporte(String nom, int id, String usuario)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
            try
            {
                conexion.Open();
                NpgsqlCommand comando = new NpgsqlCommand("sp_modificarmotivoreporte", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nom", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nom;
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
                comando.ExecuteNonQuery();
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
        }
    }
}
