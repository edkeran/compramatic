using System;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBIdiom
    {
        //METODO PARA INSERTAR UN NUEVO IDIOMA
        public void insertar_idioma(UEUIdioma idioma){
             using (var db = new Mapeo("public"))
            {
                db.idiom.Add(idioma);
                db.SaveChanges();
            }
        }
    }
}
