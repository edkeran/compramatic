using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBUsr
    {
        public void insertarUsuarioPersistencia(UEUsuario usr)
        {
            using (var db = new Mapeo("public"))
            {
                db.user.Add(usr);
                db.SaveChanges();
            }
        }

        public List<UEUsuario> obtenerUsuario()
        {
            using (var db = new Mapeo("public"))
            {
                return db.user.Where(x => x.IdTipo != 1).ToList<UEUsuario>();
            }
        }

        public void actualizarUsuario(UEUsuario user,string modif)
        {
            using (var db = new Mapeo("public"))
            {
                var usuario = db.user.Find(user.IdUsr);
                //PARAMETROS UPDATE
                usuario.IdUsr = user.IdUsr;
                usuario.NomUsr = user.NomUsr;
                usuario.ApelUsr = user.ApelUsr;
                usuario.TelUsr = user.TelUsr;
                usuario.CcUsr = user.CcUsr;
                usuario.CorreoUsr = user.CorreoUsr;
                usuario.DirUsr = user.DirUsr;
                usuario.ModifBy = modif;
                db.SaveChanges();
            }
        }
    }
}
