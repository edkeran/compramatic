using System;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_LogginUsr
    {
        //Nuevo Logging Reingeniado XD
        public U_aux_loggin Loggin(String seleccion,String email, String pass)
        {
            if (seleccion == "0")
            {
                DataTable Empresa = this.Login(email,pass);

                if (Empresa.Rows.Count > 0)
                {
                    //Retornar Datos 
                    U_aux_loggin aux_log = new U_aux_loggin();
                    aux_log.Datos = Empresa;
                    //La Variable Empresa Va A Session Al Igual Que Su ID
                    aux_log.New_page = "PerfilEmpresa.aspx";
                    aux_log.Modal_message = "Acceso Concebido";
                    aux_log.Id_empresa= Empresa.Rows[0]["idEmpresa"].ToString();
                    return aux_log;

                }
                else
                {
                    //Retornar Datos
                    U_aux_loggin aux_log = new U_aux_loggin();
                    aux_log.Modal_message = "La contraseña y/o el correo no coinciden.";
                    return aux_log;
                }

            }
            else
            {
                DDAOUsuario login = new DDAOUsuario();
                UEUsuario user = new UEUsuario();
                user.PassUsr = pass;
                user.CorreoUsr = email;
                DataTable datos = login.Login(user);
                if (datos.Rows.Count > 0)
                {
                    if ((seleccion == "2") && (datos.Rows[0]["idTipo"].ToString()=="1"))
                    {
                        U_aux_loggin aux_log = new U_aux_loggin();
                        aux_log.Datos = datos;
                        aux_log.Modal_message = "Bienvenido de nuevo administrador!";
                        aux_log.New_page = "PrincipalAdministrador.aspx";
                        return aux_log;
                    }
                    else if (int.Parse(datos.Rows[0]["estadoUsuario"].ToString()) == 0)
                    {
                        user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                        U_aux_loggin aux_log = new U_aux_loggin();
                        aux_log.Modal_message = "Qué bueno que regreses!";
                        login.BloqueoUser(user, 1, "");
                        datos = login.Login(user);
                        aux_log.Datos = datos;
                        aux_log.New_page = "Home.aspx";
                        return aux_log;
                    }
                    else if (int.Parse(datos.Rows[0]["estadoUsuario"].ToString()) == 1 && datos.Rows[0]["idTipo"].ToString() == "3")
                    {
                        String test = datos.Rows[0]["idUsuario"].ToString();
                        if ((seleccion == "2") && (datos.Rows[0]["idTipo"].ToString() == "3")) {
                            U_aux_loggin aux_log = new U_aux_loggin();
                            aux_log.Datos = null;
                            aux_log.Modal_message = "Esta Ingresando Desde Un Rol Que No Le Corresponde";
                            aux_log.New_page = "Home.aspx";
                            return aux_log;
                        }
                        else
                        {
                            U_aux_loggin aux_log = new U_aux_loggin();
                            aux_log.Datos = datos;
                            aux_log.Modal_message = "Bienvenido De Nuevo Es Un Placer Volver A Verte";
                            aux_log.New_page = "Home.aspx";
                            return aux_log;
                        }
                    }
                    else
                    {
                        U_aux_loggin aux_log = new U_aux_loggin();
                        aux_log.Modal_message = "Estas bloqueado por un tiempo, regresa cuando acabe tu sansion.";
                        return aux_log;

                    }
                }
                else
                {
                    U_aux_loggin aux_log = new U_aux_loggin();
                    aux_log.Modal_message = "La contraseña y/o el correo no coinciden.";
                    return aux_log;
                }
            }
        }

        //FUNCION AUXILIAR
        private DataTable Login(String correo, String contraseña)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Correo = correo;
            EU_Empresa.Contraseña = contraseña;
            DataTable Datos = DAO_Empresa.LoginEmpresa(EU_Empresa);
            return Datos;
        }

        public string validar_session(Object valid,bool post){
            if (!post)
            {
                if (valid != null)
                {
                    DataTable validacion = (DataTable)valid;
                    if (validacion.Rows[0]["idTipo"].ToString() == "2")
                    {
                        return "PerfilEmpresa.aspx";
                    }
                    if (validacion.Rows[0]["idTipo"].ToString() == "1")
                    {
                        return "PrincipalAdministrador.aspx";
                    }
                    if (validacion.Rows[0]["idTipo"].ToString() == "3")
                    {
                        return "PerfilUsr.aspx";
                    }
                }
                else return "0";
            }
            return "0";
        }


    }
}
