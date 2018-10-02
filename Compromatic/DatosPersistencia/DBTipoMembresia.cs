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
    }
}
