using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Admin
    {
        public int tot_clients()
        {
            using (var db = new Mapeo("public"))
            {
                int count = (from usr in db.user select usr.IdUsr).Count();
                return count;
            }
        }

        public double tot_ventas()
        {
            using (var db = new Mapeo("public"))
            {
                //query
                double ventas = (from vent in db.ventas
                              where vent.EstadoVenta == 4
                              select vent.Valor).Sum();
                return ventas;
            }
        }

        public int total_empr()
        {
            using (var db = new Mapeo("public"))
            {
                int tot_comp = (from empr in db.empre select empr.Id).Count();
                return tot_comp;
            }
        }

        //OBTENER TODAS LAS NOTIFICACIONES
        public int llenar_notificacion()
        {
            using (var db = new Mapeo("public"))
            {
                int data = (from solitReg in db.sol_reg
                            where solitReg.Estado_solici == 1
                            select solitReg.Id_solici).Count();
                return data;
            }
        }

        //NOTIFICACIONES ACEPTADAS
        public int llenar_notificacionAccept()
        {
            using (var db = new Mapeo("public"))
            {
                int data = (from solici in db.sol_reg
                            where solici.Estado_solici == 0
                            select solici.Id_solici).Count();
                return data;
            }
        }

        //NOTIFICACIONES RECHAZADAS
        public int llenar_notificacionRechaz()
        {
            using (var db = new Mapeo("public"))
            {
                int data = (from h in db.sol_reg
                            where h.Estado_solici == 3
                            select h.Id_solici).Count();
                return data;
            }
        }

        //METODO PARA TRAER EL PQR DE LAS EMPRESAS
        public DataTable pqr_empresa()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from qj in db.inf_quejas
                            join emp in db.empre on qj.IdEmpre equals emp.Id
                            join usr in db.user on qj.Id_user equals usr.IdUsr
                            join Mq in db.quejas on qj.Id_Moti_Quej equals Mq.Id_queja
                            where qj.IdEmpre != null
                            where qj.ReceptorQ == 2
                            select new vistaPQRempresa
                            {
                                desQueja = qj.DesQuej,
                                fechaQueja = qj.FechaQuj,
                                nomQueja = Mq.Nom_queja,
                                Emisor = usr.NomUsr,
                                foto = emp.RutaArchivo + emp.NomArchivo
                            }).Distinct();

                List<vistaPQRempresa> datos = data.ToList<vistaPQRempresa>();
                ListToDataTable conv = new ListToDataTable();
                DataTable respuesta = conv.ToDataTable<vistaPQRempresa>(datos);
                return respuesta;
            }
        }

        //METODO PARA TRAER LOS REPORTES
        public DataTable Reportes()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from Empresa in db.empre
                            join Producto in db.productos on Empresa.Id equals Producto.IdEmpresa
                            join Reporte in db.reporte_T on Producto.Id equals Reporte.idProducto
                            join Usuario in db.user on Reporte.idUsuario equals Usuario.IdUsr
                            join MotivoR in db.report on Reporte.idMotivoR equals MotivoR.IdMoti
                            select new vista_reportesAdministrador
                            {
                                rutaArchivo = Empresa.RutaArchivo + Empresa.NomArchivo,
                                nomEmpresa = Empresa.Nombre,
                                nomUsuario = Usuario.NomUsr,
                                nomProducto = Producto.Nombre,
                                desMotivo = MotivoR.DesMotiv,
                                fechaReporte=Reporte.fechaReporte,
                                correoEmpresa = Empresa.Correo,
                                idProducto=Reporte.idProducto
                            });
                List<vista_reportesAdministrador> res = data.ToList<vista_reportesAdministrador>();
                ListToDataTable conv = new ListToDataTable();
                DataTable retorno=conv.ToDataTable<vista_reportesAdministrador>(res);
                return retorno;
            }

        }

        //METODO PARA TRAER LOS ARCHIVOS DE LAS EMPRESAS
        public DataTable ArchivosEmpresa(int id)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from files in db.archiv_Emp where files.idSolicitud_registro==id
                            select files);
                List<UEUArchivoSolic> inf = data.ToList<UEUArchivoSolic>();
                foreach(UEUArchivoSolic aux in inf)
                {
                    aux.rutaArchivo = aux.rutaArchivo + aux.nombreArchivo;
                }
                ListToDataTable conv = new ListToDataTable();
                DataTable response = conv.ToDataTable<UEUArchivoSolic>(inf);
                return response;
            }
        }

        //METODO PARA MODIFICAR EL ESTADO DE LA EMPRESA RECIEN INSCRITA EN LA PLATAFORMA
        public void ModificarEstados(int id, int estadoEmpresa, int estadoSolicitud, string usuario)
        {
            using (var db = new Mapeo("public"))
            {
                //PASO 1 OBTENER EL ID DE LA EMPRESA
                int idEmp = (from empresa in db.empre join solcitud_reg in db.sol_reg on empresa.Id equals solcitud_reg.Id_empresa
                         where solcitud_reg.Id_solici == id select empresa.Id).FirstOrDefault();
                
                //PASO 2 CAMBIAR EL ESTADO DE LA EMPRESA
                var estEmp = db.empre.Find(idEmp);
                estEmp.EstadoEmpre = estadoEmpresa;
                estEmp.ModifBy = usuario;
                db.SaveChanges();
                //PASO 3 ACTUALIZAR LA SOLICITUD DEL REGISTRO
                var solic = (from estSolict in db.sol_reg where estSolict.Id_empresa == idEmp select estSolict).FirstOrDefault();
                solic.Estado_solici = estadoSolicitud;
                solic.ModifBy = usuario;
                db.SaveChanges();
            }
        }
        //SHOW COMPANY
        public DataTable MostrarEmpresaId(int id)
        {
            using(var db= new Mapeo("public"))
            {
                var data = (from v in db.ventas
                           from e in db.empre
                           from p in db.productos
                           where v.IdProducto == p.Id && p.IdEmpresa == e.Id
                           select new vistaHistorialCompra
                           {
                               idVenta=v.IdVenta,
                               fechaVenta=v.FechaVent,
                               idUsuario=v.IdUsr,
                               fechaEntrega=v.FechaEntr,
                               cantVenta=v.Cantidad,
                               estadoVenta=v.EstadoVenta,
                               valorVenta=v.Valor,
                               nomProducto=p.Nombre,
                               nomEmpresa=e.Nombre,
                               idEmpresa=e.Id,
                               calificacionEmpresa=e.Calificacion
                           }).Distinct();
                ListToDataTable conv = new ListToDataTable();
                DataTable res= conv.ToDataTable<vistaHistorialCompra>(data.ToList<vistaHistorialCompra>());
                return res;
            }
        }
        //FUNCION HP
        public DataTable MostrarVentasPorCategoria()
        {
            using(var db= new Mapeo("public"))
            {
                var data = (from catego in db.categ
                            join produ in db.productos on catego.Id_cate equals produ.Categoria
                            join venta in db.ventas on produ.Id equals venta.IdProducto
                            join empres in db.empre on produ.IdEmpresa equals empres.Id
                            where venta.EstadoVenta == 4
                            select new
                            {
                                venta.IdVenta,
                                catego.nomCategoria,
                                venta.Valor,
                                inf = (from prod in db.productos
                                       where catego.Id_cate == prod.Categoria
                                       select prod.Categoria).GroupBy(x=>x).FirstOrDefault()
                           }).GroupBy(x=>x.nomCategoria);
                List<vistaMostTotByCat> retorno = new List<vistaMostTotByCat>();

                foreach(var group in data)
                {
                    vistaMostTotByCat aux = new vistaMostTotByCat();
                    aux.nomCategoria= group.Key;
                    aux.ventas= group.Count(z => z.IdVenta != 0);
                    aux.valor = group.Sum(y => y.Valor).ToString("C");
                    foreach(var empre in group)
                    {
                        aux.empresas= empre.inf.Count();
                        retorno.Add(aux);
                        break;
                    }
                }
                ListToDataTable conv = new ListToDataTable();
                DataTable ret = conv.ToDataTable<vistaMostTotByCat>(retorno);
                return ret;
            }
        }

        public DataTable ProductosBajoI(int id_empresa) {
            using (var db= new Mapeo("public"))
            {
                var inf = from producto in db.productos
                          join catego in db.categ on producto.Categoria equals catego.Id_cate
                          join empresa in db.empre on producto.IdEmpresa equals empresa.Id
                          where empresa.Id==id_empresa && producto.Estado_producto==1 && producto.Cantidad<=producto.BajoInventario
                          select new vistaProductoSingle
                          {
                              nomProducto=producto.Nombre,
                              idProducto=producto.Id,
                              canProducto=producto.Cantidad,
                              precioProducto=producto.Precio,
                              desProducto=producto.Descripcion,
                              estadoProducto=producto.Estado_producto,
                              bajoInventario=producto.BajoInventario,
                              idEmpresa=producto.IdEmpresa,
                              nomCategoria=catego.nomCategoria,
                              nomEmpresa=empresa.Nombre,
                              idCategoria=producto.Categoria,
                              nomArchivo=empresa.Nombre
                          };
                ListToDataTable conv = new ListToDataTable();
                DataTable respuesta = conv.ToDataTable<vistaProductoSingle>(inf.ToList<vistaProductoSingle>());
                return respuesta;
            }
        }
    }
}
