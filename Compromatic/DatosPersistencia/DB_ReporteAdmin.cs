using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_ReporteAdmin
    {
        public vistaReporteAdmin[] crear_vista_reporte()
        {
            using (var db = new Mapeo("public"))
            {
                var datos = (from u in db.empre
                             join prod in db.productos on u.Id equals prod.IdEmpresa
                             join venta in db.ventas on prod.Id equals venta.IdProducto
                             where venta.EstadoVenta == 4
                             select new vistaReporteAdmin
                             {
                                 Nit_empresa = u.Nit,
                                 Nom_empresa = u.Nombre,
                                 Cal_empresa = u.Calificacion,
                                 //SELECCIONAR TODAS LAS VENTAS DE LA EMPRESA Y SUMARLAS
                                 Valor = (db.ventas.Where(z => z.EstadoVenta == 4 && z.IdProducto == prod.Id).Distinct().Sum(z => z.Valor)).ToString(),
                                 Ventas = db.ventas.Count(x => x.IdProducto == prod.Id && x.EstadoVenta == 4),
                                 RutaArchivo = u.RutaArchivo+""+u.NomArchivo
                             }).Distinct();
                //CREAR UNA LISTA DE LA CLASE ENCAPSULADORA Y RETORNARLA
                vistaReporteAdmin [] data=datos.ToArray();
                return data;
            }
        }
    }
}
