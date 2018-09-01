using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IADUsuario
/// </summary>
    public class IADEmpresa
    {
        
        //METODO MIGRADO
        public void CrearEmpresa(String nit, String nombre, String nomArchivo, String rutaArchivo, String numero,
            String direccion, String correo, String contraseña , int idTipo,String fechaFin, String fechaIncio, int idTipoMemebresia, String modif)
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            EUEmpresa EU_Empresa = new EUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.Nombre = nombre;
            EU_Empresa.NomArchivo = nomArchivo;
            EU_Empresa.RutaArchivo = rutaArchivo;
            EU_Empresa.Numero = numero;
            EU_Empresa.Direccion = direccion;
            EU_Empresa.Correo = correo;
            EU_Empresa.Contraseña = contraseña;
            EU_Empresa.IdTipo = idTipo;
            EU_Empresa.FechaFin = fechaFin;
            EU_Empresa.FechaInicio = fechaIncio;
            EU_Empresa.IdTipoMembresia = idTipoMemebresia;
            DAO_Empresa.CrearEmpresa(EU_Empresa, modif);
        }
        
       //METODO MOVIDO A L_Loggin y a L_PerfilEmpresa
        public DataTable Login(String correo,String contraseña)
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            EUEmpresa EU_Empresa = new EUEmpresa();
            EU_Empresa.Correo = correo;
            EU_Empresa.Contraseña = contraseña;
            DataTable Datos = DAO_Empresa.LoginEmpresa(EU_Empresa);         
            return Datos;
        }

        public DataTable MostrarArchivos(String nit)
        {
             DAOEmpresa DAO_Empresa = new DAOEmpresa();
             EUEmpresa EU_Empresa = new EUEmpresa();
             EU_Empresa.Nit=nit;
             DataTable Archivos = DAO_Empresa.MostrarArchivos(EU_Empresa);
             return Archivos;
        }
        //METODO MIGRADO A _PERFILEMPRESA
        public void SubirArchivo(String nit, String nombreArchivo, String rutaArchivo, String modif)
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            EUEmpresa EU_Empresa = new EUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.RutaArchivo = rutaArchivo;
            EU_Empresa.NomArchivo = nombreArchivo;
            DAO_Empresa.SubirArchivo(EU_Empresa, modif);
        }

        public void EliminarArchivo(int idArchivo, String modif)
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            EUEmpresa EU_Empresa = new EUEmpresa();
            EU_Empresa.Id = idArchivo;
            DAO_Empresa.BorrarArchivo(EU_Empresa,"");
        }
        //METODO MIGRADO A L_PerfilEmpresa
        public void CambiarContraseña(String nit, String contraseña, String modif)
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            EUEmpresa EU_Empresa = new EUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.Contraseña = contraseña;
            DAO_Empresa.CambiarContraseña(EU_Empresa, modif);
        }

        //METODO MIGRADO A L_PERFILEMPRESA
        public void CambiarFoto(String nit, String nomArchivo, String modif)
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            EUEmpresa EU_Empresa = new EUEmpresa();
            EU_Empresa.Nit = nit;
            EU_Empresa.NomArchivo = nomArchivo;
            DAO_Empresa.CambiarFoto(EU_Empresa, modif);
        }
    }