using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBTipoMembresia
    {
        public void insertar_membresia(UEUTipoMembresia t_mem)
        {
            using (var db = new Mapeo("public"))
            {
                db.type_membership.Add(t_mem);
                db.SaveChanges();
            }
        }

        public List<UEUTipoMembresia> traer_membresias()
        {
            using(var db= new Mapeo("public"))
            {
                return db.type_membership.ToList<UEUTipoMembresia>();
            }
        }

        public DataTable MostrarTipos()
        {
            using (var db=new Mapeo("public"))
            {

                var tipos = from tipoMem in db.type_membership select tipoMem;
                List<UEUTipoMembresia> data = tipos.ToList<UEUTipoMembresia>();
                List<UAuxTipoMem> conver = new List<UAuxTipoMem>();
                foreach (UEUTipoMembresia aux in data)
                {
                    UAuxTipoMem informacion = new UAuxTipoMem();
                    informacion.idTipo_membresia = aux.Id_tipo_mem;
                    informacion.modified_by = aux.ModifBy;
                    informacion.nomMembresia = aux.Nom_mem;
                    informacion.tiempoMembresia = aux.Tmpo_mem;
                    informacion.valorMembresia = aux.Valor_mem;
                    conver.Add(informacion);
                }

                ListToDataTable conv = new ListToDataTable();
                DataTable retorno = conv.ToDataTable<UAuxTipoMem>(conver);
                return retorno;

            }
        }
    }
}
