using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Publicacion_Use
    {
        public void insertar_publicacion(UEUPublic_User data) { 
            using (var db= new Mapeo("public"))
            {
                db.publicaciones.Add(data);
                db.SaveChanges();
            }
        }

        public List<UEUPublic_User> get_publicaciones()
        {
            using (var db= new Mapeo("public"))
            {
                return db.publicaciones.ToList();
            }
        }

    }
}
