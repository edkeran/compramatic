using System;
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
                EAcceso acc = new EAcceso();
                acc.Ip = EAcceso.obtenerIP();
                acc.Mac = EAcceso.obtenerMAC();
                acc.Id = 0; 
                acc.IdUsuario = 0;
                acc.FechaInicio = DateTime.Now.ToString();
                acc.FechaFin = DateTime.Now.ToString();
                DBAuditoria.insert(usr,acc, "dbo", "Usuario");
                
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
        public int comprobar_correo(string correo)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from user in db.user where user.CorreoUsr == correo select user).Count();
                return data;
            }
        }

        //METOSO PARA OBTENER LOS ULTIMOS 10 PRODUCTOS VISITADOS
        public DataTable obtener_top_ten(int id_user)
        {
            using(var db= new Mapeo("public"))
            {
                var datos = (from t in db.top_ten from p in db.productos from e in db.empre
                             where t.Id_prod == p.Id && p.IdEmpresa == e.Id
                             select new vistaTop10
                             {
                                 idUsuario=t.Id_usr,
                                 idProducto=t.Id_prod,
                                 fechaTop=t.Fecha_top,
                                 nomProducto=p.Nombre,
                                 nomEmpresa = e.Nombre 
                             }).Distinct();
                datos = (from d in datos where d.idUsuario == id_user select d).OrderByDescending(d => d.fechaTop).Take(10);
                List<vistaTop10> info = datos.ToList<vistaTop10>();
                ListToDataTable conv = new ListToDataTable();
                DataTable response=conv.ToDataTable<vistaTop10>(info);
                return response;
            }
        }

        //INSERCION DE LOS TOP 10   
        public void insertar_top_10(int pdto, int usr, string usuario)
        {
            using (var db = new Mapeo("public"))
            {
                UEUTopTen top = new UEUTopTen();
                top.Id_prod = pdto;
                top.Id_usr = usr;
                top.Modified_by1 = usuario;
                db.top_ten.Add(top);
                db.SaveChanges();
            }
        }

        //CHANGE PASSWORD USER
        public void CambiarPass(UEUsuario user, string usuario)
        {
            user.ModifBy = usuario;
            using (var db = new Mapeo("public")) {
                var usr = db.user.Find(user.IdUsr);
                usr.PassUsr = user.PassUsr;
                usr.ModifBy = user.ModifBy;
                db.SaveChanges();
            }
        }

        //GET SESSIONS USER
        public int obtener_sessiones_abiertas(int id_user)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.user.Find(id_user);
                return data.Sessiones;
            }
        }

        //UPDATE SESSION
        public void update_session(UEUsuario info)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.user.Find(info.IdUsr);
                data.Sessiones = info.Sessiones;
                db.SaveChanges();
            }
        }

        //METODO PARA EL BLOQUEO DE LA CUENTA
        public void bloquear_cuenta(UEUsuario user, int est, string usuario)
        {
            using (var db = new Mapeo("public"))
            {
                var data = db.user.Find(user.IdUsr);
                data.EstUsr = est;
                data.ModifBy = usuario;
                db.SaveChanges();
            }
        }

        public void CambiarFoto(UEUsuario user, string usuario)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.user.Find(user.IdUsr);
                data.NomArch = user.NomArch;
                data.ModifBy = usuario;
                db.SaveChanges();
            }
        }

        public int ComprobarReporte(int idusr, int idpdto)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from report in db.reporte_T
                            where report.idUsuario == idusr &&
                            report.idProducto == idpdto
                            select report).Count();
                if (data == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

            }
        }

        public void ReportarProducto(int motivo, int usr, int pdto, string usuario)
        {
            UEUReporte rep = new UEUReporte();
            rep.idMotivoR = motivo;
            rep.idUsuario = usr;
            rep.idProducto = pdto;
            rep.fechaReporte = DateTime.Now;
            rep.modified_by = usuario;
            using (var db= new Mapeo("public"))
            {
               db.reporte_T.Add(rep);
                db.SaveChanges();
            }
        }

        public void Bloquear_producto(string usuario, int id)
        {

            using (var db= new Mapeo("public"))
            {
                var cont = (from rep in db.reporte_T where rep.idProducto == id select rep).Count();
                if (cont > 4)
                {
                    var prod = db.productos.Find(id);
                    prod.Estado_producto = 0;
                    prod.ModifBy = usuario;
                }
            }
        }

        public List<UEUsuario> obtenerContrase(String correo)
        {
            using (var db= new Mapeo("public"))
            {
                var data = from usuario in db.user where usuario.CorreoUsr == correo select usuario;
                return data.ToList<UEUsuario>();
            }
        }

        public Boolean ExistenciaCorreo(String correo)
        {
            using (var db=new Mapeo("public"))
            {
                var data = (from usuario in db.user where usuario.CorreoUsr == correo select usuario).Count();
                if (data == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //METODO PARA EL LOGGIN DEL USUARIO
        public DataTable loggin_user(UEUsuario user)
        {
            using (var db= new Mapeo("public"))
            {
                var data = from usuario in db.user
                           where usuario.CorreoUsr == user.CorreoUsr
                           && usuario.PassUsr == user.PassUsr
                           select usuario;
                DataTable res = new DataTable();
                res.Columns.Add("idUsuario",typeof(int));res.Columns.Add("nomUsuario",typeof(string));res.Columns.Add("apeUsuario",typeof(string));
                res.Columns.Add("telUsuario",typeof(string));res.Columns.Add("correoUsuario",typeof(string));res.Columns.Add("passUsuario",typeof(string));
                res.Columns.Add("ccUsuario",typeof(string)); res.Columns.Add("dirUsuario",typeof(string)); res.Columns.Add("rutaArchivo",typeof(string));
                res.Columns.Add("nomArchivo",typeof(string));res.Columns.Add("estadoUsuario",typeof(int));res.Columns.Add("fechaCreacion_usuario",typeof(DateTime));
                res.Columns.Add("idTipo",typeof(int));res.Columns.Add("calificacionUsuario",typeof(Double));res.Columns.Add("modified_by", typeof(string));
                res.Columns.Add("Sesiones_Abiertas", typeof(int));res.Columns.Add("intentos",typeof(int));res.Columns.Add("fin_bloqueo", typeof(DateTime));
                List<UEUsuario> inf = data.ToList<UEUsuario>();
                foreach (UEUsuario aux in inf)
                {
                    DataRow fila = res.NewRow();
                    fila["idUsuario"] = aux.IdUsr;fila["nomUsuario"] = aux.NomUsr; fila["apeUsuario"] = aux.ApelUsr;
                    fila["telUsuario"] = aux.TelUsr; fila["correoUsuario"] = aux.CorreoUsr;fila["passUsuario"] = aux.PassUsr;
                    fila["ccUsuario"] = aux.CcUsr;fila["dirUsuario"] = aux.DirUsr;fila["rutaArchivo"] = aux.RutaArch;
                    fila["nomArchivo"] = aux.NomArch;fila["estadoUsuario"] = aux.EstUsr;fila["fechaCreacion_usuario"] = aux.Crea_Usr;
                    fila["nomArchivo"] = aux.NomArch;fila["idTipo"] = aux.IdTipo;fila["calificacionUsuario"] = aux.Calificacion2;
                    fila["modified_by"] = aux.ModifBy;fila["Sesiones_Abiertas"] = aux.Sessiones;fila["intentos"] = aux.Intentos;
                    if (aux.Fin_bloqu == null)
                    {
                        fila["fin_bloqueo"] = "01/01/2000";
                    }
                    else
                    {
                        fila["fin_bloqueo"] = aux.Fin_bloqu;
                    }
                    res.Rows.Add(fila);
                }
                return res;
            }
        }

        //METODO PARA OBTENER AL USUARIO POR EL CORREO
        public DataTable GET_USER(String correo)
        {
          using (var db= new Mapeo("public"))
            {
                var data = from usuario in db.user
                           where usuario.CorreoUsr == correo
                           select usuario;

                DataTable res = new DataTable();
                res.Columns.Add("idUsuario", typeof(int)); res.Columns.Add("nomUsuario", typeof(string)); res.Columns.Add("apeUsuario", typeof(string));
                res.Columns.Add("telUsuario", typeof(string)); res.Columns.Add("correoUsuario", typeof(string)); res.Columns.Add("passUsuario", typeof(string));
                res.Columns.Add("ccUsuario", typeof(string)); res.Columns.Add("dirUsuario", typeof(string)); res.Columns.Add("rutaArchivo", typeof(string));
                res.Columns.Add("nomArchivo", typeof(string)); res.Columns.Add("estadoUsuario", typeof(int)); res.Columns.Add("fechaCreacion_usuario", typeof(DateTime));
                res.Columns.Add("idTipo", typeof(int)); res.Columns.Add("calificacionUsuario", typeof(Double)); res.Columns.Add("modified_by", typeof(string));
                res.Columns.Add("Sesiones_Abiertas", typeof(int)); res.Columns.Add("intentos", typeof(int));
                List<UEUsuario> inf = data.ToList<UEUsuario>();
                foreach (UEUsuario aux in inf)
                {
                    DataRow fila = res.NewRow();
                    fila["idUsuario"] = aux.IdUsr; fila["nomUsuario"] = aux.NomUsr; fila["apeUsuario"] = aux.ApelUsr;
                    fila["telUsuario"] = aux.TelUsr; fila["correoUsuario"] = aux.CorreoUsr; fila["passUsuario"] = aux.PassUsr;
                    fila["ccUsuario"] = aux.CcUsr; fila["dirUsuario"] = aux.DirUsr; fila["rutaArchivo"] = aux.RutaArch;
                    fila["nomArchivo"] = aux.NomArch; fila["estadoUsuario"] = aux.EstUsr; fila["fechaCreacion_usuario"] = aux.Crea_Usr;
                    fila["nomArchivo"] = aux.NomArch; fila["idTipo"] = aux.IdTipo; fila["calificacionUsuario"] = aux.Calificacion2;
                    fila["modified_by"] = aux.ModifBy; fila["Sesiones_Abiertas"] = aux.Sessiones; fila["intentos"] = aux.Intentos;
                    res.Rows.Add(fila);
                }
                return res;
            }
        }

        // METODO PARA ACTUALIZAR EL BLOQUE DE INTETOS
        public void UPDATE_BLOQUEO(String correo, DateTime h_in, DateTime h_fi, int intentos)
        {
            using (var db= new Mapeo("public"))
            {
                var update =(from usuario in db.user where usuario.CorreoUsr == correo select usuario).FirstOrDefault();
                update.Inc_bloq = h_in;
                update.Fin_bloqu = h_fi;
                update.Intentos = intentos;
                db.SaveChanges();
            }
        }

        //METODO PARA REGISTRAR LA NUEVA PUNTUACION HACIA LA EMPRESA
        public void RegistrarRango(UEURango rango, String usuario)
        {
            using (var db = new Mapeo("public"))
            {
                rango.Calificador = 0;
                rango.FechaRango = DateTime.Now;
                rango.ModifiBy = usuario;
                db.rangos.Add(rango);
                db.SaveChanges();
            }
        }

        //METODO PARA CALIFICAR A LA EMPRESA
        public void CalificarEmp(UEUEmpresa emp, String usuario)
        {
            using (var db= new Mapeo("public"))
            {
                var empre = db.empre.Find(emp.Id);
                empre.Calificacion = emp.Calificacion;
                empre.ModifBy = usuario;
                db.SaveChanges();
            }
        }

        //METODO PARA BLOQUEAR A LA EMPRESA SI RECIBE UNA PESIMA PUNTUACION
        public void CambiarEstadoEmp(int emp, int est, String modif)
        {
            using (var db= new Mapeo("public"))
            {
                var empresa = db.empre.Find(emp);
                empresa.EstadoEmpre = est;
                empresa.ModifBy = modif;
                db.SaveChanges();
            }
        }
    }
}
