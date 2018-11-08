using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBEmpresa
    {
        //INSERT DE LA EMPRESA ME TOCA REVISAR SI DEBO USAR OTRA TABLA
        public void InsertarEmpresa(UEUEmpresa empresa)
        {
            using (var db = new Mapeo("public"))
            {
                empresa.Calificacion = 5;
                empresa.Sessiones = 0;
                empresa.EstadoEmpre = 0;
                //PASO 1 INSERTAR LA EMPRESA EN LA BASE DE DATOS
                db.empre.Add(empresa);
                db.SaveChanges();
                //PASO 2 OBTENER LA EMPRESA INSERTADA POR EL NIT DE LA MISMA
                List<UEUEmpresa> emp = db.empre.Where(x => x.Nit == empresa.Nit).ToList<UEUEmpresa>();
                //PASO 3 INSERTAR EN LA SOLICITUD REGISTRO
                UEUEmpresa empres = emp.ElementAt(0);
                UEUSolici_Regist soli = new UEUSolici_Regist();
                soli.ModifBy = empresa.ModifBy;
                soli.Id_empresa = empres.Id;
                soli.Estado_solici = 1;

                db.sol_reg.Add(soli);
                db.SaveChanges();

                //PASO 4 INSERTAR EN LA TABLA MEMBRESIA 
                UEUMembresia mem = new UEUMembresia();
                mem.Fecha_inicio =empresa.FechaInicio;
                mem.Fecha_fin = empresa.FechaFin;
                mem.ModifieBy = empresa.ModifBy;
                mem.Id_tipo_mem = empresa.IdTipoMembresia;
                mem.Estado_mem = 0;
                mem.Id_empresa = empres.Id;

                db.membresia.Add(mem);
                db.SaveChanges();

                //STEP 5 INSTER THE UPADATE IN THE TABLE OF SECURITY
                EAcceso acc = new EAcceso();
                acc.Ip = EAcceso.obtenerIP();
                acc.Mac = EAcceso.obtenerMAC();
                acc.Id = 0;
                acc.IdUsuario = 0;
                acc.FechaInicio = DateTime.Now.ToString();
                acc.FechaFin = DateTime.Now.ToString();
                DBAuditoria.insert(empresa,acc,"dbo","Empresa");
            }
        }

        public void actualizar_contrasena_empresa(UEUEmpresa emp)
        {
            using (var db = new Mapeo("public"))
            {
                //UPDATE PASSWORD OF THE COMPANY
                var empresa = db.empre.Find(emp.Id);
                empresa.Contraseña = emp.Contraseña;
                empresa.ModifBy = emp.ModifBy;
                db.SaveChanges();
            }
        }

        //METODO PARA TRAER LA EMPRESA ACTUAL Y POR LO LO TANTO SABER LA CONTRASEÑA ACTUAL
        public UEUEmpresa traer_empresa_actual(UEUEmpresa emp)
        {
            using (var db= new Mapeo("public"))
            {
                var empresa = db.empre.Find(emp.Id);
                return (UEUEmpresa)empresa;
            }
        }

        //METODO PARA ACTUALIZAR LA EMPRESA
        public void update_Empresa(UEUEmpresa datos)
        {
            using (var db= new Mapeo("public"))
            {
                var old = db.empre.Find(datos.Id);
                old.Nombre = datos.Nombre;
                old.Nit = datos.Nit;
                old.Numero = datos.Numero;
                old.Correo = datos.Correo;
                old.Direccion = datos.Direccion;
                old.ModifBy = datos.ModifBy;
                db.SaveChanges();
            }
        }

        //METODO PARA MOSTRAR LOS ARCHIVOS CARGADOS POR LA EMPRESA
        public DataTable MostrarArchivos(UEUEmpresa emp)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from archivSoli in db.archiv_Emp 
                            join solci in db.sol_reg on archivSoli.idSolicitud_registro equals solci.Id_solici
                            join empre in db.empre on solci.Id_empresa equals empre.Id
                            where empre.Nit==emp.Nit
                            select archivSoli);
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<UEUArchivoSolic>(data.ToList<UEUArchivoSolic>());
                return res;
            }
        }

        //METODO PARA ELIMINAR EL ARCHIVO
        public void delete_file(int id)
        {
            using (var db= new Mapeo("public"))
            {
                var file = db.archiv_Emp.Find(id);
                db.Entry(file).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        //METODO PARA OBTENER LA CANTIDAD DE SESIONES EXISTENTES
        public int get_sessions(int id)
        {
            using( var db= new Mapeo("public"))
            {
                var data = db.empre.Find(id);
                int sess = data.Sessiones;
                return sess;
            }
        }

        //METODO PARA ACTUALIZAR LA SESSION
        public void update_session(UEUEmpresa emp)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.empre.Find(emp.Id);
                data.Sessiones = emp.Sessiones;
                db.SaveChanges();
            }
        }

        //METODO PARA VALIDAR LA EXISTENCIA DEL CORREO
        public bool ExistenciaCorreo(string correo)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from emp in db.empre where emp.Correo == correo select emp).Count();
                if (data == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //METODO PARA EL LOGGIN DE LA EMPRESA
        public DataTable LoginEmpresa(UEUEmpresa EU_Empresa)
        {
            using (var db= new Mapeo("public"))
            {
                var data=(from empresa in db.empre where empresa.Correo==EU_Empresa.Correo && empresa.Contraseña==EU_Empresa.Contraseña
                          select empresa);
                List<UEUEmpresa> inf = data.ToList<UEUEmpresa>();
                DataTable res = new DataTable();
                res.Columns.Add("nomEmpresa",typeof(string));res.Columns.Add("idEmpresa",typeof(int));res.Columns.Add("telEmpresa", typeof(string));
                res.Columns.Add("correoEmpresa", typeof(string));res.Columns.Add("dirEmpresa", typeof(string));res.Columns.Add("nitEmpresa", typeof(string));
                res.Columns.Add("nomArchivo", typeof(string));res.Columns.Add("rutaArchivo",typeof(string));res.Columns.Add("estadoEmpresa", typeof(int));
                res.Columns.Add("calificacionEmpresa", typeof(double));res.Columns.Add("idTipo", typeof(int));res.Columns.Add("passEmpresa", typeof(string));
                res.Columns.Add("fechaCreacion_empresa", typeof(DateTime));res.Columns.Add("modified_by", typeof(string));res.Columns.Add("Sesiones_Abiertas", typeof(int));
                res.Columns.Add("intentos", typeof(int));
                foreach(UEUEmpresa aux in inf)
                {
                    DataRow fila = res.NewRow();
                    fila["nomEmpresa"] = aux.Nombre; fila["telEmpresa"] = aux.Numero; fila["idEmpresa"] = aux.Id; fila["correoEmpresa"] = aux.Correo;
                    fila["dirEmpresa"] = aux.Direccion; fila["nitEmpresa"] = aux.Nit; fila["nomArchivo"] = aux.NomArchivo; fila["rutaArchivo"] = aux.RutaArchivo;
                    fila["estadoEmpresa"] = aux.EstadoEmpre; fila["calificacionEmpresa"] = aux.Calificacion; fila["idTipo"] = aux.IdTipo; fila["passEmpresa"] = aux.Contraseña;
                    fila["fechaCreacion_empresa"] = aux.Fecha_Crea;fila["modified_by"] = aux.ModifBy; fila["Sesiones_Abiertas"] = aux.Sessiones; fila["Sesiones_Abiertas"] = aux.Sessiones;
                    fila["intentos"] = aux.Intentos;
                    res.Rows.Add(fila);
                }
                return res;
                
            }
        }

        //METODFO PARA OBTENER LA EMPRESA POR CORRE
        public DataTable GET_EMP(string correo)
        {
            using (var db= new Mapeo("public"))
            {
                var data = from emp in db.empre
                           where emp.Correo == correo
                           select emp;
                List<UEUEmpresa> inf = data.ToList<UEUEmpresa>();
                DataTable res = new DataTable();
                res.Columns.Add("nomEmpresa", typeof(string)); res.Columns.Add("idEmpresa", typeof(int)); res.Columns.Add("telEmpresa", typeof(string));
                res.Columns.Add("correoEmpresa", typeof(string)); res.Columns.Add("dirEmpresa", typeof(string)); res.Columns.Add("nitEmpresa", typeof(string));
                res.Columns.Add("nomArchivo", typeof(string)); res.Columns.Add("rutaArchivo", typeof(string)); res.Columns.Add("estadoEmpresa", typeof(int));
                res.Columns.Add("calificacionEmpresa", typeof(double)); res.Columns.Add("idTipo", typeof(int)); res.Columns.Add("passEmpresa", typeof(string));
                res.Columns.Add("fechaCreacion_empresa", typeof(DateTime)); res.Columns.Add("modified_by", typeof(string)); res.Columns.Add("Sesiones_Abiertas", typeof(int));
                res.Columns.Add("intentos", typeof(int));
                foreach (UEUEmpresa aux in inf)
                {
                    DataRow fila = res.NewRow();
                    fila["nomEmpresa"] = aux.Nombre; fila["telEmpresa"] = aux.Numero; fila["idEmpresa"] = aux.Id; fila["correoEmpresa"] = aux.Correo;
                    fila["dirEmpresa"] = aux.Direccion; fila["nitEmpresa"] = aux.Nit; fila["nomArchivo"] = aux.NomArchivo; fila["rutaArchivo"] = aux.RutaArchivo;
                    fila["estadoEmpresa"] = aux.EstadoEmpre; fila["calificacionEmpresa"] = aux.Calificacion; fila["idTipo"] = aux.IdTipo; fila["passEmpresa"] = aux.Contraseña;
                    fila["fechaCreacion_empresa"] = aux.Fecha_Crea; fila["modified_by"] = aux.ModifBy; fila["Sesiones_Abiertas"] = aux.Sessiones; fila["Sesiones_Abiertas"] = aux.Sessiones;
                    fila["intentos"] = aux.Intentos;
                    res.Rows.Add(fila);
                }
                return res;
            }
        }

        //METODO PARA ACTUALIZAR LOS INTENTOS INVALIDOS DE LOGGUEO
        public void UPDATE_BLOQUEO(String correo, DateTime h_in, DateTime h_fi, int intentos)
        {
           using (var db= new Mapeo("public"))
            {
                var update = (from empres in db.empre where empres.Correo == correo select empres).FirstOrDefault();
                if (update != null)
                {
                    update.Fch_in = h_in;
                    update.Fch_fn = h_fi;
                    update.Intentos = intentos;
                    db.SaveChanges();
                }
                
            }
        }

        //METODO PARA OBTENER LAS PETIVCIONES DE COMPRA
        public DataTable PeticionesCompra(int idEmpresa)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from prod in db.productos
                            join vent in db.ventas on prod.Id equals vent.IdProducto
                            join usuario in db.user on vent.IdUsr equals usuario.IdUsr
                            join empresa in db.empre on prod.IdEmpresa equals empresa.Id
                            where vent.EstadoVenta == 1 && empresa.Id == idEmpresa
                            select new vistaMostrarVenta {
                                idVenta = vent.IdVenta,
                                fechaVenta=vent.FechaVent,
                                estadoVenta=vent.EstadoVenta,
                                valorVenta=vent.Valor,
                                nomUsuario=usuario.NomUsr,
                                apeUsuario=usuario.ApelUsr,
                                telUsuario=usuario.TelUsr,
                                correoUsuario=usuario.CorreoUsr,
                                dirUsuario=usuario.DirUsr,
                                idEmpresa=empresa.Id,
                                calificacionUsuario=usuario.Calificacion2,
                                canProducto=prod.Cantidad,
                                cantVenta=vent.Cantidad,
                                nomProducto=prod.Nombre
                            });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorn = conv.ToDataTable<vistaMostrarVenta>(data.ToList<vistaMostrarVenta>());
                return retorn;
            }
        }

        public DataTable PeticionesEnProceso(int idEmpresa)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from prod in db.productos
                           join vent in db.ventas on prod.Id equals vent.IdProducto
                           join usuario in db.user on vent.IdUsr equals usuario.IdUsr
                           join empresa in db.empre on prod.IdEmpresa equals empresa.Id
                           where vent.EstadoVenta == 2 && empresa.Id == idEmpresa
                           select new vistaMostrarVenta
                           {
                               idVenta = vent.IdVenta,
                               fechaVenta = vent.FechaVent,
                               estadoVenta = vent.EstadoVenta,
                               valorVenta = vent.Valor,
                               nomUsuario = usuario.NomUsr,
                               apeUsuario = usuario.ApelUsr,
                               telUsuario = usuario.TelUsr,
                               correoUsuario = usuario.CorreoUsr,
                               dirUsuario = usuario.DirUsr,
                               idEmpresa = empresa.Id,
                               calificacionUsuario = usuario.Calificacion2,
                               canProducto = prod.Cantidad,
                               cantVenta = vent.Cantidad,
                               nomProducto = prod.Nombre
                           });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorn = conv.ToDataTable<vistaMostrarVenta>(data.ToList<vistaMostrarVenta>());
                return retorn;
            }
        }

        public DataTable PeticionesFinalizadas(int idEmpresa)
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from prod in db.productos
                            join vent in db.ventas on prod.Id equals vent.IdProducto
                            join usuario in db.user on vent.IdUsr equals usuario.IdUsr
                            join empresa in db.empre on prod.IdEmpresa equals empresa.Id
                            where vent.EstadoVenta == 4 && empresa.Id == idEmpresa
                            select new vistaMostrarVenta
                            {
                                idVenta = vent.IdVenta,
                                fechaVenta = vent.FechaVent,
                                estadoVenta = vent.EstadoVenta,
                                valorVenta = vent.Valor,
                                nomUsuario = usuario.NomUsr,
                                apeUsuario = usuario.ApelUsr,
                                telUsuario = usuario.TelUsr,
                                correoUsuario = usuario.CorreoUsr,
                                dirUsuario = usuario.DirUsr,
                                idEmpresa = empresa.Id,
                                calificacionUsuario = usuario.Calificacion2,
                                canProducto = prod.Cantidad,
                                cantVenta = vent.Cantidad,
                                nomProducto = prod.Nombre
                            });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorn = conv.ToDataTable<vistaMostrarVenta>(data.ToList<vistaMostrarVenta>());
                return retorn;
            }
        }

        public DataTable PeticionesHechas(int idEmpresa)
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from prod in db.productos
                            join vent in db.ventas on prod.Id equals vent.IdProducto
                            join usuario in db.user on vent.IdUsr equals usuario.IdUsr
                            join empresa in db.empre on prod.IdEmpresa equals empresa.Id
                            where vent.EstadoVenta == 5 && empresa.Id == idEmpresa
                            select new vistaMostrarVenta
                            {
                                idVenta = vent.IdVenta,
                                fechaVenta = vent.FechaVent,
                                estadoVenta = vent.EstadoVenta,
                                valorVenta = vent.Valor,
                                nomUsuario = usuario.NomUsr,
                                apeUsuario = usuario.ApelUsr,
                                telUsuario = usuario.TelUsr,
                                correoUsuario = usuario.CorreoUsr,
                                dirUsuario = usuario.DirUsr,
                                idEmpresa = empresa.Id,
                                calificacionUsuario = usuario.Calificacion2,
                                canProducto = prod.Cantidad,
                                cantVenta = vent.Cantidad,
                                nomProducto = prod.Nombre
                            });
                ListToDataTable conv = new ListToDataTable();
                DataTable retorn = conv.ToDataTable<vistaMostrarVenta>(data.ToList<vistaMostrarVenta>());
                return retorn;
            }
        }

        public int AprobarVenta(int idVenta, String usuario)
        {
            using (var db= new Mapeo("public"))
            {
                var idPro = (from product in db.productos
                            join vent in db.ventas on product.Id equals vent.IdProducto
                            where vent.IdVenta == idVenta
                            select product.Id).FirstOrDefault();

                var consultB = (from product in db.productos
                               join vent in db.ventas on product.Id equals vent.IdProducto
                               where vent.IdVenta == idVenta
                               select product.Cantidad).FirstOrDefault();

                var consultC = (from vent in db.ventas
                               where vent.IdVenta == idVenta
                               select vent.Cantidad).FirstOrDefault();

                if (consultB < consultC)
                {
                    return 1;
                }
                else
                {
                    //HACER UPDATES
                    var prod = db.productos.Find(idPro);
                    prod.Cantidad = prod.Cantidad - ((from vent in db.ventas where vent.IdVenta == idVenta select vent.Cantidad).FirstOrDefault());
                    prod.ModifBy = usuario;
                    db.SaveChanges();
                    var venta = db.ventas.Find(idVenta);
                    venta.EstadoVenta = 2;
                    venta.modified_by = usuario;
                    db.SaveChanges();
                    return 2;
                }
            }
        }

        public void RechazarVenta(int idVenta, String modif) {
            using (var db= new Mapeo("public"))
            {
                var vent = db.ventas.Find(idVenta);
                vent.EstadoVenta = 3;
                vent.modified_by = modif;
                db.SaveChanges();
            }
        }

        public DataTable PeticionCompra(int idVenta)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from venta in db.ventas
                            where venta.IdVenta == idVenta
                            select venta);
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<UEUVenta>(data.ToList<UEUVenta>());
                return res;
            }
        }
        //pendiente 
        public void CalificarCliente(double rango, String comentario, int idEmpresa, int idCliente, int idVenta, String modif) {
            using (var db= new Mapeo("public"))
            {
                //PÁSO 1 INSERTAR EN RANGO
                UEURango rang = new UEURango();
                rang.Rango = rango;
                rang.Comentario = comentario;
                rang.Calificador = 1;
                rang.FechaRango = DateTime.Now;
                rang.IdEmp = idEmpresa;
                rang.IdUsr = idCliente;
                rang.ModifiBy = modif;
                db.rangos.Add(rang);
                db.SaveChanges();
                //PASO 2 OBTENER EL ID DEL RANGO
                var idRango = (from rangods in db.rangos select rangods.IdRango).OrderByDescending(x=>x).Take(1);
                int idrang = idRango.First();
                //PASO 3 ACTUALIZAR LAS VENTAS
                UEUVenta vent= db.ventas.Find(idVenta);
                vent.CalEmp = idrang;
                vent.EstadoVenta = 5;
                vent.modified_by = modif;
                db.SaveChanges();
                //PASO 4 OBTENER CALIFICACION CUENTA
                Double cal = (from ra in db.rangos
                           where ra.IdUsr == idCliente && ra.Calificador == 1
                           select ra.Rango).Sum();
                int cuenta = (from ra in db.rangos
                              where ra.IdUsr == idCliente && ra.Calificador == 1
                              select ra.Rango).Count();
                Double califi = (cal / cuenta);
                califi = Math.Round(califi);
                //PASO 5 ACTUALIZAR EL USUARIO
                UEUsuario user = db.user.Find(idCliente);
                user.Calificacion2 = califi;
                user.ModifBy = modif;
                db.SaveChanges();
                //PASO 6 PREGNTAR SI SE DEBE BLOQUEAR EL USUARIOI
                if (califi < 3)
                {
                    UEUsuario updateUsr = db.user.Find(idCliente);
                    updateUsr.EstUsr = 2;
                    updateUsr.ModifBy = modif;
                    db.SaveChanges();
                    UEUBloqueo bloq = new UEUBloqueo();
                    bloq.fechaInicio = DateTime.Now;
                    bloq.fechaFinal = DateTime.Now.AddDays(90);
                    bloq.idUsuario = idCliente;
                    bloq.modified_by = modif;
                    db.bloqueos.Add(bloq);
                    db.SaveChanges();
                }


            }

        }

        public void SubirArchivo(UEUEmpresa EU_Empresa, String modif)
        {
            using (var db= new Mapeo("public"))
            {
                var _idSolicitud_registro = (from empre in db.empre
                                            join solcitReg in db.sol_reg on empre.Id equals solcitReg.Id_empresa
                                            where empre.Nit == EU_Empresa.Nit
                                            select solcitReg.Id_solici).FirstOrDefault();

                UEUArchivoSolic file= new UEUArchivoSolic();
                file.rutaArchivo = EU_Empresa.RutaArchivo;
                file.nombreArchivo = EU_Empresa.NomArchivo;
                file.idSolicitud_registro = _idSolicitud_registro;
                file.modified_by = modif;
                db.archiv_Emp.Add(file);
                db.SaveChanges();

            }
        }
        //UPDATE PICTURE EMPRESA
        public void CambiarFoto(UEUEmpresa EU_Empresa, String modif) {
            using (var db= new Mapeo("public"))
            {
                var data = (from empresa in db.empre
                           where empresa.Nit == EU_Empresa.Nit
                           select empresa).FirstOrDefault();
                data.NomArchivo = EU_Empresa.NomArchivo;
                data.ModifBy = modif;
                db.SaveChanges();
            }
        }

        //METODO PARA INSERTAR UN COMENTARIO A LA EMPRESA
        public void CrearComentario(UEUComentEmpres comment)
        {
            using (var db = new Mapeo("public"))
            {
                db.comentEmpre.Add(comment);
                db.SaveChanges();
            }
        }

        //METODO PARA CARGAR LAS EMPRESAS ACIVAS
        public List<UEUEmpresa> get_active_comp()
        {
            using (var db= new Mapeo("public"))
            {
                var data = from emp in db.empre
                           where emp.EstadoEmpre == 1
                           select emp;
                return data.ToList<UEUEmpresa>();
            }
        }

    }
}
