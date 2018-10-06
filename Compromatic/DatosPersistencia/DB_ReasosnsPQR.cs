using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_ReasosnsPQR
    {
        //DATABASE PERSISTENCIA DEL PQR DEL ADMINSTRADOR
        public void insertar_queja(UEUQueja queja)
        {
            using (var db= new Mapeo("public"))
            {
                db.quejas.Add(queja);
                db.SaveChanges();
            }
        }

        public void modif_queja(UEUQueja queja)
        {
            using (var db= new Mapeo("public"))
            {
                //UPDATE DE LAS QUEJAS
                db.quejas.Attach(queja);
                var entry = db.Entry(queja);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //METODO PARA TRAER LOS MOTIVOS QUEJAS INGRESADAS POR EL ADMIN
        public List<UEUQueja> traer_quejas()
        {
            using (var db= new Mapeo("public"))
            {
                 return db.quejas.ToList<UEUQueja>();
            }
        }

        //METODO PARA INSERTAR UN REPORTE PARA LAS EMPRESAS
        public void insertar_reporte(UEUMotiRepo rep)
        {
            using (var db= new Mapeo("public"))
            {
                db.report.Add(rep);
                db.SaveChanges();
            }
        }

        //METODO PARA ACTUALIZAR UN REPORTE DE LAS EMPRESAS POR EL ADMINISTRADOR
        public void actualizar_reporte(UEUMotiRepo reporte)
        {
            using (var db= new Mapeo("public"))
            {
                db.report.Attach(reporte);
                var entry = db.Entry(reporte);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<UEUMotiRepo> traer_reportes()
        {
            using (var db= new Mapeo("public"))
            {
                return db.report.ToList<UEUMotiRepo>();
            }
        }
    }
}
