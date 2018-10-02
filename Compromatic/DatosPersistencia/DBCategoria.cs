using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBCategoria
    {
        public void insertar_categoria(UEUCategoria cat)
        {
            using (var db = new Mapeo("public"))
            {
                db.categ.Add(cat);
                db.SaveChanges();
            }
        }

        public void editar_categoria(UEUCategoria categ)
        {
            using (var db = new Mapeo("public"))
            {
                var cate = db.categ.Find(categ.Id_cate);
                cate.ModifBy = categ.ModifBy;
                cate.nomCategoria = categ.nomCategoria;
                db.SaveChanges();
            }
           
        }

        public List<UEUCategoria> leer_categorias()
        {
            using (var db = new Mapeo("public"))
            {
                return db.categ.OrderBy(f=>f.Id_cate).ToList<UEUCategoria>(); 
            }
        }
    }
}
