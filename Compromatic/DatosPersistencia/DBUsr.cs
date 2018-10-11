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

        public void actualizarUsuario(UEUsuario user, string modif)
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

        public DataTable historial_compras(UEUsuario user, int estado)
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from v in db.ventas
                            from e in db.empre
                            from p in db.productos where v.IdProducto == p.Id
                          && p.IdEmpresa == e.Id && v.IdUsr == user.IdUsr
                            && v.EstadoVenta == estado select new vista_Historial_vent {
                                idVenta = v.IdVenta,
                                fechaVenta = v.FechaVent,
                                idUsuario = v.IdUsr,
                                fechaEntrega = v.FechaEntr,
                                cantVenta = v.Cantidad,
                                estadoVenta = v.EstadoVenta,
                                valorVenta = v.Valor,
                                nomProducto = p.Nombre,
                                nomEmpresa = e.Nombre,
                                idEmpresa = e.Id,
                                calificacionEmpresa = e.Calificacion
                            }).Distinct();
                ListToDataTable conv = new ListToDataTable();
                DataTable retorno = conv.ToDataTable<vista_Historial_vent>(data.ToList<vista_Historial_vent>());
                return retorno;
            }
        }
        //VERFICAR CORREO
        public void comprobar_correo(string correo)
        {
            using (var db= new Mapeo("public"))
            {

            }
        }
    }
}
