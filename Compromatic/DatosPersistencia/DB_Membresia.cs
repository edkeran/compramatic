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
    }
}
