using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


public class DAOUsuario
{
	public DAOUsuario()
	{}
    //METODO MIGRADO
    public void RegistrarUsuario(EUsuario user,String usuario)
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
    //MIGRADO
    public void Bloquear_producto(String usuario, int id)
    {
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            conexion.Open();
            NpgsqlCommand comando = new NpgsqlCommand("sp_bloquear_producto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("_modif", NpgsqlTypes.NpgsqlDbType.Text).Value = usuario;
            comando.Parameters.Add("_idproducto", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            

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
    //METODO MIGRADO
    public void RegistrarRango(EURango rango,String usuario) 
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

    //METODO MIGRADO
    public void Top10(int pdto, int usr,String usuario)
    {
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            conexion.Open();
            NpgsqlCommand comando = new NpgsqlCommand("sp_top_diez", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("_idpdto", NpgsqlTypes.NpgsqlDbType.Integer).Value = pdto;
            comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = usr;
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
    //MIGRADO
    public void ReportarProducto(int motivo, int usr, int pdto,String usuario)
    {
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            conexion.Open();
            NpgsqlCommand comando = new NpgsqlCommand("sp_registrar_reporte_producto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("_idmotivo", NpgsqlTypes.NpgsqlDbType.Integer).Value = motivo;
            comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = usr;
            comando.Parameters.Add("_idpdto", NpgsqlTypes.NpgsqlDbType.Integer).Value =pdto;
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
    //METOTO MIGRADO
    public DataTable Login(EUsuario user)
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


    //FUNCION MIGRADA
   public int ComprobarCorreo(String correo)
    {
        int existencia;
        DataTable Correo = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

        try
        {
            NpgsqlCommand command = new NpgsqlCommand("sp_comprobarcorreo_usuario", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_correousr",NpgsqlTypes.NpgsqlDbType.Varchar).Value=correo;
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
        catch(Exception e)
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
    //MIGRADO
   public int ComprobarReporte(int idusr, int idpdto)
   {
       int existencia;
       DataTable Reporte = new DataTable();
       NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);

       try
       {
           NpgsqlCommand command = new NpgsqlCommand("sp_comprobar_reporte_usuario", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value = idusr;
           command.Parameters.Add("_idpdto", NpgsqlTypes.NpgsqlDbType.Integer).Value = idpdto;
           connection.Open();
           NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
           adapter.Fill(Reporte);
           if (Reporte.Rows.Count == 0)
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

   //Metodo Migrado
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
    //Metodo Migrado
    public DataTable HistorialCompras(EUsuario user, int estado)
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
    //METODO MIGRADO
    public void CalificarEmp(EUEmpresa emp,String usuario)
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
    //METODO MIGRADO
    public void ModificarInf(EUsuario user,String usuario)
    {
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgresql"].ConnectionString);
        try
        {
            conexion.Open();
            NpgsqlCommand comando = new NpgsqlCommand("sp_modificar_usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("_idusr", NpgsqlTypes.NpgsqlDbType.Integer).Value =user.IdUsr;
            comando.Parameters.Add("_nomusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.NomUsr;
            comando.Parameters.Add("_apeusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.ApelUsr;
            comando.Parameters.Add("_telusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.TelUsr;
            comando.Parameters.Add("_ccusr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CcUsr;
            comando.Parameters.Add("_correousr", NpgsqlTypes.NpgsqlDbType.Varchar).Value = user.CorreoUsr;
            comando.Parameters.Add("_dirusr", NpgsqlTypes.NpgsqlDbType.Varchar,30).Value = user.DirUsr;
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
    //Metodo Migrado
    public void CambiarPass(EUsuario user,String usuario)
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
        catch( Exception e )
        {
            throw e;
        }
        finally
        {
            conexion.Close();
        }
    }
    //METODO MIGRADO
    public void CambiarFoto(EUsuario user, String usuario)
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
        catch(Exception e)
        {
            throw e;
        }
        finally
        {
            conexion.Close();
        }
    }
    //METODO MOVIDO A DDAOUsuario
    public void BloqueoUser(EUsuario user, int est, String usuario)
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
    //METODO MIGRADO
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
}