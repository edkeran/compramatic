using System;
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
        //MODIFICAR QUEJA   
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

        //METODO QUE TRAE TODOS LOS REPORTES
        public List<UEUMotiRepo> traer_reportes()
        {
            using (var db= new Mapeo("public"))
            {
                return db.report.ToList<UEUMotiRepo>();
            }
        }

        //METODO PARA VERFICAR LA QUEJA 
        public DataTable verficarQueja(string nomQueja)
        {
            using (var db= new Mapeo("public"))
            {
                nomQueja = nomQueja.ToUpper();
                var consulta = (from motiQ in db.quejas where motiQ.Nom_queja.ToUpper().Contains(nomQueja) select motiQ);
                ListToDataTable conv = new ListToDataTable();
                return conv.ToDataTable<UEUQueja>(consulta.ToList<UEUQueja>());
            }
        }

        //METODO PARA VERFICAR EL REPORTE
        public DataTable verficarReporte(string nomReporte)
        {
            nomReporte = nomReporte.ToUpper();
           using (var db= new Mapeo("public"))
            {
                var datos = (from motiR in db.report where motiR.DesMotiv.ToUpper().Contains(nomReporte) select motiR);
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<UEUMotiRepo>(datos.ToList<UEUMotiRepo>());
                return res;
            }
        }
        //REGIST PQR EMPRESZA
        public void RegistrarPqr(UEUPqr EU_Pqr, string modif)
        {
            using (var db = new Mapeo("public"))
            {
                TQuejas quej = new TQuejas();
                quej.Modified_by = modif;
                quej.DesQuej = EU_Pqr.Descripcion;
                quej.FechaQuj = DateTime.Now;
                quej.IdEmpre = EU_Pqr.IdEmpresa;
                quej.Id_Moti_Quej = EU_Pqr.Motivo;
                quej.ReceptorQ = 1;
                db.inf_quejas.Add(quej);
                db.SaveChanges();
            } 
        }

        public void quejaUsr(UEUPqr pqr, String modif)
        {
            using (var db = new Mapeo("public"))
            {
                TQuejas quej = new TQuejas();
                quej.DesQuej = pqr.Descripcion;
                quej.FechaQuj = DateTime.Now;
                quej.Id_user = pqr.IdCliente;
                quej.Id_Moti_Quej = 2;
                quej.ReceptorQ = 1;
                quej.Modified_by = modif;
                db.inf_quejas.Add(quej);
                db.SaveChanges();
            }
        }

        public DataTable MostrarPQRcliente()
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from motivoQ in db.quejas
                            join quejas in db.inf_quejas on motivoQ.Id_queja equals quejas.Id_Moti_Quej
                            join Empresa in db.empre on quejas.IdEmpre equals Empresa.Id
                            join Usuario in db.user on quejas.Id_user equals Usuario.IdUsr
                            where quejas.ReceptorQ==3
                            select new vistaMostrarPQRCliente
                            {
                                desQueja=quejas.DesQuej,
                                fechaQueja=quejas.FechaQuj,
                                nomQueja=motivoQ.Nom_queja,
                                foto=Usuario.RutaArch+Usuario.NomArch,
                                Emisor=Empresa.Nombre
                            });
                List<vistaMostrarPQRCliente> pqrClien = data.ToList<vistaMostrarPQRCliente>();
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<vistaMostrarPQRCliente>(pqrClien);
                return res;
            }
        }
    }
}
