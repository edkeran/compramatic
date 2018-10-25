using System;
using System.Data;
using System.IO;
using DatosPersistencia;
using Utilitarios;

namespace Logica
{
    public class L_RegistroEmpresa
    {
        public String validar_session(Object Session)
        {
            if (Session != null)
            {
                return "LoginUsr.aspx";
            }
            return "0";
        }

        public DataTable mostrar_Membresia(int tipo)
        {
            DB_Membresia daoMembresia= new DB_Membresia();
            DataTable data = daoMembresia.mostrarTipos(tipo);
            return data;
        }

        public Boolean Validar_Existencia_Correo(String correo)
        {
            DBEmpresa db = new DBEmpresa();
            //DDAOEmpresa db = new DDAOEmpresa();
            return db.ExistenciaCorreo(correo);
        }

        //VALIDACIONES REGISTRAR EMPRESA
        public U_aux_reg_emp validar_extenciones(String extension, String pass1, String pass2, Boolean email)
        {
            U_aux_reg_emp res = new U_aux_reg_emp();
            if (!email)
            {
                if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
                {
                    if (pass1 != pass2)
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('Las Contraseñas no coinciden')</script>");
                        //return;
                        res.Valido = false;
                        res.Info = "Las Contraseñas no coinciden";
                    }
                    else
                    {
                        res.Valido = true;
                        res.Info = "";
                    }
                }
                else
                {
                    res.Valido = false;
                    res.Info = "Formato Invalido De Imagen.";
                }
            }
            else
            {
                res.Valido = false;
                res.Info = "El Correo Ingresado Ya Existe.";
            }
            return res;
        }

        //PUBLIC VOID CREAR EMPRESA
        public void CrearEmpresa(String nit, String nombre, String nomArchivo, String rutaArchivo, String numero,
            String direccion, String correo, String contraseña, int idTipo, String fechaFin, String fechaIncio, int idTipoMemebresia, String modif,Boolean data)
        {
            if (data) {
                //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
                UEUEmpresa EU_Empresa = new UEUEmpresa();
                EU_Empresa.Nit = nit;
                EU_Empresa.Nombre = nombre;
                EU_Empresa.NomArchivo = nomArchivo;
                EU_Empresa.RutaArchivo = rutaArchivo;
                EU_Empresa.Numero = numero;
                EU_Empresa.Direccion = direccion;
                EU_Empresa.Correo = correo;
                EU_Empresa.Contraseña = contraseña;
                EU_Empresa.IdTipo = idTipo;
                EU_Empresa.FechaFin = DateTime.Parse (fechaFin);
                EU_Empresa.FechaInicio = DateTime.Parse (fechaIncio);
                EU_Empresa.IdTipoMembresia = idTipoMemebresia;
                EU_Empresa.ModifBy = modif;
                DBEmpresa daoEmpresa = new DBEmpresa();
                daoEmpresa.InsertarEmpresa(EU_Empresa);
                //DAO_Empresa.CrearEmpresa(EU_Empresa, modif);
            }
        }

        public void guardar_imagen(Stream file,bool valido,String saveLocation)
        {
            if (valido)
            {
                //GUARDO LA IMAGEN DE LA NUEVA EMPRESA
                try
                {
                    //file.SaveAs(saveLocation);
                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        Stream inputStream = file;
                        inputStream.CopyTo(stream);
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }

            }
        }
    }
}
