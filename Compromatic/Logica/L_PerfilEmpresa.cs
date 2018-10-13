using System;
using System.Data;
using Utilitarios;
using Datos;
using System.IO;
using DatosPersistencia;

namespace Logica
{
    public class L_PerfilEmpresa
    {
        //Logica Del Page Load
        public UEUEmpresa page_load(bool post,Object Session)
        {
            UEUEmpresa response = new UEUEmpresa();
            if (!post)
            {
                if (Session == null)
                {
                    //Retrono a esta url
                    response.Redireccion = "LoginUsr.aspx";
                    return response;
                    //Response.Redirect("LoginUsr.aspx");
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    //Retornar Esta URL
                    response.Redireccion = "LoginUsr.aspx";
                    return response;
                    //Response.Redirect("LoginUsr.aspx");
                }
                else
                {
                    //Retorno Los Datos
                    response.RutaArchivo = Empresa.Rows[0]["rutaArchivo"].ToString();
                    response.NomArchivo= Empresa.Rows[0]["nomArchivo"].ToString();
                    response.Nit= Empresa.Rows[0]["nitEmpresa"].ToString();
                    response.Nombre= Empresa.Rows[0]["nomEmpresa"].ToString();
                    response.Numero= Empresa.Rows[0]["telEmpresa"].ToString();
                    response.Correo= Empresa.Rows[0]["correoEmpresa"].ToString();
                    response.Direccion = Empresa.Rows[0]["dirEmpresa"].ToString();
                    response.Redireccion = "0";
                    return response;
                }
            }
            else
            {
                //No Hago Nada O Una Excepcion Segun Sea El Caso
                throw new System.ArgumentException("No Debo Cambiar Ningun Campo", "New Ex");
            }
        }

        public String cambiarContraseña(String Contra1,String Contra2,DataTable Empresa,String OldPss,String oldConfPass,String nit)
        {
            if (Contra1 != Contra2)
            {
                //Modal("Las Contraseñas no coinciden");
               return "Las Contraseñas no coinciden";
            }
            if (!oldConfPass.Equals(OldPss))
            {
                //Modal("Contraseña Incorrecta");
                return "Contraseña Incorrecta";
            }
            this.CambiarContraseña(nit, Contra1, Empresa.Rows[0]["nomEmpresa"].ToString(),Empresa.Rows[0]["idEmpresa"].ToString());
            return "Cambio Exitoso";
        }

        private void CambiarContraseña(String nit, String contraseña, String modif,String id_emp)
        {
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.Id = int.Parse(id_emp);
            EU_Empresa.Contraseña = contraseña;
            //CAMBIAR POR EL NUEVO METODO 
            DBEmpresa daoEmp = new DBEmpresa();
            EU_Empresa.ModifBy = modif;
            daoEmp.actualizar_contrasena_empresa(EU_Empresa);
            //DAO_Empresa.CambiarContraseña(EU_Empresa, modif);
        }

        public U_aux_PerfilEmp ModificarDatos(DataTable Empresa,String tb_correo,String tb_nombre,String tb_nit,String tb_telefono,String tb_direccion,String urlRedir)
        {
            U_aux_PerfilEmp response = new U_aux_PerfilEmp();
            DBEmpresa daoEmp = new DBEmpresa();
            //DDAOEmpresa envio = new DDAOEmpresa();
            if (Empresa.Rows[0]["correoEmpresa"].ToString() != tb_correo)
            {
                if (daoEmp.ExistenciaCorreo(tb_correo))
                {
                    //Modal("Correo Existente");
                    response.Mensage = "Correo Existente";
                    response.Data = Empresa;
                    response.Response = "0";
                    return response;
                }
            }
            UEUEmpresa datos = new UEUEmpresa();
            DBEmpresa daoEmpresa = new DBEmpresa();
            datos.Nombre = tb_nombre;
            datos.Nit = tb_nit;
            datos.Numero = tb_telefono;
            datos.Correo = tb_correo;
            datos.Direccion = tb_direccion;
            datos.Id = int.Parse(Empresa.Rows[0]["idEmpresa"].ToString());
            datos.ModifBy = datos.Nombre;
            //envio.ModificarEmpresa(datos, datos.Nombre);
            daoEmpresa.update_Empresa(datos);
            this.login(tb_correo, Empresa.Rows[0]["passEmpresa"].ToString());
            response.Data= this.login(tb_correo, Empresa.Rows[0]["passEmpresa"].ToString());
            response.Mensage = "Actualizacion Exitosa";
            response.Response = urlRedir;
            return response;
        }

