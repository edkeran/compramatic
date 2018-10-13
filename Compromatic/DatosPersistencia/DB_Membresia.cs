using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Membresia
    {
        public void modificarMembresia(string nom, string ant, int dur, double valor, string usuario)
        {
            using (var db = new Mapeo("public"))
            {
                //DEBO AVANZAR
                var mem = (from member in db.type_membership where member.Nom_mem == ant select member).FirstOrDefault();
                mem.ModifBy = usuario;
                mem.Nom_mem = nom;
                mem.Tmpo_mem=dur;
                mem.Valor_mem = valor;
                db.SaveChanges();
            }
        }

        public DataTable verificarMembresia(string nomMembresia)
        {
            nomMembresia = nomMembresia.ToUpper();
            using (var db = new Mapeo("public"))
            {
                var verMem = (from tip in db.type_membership where tip.Nom_mem.ToUpper().Contains(nomMembresia) select tip);
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<UEUTipoMembresia>(verMem.ToList<UEUTipoMembresia>());
                return res;
            }
        }

        public DataTable mostrarTipos(int id)
        {
            using (var db= new Mapeo("public"))
            {
                DataTable res = new DataTable();
                var consulta = (from TM in db.type_membership where TM.Id_tipo_mem == id select TM);
                ListToDataTable conv = new ListToDataTable();
                res = conv.ToDataTable<UEUTipoMembresia>(consulta.ToList<UEUTipoMembresia>());
                return res;
            }
        }

        public DataTable MostrarActual(int idEmpresa)
        {
            using (var db= new Mapeo("public"))
            {
                //KEEP GOING!!
                var data = (from mem in db.membresia where mem.Id_empresa == idEmpresa select mem);
                ListToDataTable conv = new ListToDataTable();
                return conv.ToDataTable<UEUMembresia>(data.ToList<UEUMembresia>());
            }
        }

        //CONTEMPLA EL ESTADO DE LA DICHOSA MEMBRESIA
        public DataTable MostrarActual2(int idEmpresa)
        {
           using (var db= new Mapeo("public"))
            {
                var data = (from mem in db.membresia where mem.Id_empresa == idEmpresa && mem.Estado_mem==1  select mem);
                ListToDataTable conv = new ListToDataTable();
                return conv.ToDataTable<UEUMembresia>(data.ToList<UEUMembresia>());
            }
        }


        public void RegistrarMembresia(UEUMembresia insercion)
        {
            using (var db= new Mapeo("public"))
            {
                DataTable test = MostrarActual(insercion.Id_empresa);
                if (test.Rows.Count > 0)
                {
                    //UPDATE
                    var data = (from mem in db.membresia where mem.Id_empresa == insercion.Id_empresa select mem).FirstOrDefault();
                    data.Estado_mem = insercion.Estado_mem;
                    data.Fecha_inicio = insercion.Fecha_inicio;
                    data.Fecha_fin = insercion.Fecha_fin;
                    data.Id_tipo_mem = insercion.Id_tipo_mem;
                    db.SaveChanges();
                }
                else
                {
                    //INSERT    
                    db.membresia.Add(insercion);
                    db.SaveChanges();
                }
            }
        }
    }
}
