using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBIdiom
    {
        //METODO PARA INSERTAR UN NUEVO IDIOMA
        public void insertar_idioma(UEUIdioma idioma) {
            using (var db = new Mapeo("idioma"))
            {
                db.idiom.Add(idioma);
                db.SaveChanges();
            }
        }

        //METODO PARA TAER UN IDIOMA
        public List<UEUIdioma> traer_idioma()
        {
            using (var db = new Mapeo("idioma"))
            {
                return db.idiom.Where(x => x.Id_Idioma != 1).ToList<UEUIdioma>();
            }
        }

        //METODO PARA ELIMINAR UN IDIOMA
        public void delete_idiom(int id)
        {
            using (var db = new Mapeo("idioma"))
            {
                var idioma = db.idiom.Find(id);
                db.Entry(idioma).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        //METODO PARA TRAER UN SOLO IDI0OMA
        public UEUIdioma get_idiom (int id){
            using (var db = new Mapeo("idioma"))
            {
                var idioma = db.idiom.Find(id);
                return idioma;
            }
        }

        public void update_idioma(UEUIdioma new_idiom)
        {
            using (var db= new Mapeo("idioma"))
            {
                db.idiom.Attach(new_idiom);
                var entry = db.Entry(new_idiom);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