        private DataTable login(String correo, String contraseña)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Correo = correo;
            EU_Empresa.Contraseña = contraseña;
            DataTable Datos = DAO_Empresa.LoginEmpresa(EU_Empresa);
            return Datos;
        }

        public String btn_SubirArchivo(int rows,DataTable Empresa,String extension,String nomArch,String saveLocation,String nit,Stream archivo)
        {
            if (rows >= 3)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('Numero Excedido')</script>");
                return "Numero Excedido";
            }
            DateTime Fecha = DateTime.Now.Date;
            if (extension.Equals(".pdf"))
            {
                this.subir_file(nit, nomArch, "../Archivos/DocumentosEmpresa/", Empresa.Rows[0]["nomEmpresa"].ToString());

                try
                {
                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        Stream inputStream = archivo;
                        inputStream.CopyTo(stream);
                    }
                }
                catch (Exception exp)
                { throw exp; }
                throw new System.ArgumentException("Deseo Ejecutar La Linea De Abajo", "original");
                //Server.TransferRequest(Request.Url.AbsolutePath, false);

            }
            else
            {
                //Modal("Formato Invalido");
                return "Formato Invalido";
            }
        }

        private void subir_file(String nit, String nombreArchivo, String rutaArchivo, String modif)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.RutaArchivo = rutaArchivo;
            EU_Empresa.NomArchivo = nombreArchivo;
            DAO_Empresa.SubirArchivo(EU_Empresa, modif);
        }

        public U_aux_PerfilEmp BTN_CambiarFoto_Click(String extension,String extensionAnterior,String saveLocationAnterior,String nit,String nombreArchivo,DataTable datos,String saveLocation, Stream archivo,String redir)
        {
            U_aux_PerfilEmp res = new U_aux_PerfilEmp();
            if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
            {

                if (!extensionAnterior.Equals(extension))
                {
                    //String saveLocationAnterior = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo + extensionAnterior);
                    System.IO.File.Delete(saveLocationAnterior);
                    //IADEmpresa IAD_Empresa = new IADEmpresa();
                    this.CambiarFoto(nit, nombreArchivo + extension, datos.Rows[0]["nomEmpresa"].ToString());
                }
                else
                {
                    System.IO.File.Delete(saveLocation);
                }

                try
                {
                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        Stream inputStream = archivo;
                        inputStream.CopyTo(stream);
                    }
                    datos.Rows[0]["nomArchivo"] = nombreArchivo + extension;
                    res.Data = datos;
                    res.Mensage = "Actualizacion Exitosa";
                    res.Response = redir;
                    return res;
                    //Session["Sesion"] = datos;
                    //Response.Redirect(Request.RawUrl);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            else
            {
                //Modal("Formato Invalido");
                res.Data = datos;
                res.Mensage = "Formato Invalido";
                res.Response = "0";
                return res;
            }
        }

        //UPDATE PICTURE
        private void CambiarFoto(String nit, String nomArchivo, String modif)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.NomArchivo = nomArchivo;
            DAO_Empresa.CambiarFoto(EU_Empresa, modif);
        }

        public String traer_old_pass_empresa(int id)
        {
            UEUEmpresa emp = new UEUEmpresa();
            emp.Id = id;
            DBEmpresa daoEmpre = new DBEmpresa();
            UEUEmpresa res = daoEmpre.traer_empresa_actual(emp);
            return res.Contraseña;
        }

        public void delete_file(int id)
        {
            DBEmpresa daoEmpresa = new DBEmpresa();
            daoEmpresa.delete_file(id);
        }
    }
}
