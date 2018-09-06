using System;
using Utilitarios;
using Datos;
using System.Data;
using System.IO;

namespace Logica
{
    public class L_ModificarPerfilUsr
    {
        public UEUsuario page_loading(Object session)
        {
            UEUsuario user = new UEUsuario();
            if (session == null)
            {
                //Retorno A La Pagina Correspondiente
                user.Redireccion = "LoginUsr.aspx";
                return user;
            }
            else
            {
                DataTable datos = (DataTable)session;
                if (datos.Rows[0]["idTipo"].ToString() != "3")
                {
                    //RETORNO A LA PAGINA CORRESPONDIENTE
                    user.Redireccion = "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                    return user;
                }
                else
                {
                    //Crear Objeto Con La Informacion Del Usuario
                    user.NomArch = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
                    user.NomUsr = datos.Rows[0]["nomUsuario"].ToString();
                    user.ApelUsr = datos.Rows[0]["apeUsuario"].ToString();
                    user.TelUsr = datos.Rows[0]["telUsuario"].ToString();
                    user.CcUsr = datos.Rows[0]["ccUsuario"].ToString();
                    user.CorreoUsr = datos.Rows[0]["correoUsuario"].ToString();
                    user.DirUsr = datos.Rows[0]["dirUsuario"].ToString();
                    user.Redireccion = "0";
                    return user;
                }
            }
        }

        public U_Modificar_Pfi_Usr cambiar_informacion(DataTable datos,String correo,UEUsuario newInfo)
        {
            DDAOUsuario db = new DDAOUsuario();
            U_Modificar_Pfi_Usr response = new U_Modificar_Pfi_Usr();
            bool valido=true;
            if (db.ComprobarCorreo(correo) == 1)
            {
                //Ejecutar Mensaje Del Modal
                valido = false;
                response.Valido = valido;
                response.Datos = datos;
                response.Mensage = "El Correo Ingresado Ya Existe.";
                response.Pagina_redir = "0";
                return response;
            }
            else
            {
                //Nombre
                if (newInfo.NomUsr.Length != 0)
                {
                    datos.Rows[0]["nomUsuario"] = newInfo.NomUsr;
                }
                if (newInfo.NomUsr.Length == 0)
                {
                    newInfo.NomUsr = datos.Rows[0]["nomUsuario"].ToString();
                }
                //Apellido
                if (newInfo.ApelUsr.Length != 0)
                {
                    datos.Rows[0]["apeUsuario"]= newInfo.ApelUsr;
                }
                if (newInfo.ApelUsr.Length == 0)
                {
                    newInfo.ApelUsr = datos.Rows[0]["apeUsuario"].ToString();
                }
                //Telefono
                if (newInfo.TelUsr.Length != 0)
                {
                    datos.Rows[0]["telUsuario"] = newInfo.TelUsr;
                }
                if (newInfo.TelUsr.Length == 0)
                {
                    newInfo.TelUsr = datos.Rows[0]["telUsuario"].ToString();
                }
                //Cc
                if (newInfo.CcUsr.Length != 0)
                {
                    datos.Rows[0]["ccUsuario"] = newInfo.CcUsr;
                }
                if (newInfo.CcUsr.Length == 0)
                {
                    newInfo.CcUsr = datos.Rows[0]["ccUsuario"].ToString();
                }
                //Correo
                if (newInfo.CorreoUsr.Length != 0)
                {
                    datos.Rows[0]["correoUsuario"] = newInfo.CorreoUsr;
                }
                if (newInfo.CorreoUsr.Length == 0)
                {
                    newInfo.CorreoUsr = datos.Rows[0]["correoUsuario"].ToString();
                }
                //Direccion
                if (newInfo.DirUsr.Length != 0)
                {
                    datos.Rows[0]["dirUsuario"] = newInfo.DirUsr;
                }
                if (newInfo.DirUsr.Length == 0)
                {
                    newInfo.DirUsr = datos.Rows[0]["dirUsuario"].ToString();
                }
                //Ya Organizada La Informacion Se Procede A Actualizarla EN LA BD
                db.ModificarInf(newInfo, datos.Rows[0]["nomUsuario"].ToString());
                response.Valido = valido;
                response.Mensage = "Modificacion Exitosa";
                response.Datos = datos;
                response.Pagina_redir = "PerfilUsr.aspx";
                return response;
            }
        }
        //FUNCION PARA CAMBIAR LA IMAGEN DE USUARIO
        public U_Modificar_Pfi_Usr cambiar_foto(String saveLocation,Stream new_file,String extension,DataTable datos,String nombreArchivo,String SaveLocationAnt)
        {
            U_Modificar_Pfi_Usr response = new U_Modificar_Pfi_Usr();
            if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
            {
                String nomArchivoAnt = datos.Rows[0]["nomArchivo"].ToString();
                String[] aux = nomArchivoAnt.Split('.');
                nomArchivoAnt = aux[0];
                if (nomArchivoAnt == datos.Rows[0]["idUsuario"].ToString())
                {
                    System.IO.File.Delete(SaveLocationAnt);
                }
                try
                {
                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        Stream inputStream = new_file;
                        inputStream.CopyTo(stream);
                    }

                    //new_file.SaveAs(saveLocation);
                    DDAOUsuario foto = new DDAOUsuario();
                    UEUsuario user = new UEUsuario();
                    user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                    user.NomArch = nombreArchivo + extension;
                    foto.CambiarFoto(user, datos.Rows[0]["nomUsuario"].ToString());
                    datos.Rows[0]["nomArchivo"] = nombreArchivo + extension;
                    response.Datos = datos;
                    response.Pagina_redir = "PerfilUsr.aspx";
                    response.Mensage = "Actualizacion Exitosa";
                    return response;
                    //Session["Sesion"] = datos;
                    //Response.Redirect("PerfilUsr.aspx");
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            else
            {
                //IMAGEN INVALIDA Y POR LO TANTO DEBO CARGAR LA MISMA PAGINA
                response.Datos = datos;
                response.Mensage = "Formato Invalido";
                response.Pagina_redir = "0";
                return response;
            }
        }
        public void quitar_foto(UEUsuario user,String usuario)
        {
            DDAOUsuario foto = new DDAOUsuario();
            foto.CambiarFoto(user,usuario);
        }
    }
}
