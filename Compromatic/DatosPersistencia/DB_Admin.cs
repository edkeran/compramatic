using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Admin
    {
        public int tot_clients()
        {
            using (var db = new Mapeo("public"))
            {
                int count = (from usr in db.user select usr.IdUsr).Count();
                return count;
            }
        }

        public int tot_ventas()
        {
            using (var db = new Mapeo("public"))
            {
                //query
                int ventas = (from vent in db.ventas
                              where vent.EstadoVenta == 4
                              select vent.Valor).Sum();
                return ventas;
            }
        }

        public int total_empr()
        {
            using (var db = new Mapeo("public"))
            {
                int tot_comp = (from empr in db.empre select empr.Id).Count();
                return tot_comp;
            }
        }

        //OBTENER TODAS LAS NOTIFICACIONES
        public int llenar_notificacion()
        {
            using (var db = new Mapeo("public"))
            {
                int data = (from solitReg in db.sol_reg
                            where solitReg.Estado_solici == 1
                            select solitReg.Id_solici).Count();
                return data;
            }
        }

        //NOTIFICACIONES ACEPTADAS
        public int llenar_notificacionAccept()
        {
            using (var db = new Mapeo("public"))
            {
                int data = (from solici in db.sol_reg
                            where solici.Estado_solici == 0
                            select solici.Id_solici).Count();
                return data;
            }
        }

        //NOTIFICACIONES RECHAZADAS
        public int llenar_notificacionRechaz()
        {
            using (var db = new Mapeo("public"))
            {
                int data = (from h in db.sol_reg
                            where h.Estado_solici == 3
                            select h.Id_solici).Count();
                return data;
            }
        }

        //METODO PARA TRAER EL PQR DE LAS EMPRESAS
        public DataTable pqr_empresa()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from qj in db.inf_quejas
                            join emp in db.empre on qj.IdEmpre equals emp.Id
                            join usr in db.user on qj.Id_user equals usr.IdUsr
                            join Mq in db.quejas on qj.Id_Moti_Quej equals Mq.Id_queja
                            where qj.IdEmpre != null
                            where qj.ReceptorQ == 2
                            select new vistaPQRempresa
                            {
                                desQueja = qj.DesQuej,
                                fechaQueja = qj.FechaQuj,
                                nomQueja = Mq.Nom_queja,
                                Emisor = usr.NomUsr,
                                foto = emp.RutaArchivo + emp.NomArchivo
                            }).Distinct();

                List<vistaPQRempresa> datos = data.ToList<vistaPQRempresa>();
                ListToDataTable conv = new ListToDataTable();
                DataTable respuesta = conv.ToDataTable<vistaPQRempresa>(datos);
                return respuesta;
            }
        }

        //METODO PARA TRAER LOS REPORTES
        public DataTable Reportes()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from Empresa in db.empre
                            join Producto in db.productos on Empresa.Id equals Producto.IdEmpresa
                            join Reporte in db.reporte_T on Producto.Id equals Reporte.idProducto
                            join Usuario in db.user on Reporte.idUsuario equals Usuario.IdUsr
                            join MotivoR in db.report on Reporte.idMotivoR equals MotivoR.IdMoti
                            select new vista_reportesAdministrador
                            {
                                rutaArchivo = Empresa.RutaArchivo + Empresa.NomArchivo,
                                nomEmpresa = Empresa.Nombre,
                                nomUsuario = Usuario.NomUsr,
                                nomProducto = Producto.Nombre,
                                desMotivo = MotivoR.DesMotiv,
                                fechaReporte=Reporte.fechaReporte,
                                correoEmpresa = Empresa.Correo,
                                idProducto=Reporte.idProducto
                            });
                List<vista_reportesAdministrador> res = data.ToList<vista_reportesAdministrador>();
                ListToDataTable conv = new ListToDataTable();
                DataTable retorno=conv.ToDataTable<vista_reportesAdministrador>(res);
                return retorno;
            }

        }
    }
}
