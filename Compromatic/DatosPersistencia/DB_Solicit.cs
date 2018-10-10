using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Solicit
    {
        //FUNCION QUE ME TRAE TODAS LAS SOLICITUDES ACEPTADAS
        public DataTable traer_accept()
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from emp in db.empre
                           join solicit in db.sol_reg on emp.Id equals solicit.Id_empresa
                           where solicit.Estado_solici == 0
                           select new UEUVista_Soil_Acep
                           {
                               nomEmpresa=emp.Nombre,
                               telEmpresa=emp.Numero,
                               correoEmpresa=emp.Correo,
                               dirEmpresa=emp.Direccion,
                               nitEmpresa=emp.Nit,
                               rutaArchivo=emp.RutaArchivo+emp.NomArchivo,
                               estadoEmpresa=emp.EstadoEmpre,
                               calificacionEmpresa=emp.Calificacion,
                               fechaCreacion_empresa=emp.Fecha_Crea,
                               idSolicitud_registro=solicit.Id_solici,
                               estadoSolicitud=solicit.Estado_solici
                           });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorno = conv.ToDataTable<UEUVista_Soil_Acep>(data.ToList<UEUVista_Soil_Acep>());
                return retorno;
            }
        }

        //METODO QUE TRAE LAS SOLICITUDES RECHAZADAS
        public DataTable traer_rechaza()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from emp in db.empre
                            join solicit in db.sol_reg on emp.Id equals solicit.Id_empresa
                            where solicit.Estado_solici == 3
                            select new UEUVista_Soil_Acep
                            {
                                nomEmpresa = emp.Nombre,
                                telEmpresa = emp.Numero,
                                correoEmpresa = emp.Correo,
                                dirEmpresa = emp.Direccion,
                                nitEmpresa = emp.Nit,
                                rutaArchivo = emp.RutaArchivo + emp.NomArchivo,
                                estadoEmpresa = emp.EstadoEmpre,
                                calificacionEmpresa = emp.Calificacion,
                                fechaCreacion_empresa = emp.Fecha_Crea,
                                idSolicitud_registro = solicit.Id_solici,
                                estadoSolicitud = solicit.Estado_solici
                            });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorno = conv.ToDataTable<UEUVista_Soil_Acep>(data.ToList<UEUVista_Soil_Acep>());
                return retorno;
            }
        }

        //METODO QUE ME TRAE TODAS LAS SOLICITUDES PENDIENTES
        public DataTable traer_pendiente()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from emp in db.empre
                            join solicit in db.sol_reg on emp.Id equals solicit.Id_empresa
                            where solicit.Estado_solici == 1
                            select new UEUVista_Soil_Acep
                            {
                                nomEmpresa = emp.Nombre,
                                telEmpresa = emp.Numero,
                                correoEmpresa = emp.Correo,
                                dirEmpresa = emp.Direccion,
                                nitEmpresa = emp.Nit,
                                rutaArchivo = emp.RutaArchivo + emp.NomArchivo,
                                estadoEmpresa = emp.EstadoEmpre,
                                calificacionEmpresa = emp.Calificacion,
                                fechaCreacion_empresa = emp.Fecha_Crea,
                                idSolicitud_registro = solicit.Id_solici,
                                estadoSolicitud = solicit.Estado_solici
                            });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorno = conv.ToDataTable<UEUVista_Soil_Acep>(data.ToList<UEUVista_Soil_Acep>());
                return retorno;
            }
        }


    }
}
