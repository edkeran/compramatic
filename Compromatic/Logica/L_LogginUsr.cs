using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;
using System.Collections.Generic;

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
                    aux_log.Id_empresa = Empresa.Rows[0]["idEmpresa"].ToString();
                    //actualizar sesion
                    DBEmpresa daoEmpresa = new DBEmpresa();
                    //DDAOEmpresa DB = new DDAOEmpresa();
                    int sess = int.Parse(Empresa.Rows[0]["Sesiones_Abiertas"].ToString());
                    if (int.Parse(Empresa.Rows[0]["intentos"].ToString()) >= 3)
                    {
                        aux_log.New_page = "LoginUsr.aspx";
                        aux_log.Modal_message = "Has Excedido El Numero De Intentos De Loggin Intentalo A Las "+ Empresa.Rows[0]["fin_bloqueo"].ToString();
                        aux_log.Datos = null;
                        aux_log.Id_empresa = null;
                        return aux_log;
                    }
                    if (sess < 3)
                    {
                        //llamar db
                        UEUEmpresa emp = new UEUEmpresa();
                        emp.Id = int.Parse(Empresa.Rows[0]["idEmpresa"].ToString());
                        emp.Sessiones = sess + 1;
                        Empresa.Rows[0]["Sesiones_Abiertas"]=emp.Sessiones;
                        daoEmpresa.update_session(emp);
                    }
                    else
                    {
                        aux_log.New_page = "LoginUsr.aspx";
                        aux_log.Modal_message = "Has Excedido el numero de sesiones abiertas";
                        aux_log.Datos = null;
                        aux_log.Id_empresa = null;
                    }
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
                //DDAOUsuario login = new DDAOUsuario();
                UEUsuario user = new UEUsuario();
                DBUsr db_usr = new DBUsr();
                user.PassUsr = pass;
                user.CorreoUsr = email;
                //LOGGING ANTIGUO
                DataTable datos = db_usr.loggin_user(user);
                if (datos.Rows.Count > 0)
                {
                    if ((seleccion == "2") && (datos.Rows[0]["idTipo"].ToString() == "1"))
                    {
                        U_aux_loggin aux_log = new U_aux_loggin();
                        aux_log.Datos = datos;
                        aux_log.Modal_message = "Bienvenido de nuevo administrador!";
                        aux_log.New_page = "PrincipalAdministrador.aspx";
                        int sess = int.Parse(datos.Rows[0]["Sesiones_Abiertas"].ToString());
                        //actualizar sesion
                        if (sess < 1)
                        {
                            //llamar db
                            UEUsuario usr = new UEUsuario();
                            DBUsr daoUser = new DBUsr();
                            //DDAOUsuario db = new DDAOUsuario();
                            usr.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                            usr.Sessiones = sess + 1;
                            daoUser.update_session(usr);
                            //REVISAR EL ULTIMO REPORTE DE LA SESSION PARA ELIMINAR EL REGISTRO SIEMPRE Y CUANDO HAYA PASADO MUCHO TIEMPO
                            update_session_usr(datos.Rows[0]["idUsuario"].ToString());
                        }
                        else
                        {
                            //MODIFICAR ESTO EN CASO DE QUE EL REPORTE SEA DEMASIADO TARDIO
                            bool ayu= update_session_usr(datos.Rows[0]["idUsuario"].ToString());
                            if (ayu)
                            {
                                return aux_log;
                            }
                            aux_log.New_page = "LoginUsr.aspx";
                            aux_log.Modal_message = "Has Excedido el numero de sesiones abiertas";
                            aux_log.Datos = null;
                            aux_log.Id_empresa = null;
                        }

                        return aux_log;
                    }
                    else if (int.Parse(datos.Rows[0]["estadoUsuario"].ToString()) == 0)
                    {
                        U_aux_loggin aux_log = new U_aux_loggin();
                        if (int.Parse(datos.Rows[0]["intentos"].ToString()) >= 3)
                        {
                            //NO LOGGUEAR
                            aux_log.New_page = "LoginUsr.aspx";
                            aux_log.Modal_message = "Has Excedido el numero de intentos de logueo intentalo a las " + datos.Rows[0]["fin_bloqueo"];
                            aux_log.Datos = null;
                            aux_log.Id_empresa = null;
                            return aux_log;
                        }
                        user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                        aux_log.Modal_message = "Qué bueno que regreses!";
                        db_usr.bloquear_cuenta(user, 1, "");
                        datos = db_usr.loggin_user(user);
                        aux_log.Datos = datos;
                        aux_log.New_page = "Home.aspx";
                        int sess = int.Parse(datos.Rows[0]["Sesiones_Abiertas"].ToString());
                        //actualizar sesion
                        if (sess < 3)
                        {
                            //ACTUALIZAR LAS SESSIONES 
                            update_session_usr(datos.Rows[0]["idUsuario"].ToString());
                            //llamar db
                            UEUsuario usr = new UEUsuario();
                            DBUsr db = new DBUsr();
                            //DDAOUsuario db = new DDAOUsuario();
                            usr.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                            usr.Sessiones = sess + 1;
                            db.update_session(usr);
                        }
                        else
                        {
                            //VERIFICAR SI LAS SESIONES AUN SON VALIDAS
                            bool ayu = update_session_usr(datos.Rows[0]["idUsuario"].ToString());
                            if (ayu)
                            {
                                return aux_log;
                            }
                            aux_log.New_page = "LoginUsr.aspx";
                            aux_log.Modal_message = "Has Excedido el numero de sesiones abiertas";
                            aux_log.Datos = null;
                            aux_log.Id_empresa = null;
                        }

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
                            int sess = int.Parse(datos.Rows[0]["Sesiones_Abiertas"].ToString());
                            if (int.Parse(datos.Rows[0]["intentos"].ToString()) >= 3)
                            {
                                //DEBO RETORNAR NULOS Y UN MENSAJE DE ERROR
                                aux_log.New_page = "LoginUsr.aspx";
                                aux_log.Modal_message = "Tu Cuenta Ha Tenido Demasiados Intentos Erroneo Intentalo a Las "+ datos.Rows[0]["fin_bloqueo"].ToString();
                                aux_log.Datos = null;
                                aux_log.Id_empresa = null;
                                return aux_log;
                            }
                            //actualizar session
                            if (sess < 3)
                            {
                                //llamar db
                                UEUsuario usr = new UEUsuario();
                                DBUsr db = new DBUsr();
                                //DDAOUsuario db = new DDAOUsuario();
                                usr.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                                usr.Sessiones = sess + 1;
                                db.update_session(usr);
                                update_session_usr(datos.Rows[0]["idUsuario"].ToString());
                            }
                            else
                            {
                                bool ayu = update_session_usr(datos.Rows[0]["idUsuario"].ToString());
                                if (ayu)
                                {
                                    return aux_log;
                                }
                                aux_log.New_page = "LoginUsr.aspx";
                                aux_log.Modal_message = "Has Excedido el numero de sesiones abiertas";
                                aux_log.Datos = null;
                                aux_log.Id_empresa = null;
                            }

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
                    DBUsr db = new DBUsr();
                    //DDAOUsuario db = new DDAOUsuario();
                    DataTable data = db.GET_USER(email);
                    if (data.Rows.Count > 0)
                    {
                        //AUMENTAR BLOQUEO
                        DateTime hora_incio = DateTime.Now;
                        DateTime hora_fin = hora_incio.AddMinutes(30);
                        int intentos = int.Parse(data.Rows[0]["intentos"].ToString());
                        intentos = intentos + 1;
                        db.UPDATE_BLOQUEO(email, hora_incio, hora_fin, intentos);
                    }
                    U_aux_loggin aux_log = new U_aux_loggin();
                    aux_log.Modal_message = "La contraseña y/o el correo no coinciden.";
                    return aux_log;
                }
            }
        }

        //FUNCION AUXILIAR
        private DataTable Login(String correo, String contraseña)
        {
            DBEmpresa daoEmpresa = new DBEmpresa();
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Correo = correo;
            EU_Empresa.Contraseña = contraseña;
            DataTable Datos = daoEmpresa.LoginEmpresa(EU_Empresa);
            //Codigo Nuevo Para El Caso Del Bloqueo
            DataTable res= daoEmpresa.GET_EMP(correo);
            if (Datos.Rows.Count <= 0)
            {
                if (res.Rows.Count > 0)
                {
                    //AUMENTAR INTENTOS
                    int intentos=int.Parse(res.Rows[0]["intentos"].ToString());
                    intentos = intentos + 1;
                    DateTime hora_inicio = DateTime.Now;
                    DateTime hora_fin = hora_inicio.AddMinutes(30);
                    daoEmpresa.UPDATE_BLOQUEO(correo, hora_inicio, hora_fin, intentos);
                }
            }
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

        public bool update_session_usr(string id_user)
        {
            DB_Session daoSession = new DB_Session();
            List<UEUSession> data = daoSession.obtener_sessiones_reportes_usr(id_user);
            bool retorno=false;
            if (data != null)
            {
                List<UEUSession> delete = new List<UEUSession>();
                foreach (UEUSession aux in data)
                {
                    TimeSpan dif = DateTime.Now - aux.Fecha_fin_new;
                    if (dif.TotalSeconds > 90)
                    {
                        delete.Add(aux);
                        retorno = true;
                    }
                }
                //ELIMINAR DATOS
                foreach (UEUSession aux in delete)
                {
                    data.Remove(aux);
                }

                if (data.Count == 0)
                {
                    data = null;
                }
                daoSession.update_sessiones_usr(data, id_user);
                return retorno;
            }
            else
            {
                return true;
            }
        }

    }
}
