﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Producto
    {
        //insert Product
        public void insertar_producto(UEUProducto produ)
        {
            using (var db = new Mapeo("public"))
            {
                db.productos.Add(produ);
                db.SaveChanges();
                DBAuditoria.insert(produ, this.crearAcceso(), "dbo", "Producto");
            }
        }

        //METODO PARA ELIMINAR PRODUCTO
        public void delete_producto(UEUProducto data)
        {
            using (var db= new Mapeo("public"))
            {
                var prod_del = db.productos.Find(data.Id);
                UEUProducto oldProd = (UEUProducto)prod_del.Clone();
                prod_del.Estado_producto = 0;
                prod_del.ModifBy = data.ModifBy;
                db.SaveChanges();
                DBAuditoria.update(prod_del,oldProd,crearAcceso(),"dbo","Producto");

            }
        }

        //METODO PARA ACTUALIZAR UN PRODUCTO
        public void actualizar_producto(UEUProducto prod)
        {
            using (var db = new Mapeo("public"))
            {
                var update = db.productos.Find(prod.Id);
                UEUProducto old_Prod = (UEUProducto)update.Clone();
                update.Nombre = prod.Nombre;
                update.Cantidad = prod.Cantidad;
                update.Precio = prod.Precio;
                update.Descripcion = prod.Descripcion;
                update.Categoria = prod.Categoria;
                update.Id = prod.Id;
                update.ModifBy = prod.ModifBy;
                db.SaveChanges();
                DBAuditoria.update(update, old_Prod, crearAcceso(), "dbo", "Producto");
            }

        }

        //METODO PARA TRAER TODOS LOS PRODUCTOS POR EMPRESA
        public List<UEUProducto> traer_productos(int id_emp)
        {
            using (var db= new Mapeo("public"))
            {
                //SE TRAEN LOS PRODUCTOS ACTIVOS DEL PROYECTO
                var producto = (from dao in db.productos
                               join categ in db.categ on dao.Categoria equals categ.Id_cate
                               join empres in db.empre on dao.IdEmpresa equals empres.Id
                               select dao).Where(y=>y.IdEmpresa == id_emp && y.Estado_producto==1).ToList<UEUProducto>();
                var otrosDatos = (from dao in db.productos
                                  join categ in db.categ on dao.Categoria equals categ.Id_cate
                                  join empres in db.empre on dao.IdEmpresa equals empres.Id
                                  where dao.IdEmpresa==id_emp && dao.Estado_producto==1
                                  select new U_Aux_Vista_Products
                                  {
                                      Nom_Empresa=empres.Nombre,
                                      Nom_Categoria=categ.nomCategoria,
                                      Id_Categoria=categ.Id_cate,
                                      Nom_Archivo=empres.NomArchivo
                                  }).ToList<U_Aux_Vista_Products>();
                //SE RETORNA LA LISTA COMPLETA DE PRODUCTOS 
                for (int i = 0; i < producto.Count; i++)
                {
                    producto.ElementAt(i).NomArchivo = otrosDatos.ElementAt(i).Nom_Archivo;
                    producto.ElementAt(i).NomEmp = otrosDatos.ElementAt(i).Nom_Empresa;
                    producto.ElementAt(i).NomCategoria = otrosDatos.ElementAt(i).Nom_Categoria;
                }

                return producto;
            }
        }

        //METODO PARA SUBIR FOTOS DE UN PRODUCTO
        public void subir_fotos(UEUFotoProd picture)
        {
            using (var db= new Mapeo("public"))
            {
                db.fotosPro.Add(picture);
                db.SaveChanges();
                DBAuditoria.insert(picture,crearAcceso(),"dbo", "Foto_producto");
            }
        }

        //METODO PARA AÑADIR UN NUEVO TAG
        public void añadir_tag(UEUTag data)
        {
            using (var db= new Mapeo("public"))
            {
                db.tag.Add(data);
                db.SaveChanges();
                DBAuditoria.insert(data, crearAcceso(), "dbo", "Palabra_clave");
            }
        }

        //METODO PARA ELIMINAR UN TAG
        public void delete_tag(UEUTag tagg)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.tag.Find(tagg.IdTag);
                db.Entry(data).State = EntityState.Deleted;
                db.SaveChanges();
                DBAuditoria.delete(data, crearAcceso(), "dbo", "Palabra_clave");
            }
        }

        //METODO PARA MODIFICAR LA ALERTA DEL PRODUCTO
        public void modify_alert(UEUProducto nData)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.productos.Find(nData.Id);
                UEUProducto old_Prod = (UEUProducto)data.Clone();
                data.BajoInventario = nData.BajoInventario;
                data.ModifBy = nData.ModifBy;
                db.SaveChanges();
                DBAuditoria.update(data, old_Prod, crearAcceso(), "dbo", "Producto");
            }
        }

        //METODO PARA OBTENER TODOS LOS PRODUCTOS ACTIVOS DE LAS EMPRESAS
        public DataTable get_all_products()
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from x in db.empre
                            join h in db.productos on x.Id equals h.IdEmpresa
                            join l in db.categ on h.Categoria equals l.Id_cate
                            where h.Estado_producto == 1
                            select new UEUVista_Tot_Prod
                            {
                                _nomcategoria=l.nomCategoria,
                                _idproducto=h.Id,
                                _nomproducto=h.Nombre,
                                _desproducto=h.Descripcion,
                                _precioproducto=h.Precio,
                                _canproducto=h.Cantidad,
                                _nomempresa=x.Nombre,
                                _idempresa=x.Id,
                                _foto=(from k in db.fotosPro where h.Id == k.Id_Product && h.Estado_producto == 1 select k).Take(1).FirstOrDefault().NomArchi.ToString()
                            });
                List<UEUVista_Tot_Prod> res = data.ToList<UEUVista_Tot_Prod>();
                foreach(UEUVista_Tot_Prod aux in res)
                {
                    if (aux._foto.Equals(""))
                    {
                        aux._foto = "default.png";
                    }
                    aux._foto.ToString();
                }
                ListToDataTable convert = new ListToDataTable();
                DataTable retorno=convert.ToDataTable<UEUVista_Tot_Prod>(res);
                return retorno;
            }
        }

        //METODO PARA TRAER LOS PRODUCTOS ESCRITOS EN LA BUSQUEDA
        public DataTable find_products(string busqueda)
        {
            using (var db=new Mapeo("public"))
            {
                var data = (from x in db.empre
                            join h in db.productos on x.Id equals h.IdEmpresa
                            join l in db.categ on h.Categoria equals l.Id_cate
                            where h.Estado_producto == 1 && h.Nombre.Contains(busqueda)
                            select new UEUVista_Tot_Prod
                            {
                                _nomcategoria = l.nomCategoria,
                                _idproducto = h.Id,
                                _nomproducto = h.Nombre,
                                _desproducto = h.Descripcion,
                                _precioproducto = h.Precio,
                                _canproducto = h.Cantidad,
                                _nomempresa = x.Nombre,
                                _idempresa = x.Id,
                                _foto = (from k in db.fotosPro where h.Id == k.Id_Product && h.Estado_producto == 1 select k).Take(1).FirstOrDefault().NomArchi.ToString()
                            });
                List<UEUVista_Tot_Prod> res = data.ToList<UEUVista_Tot_Prod>();
                foreach (UEUVista_Tot_Prod aux in res)
                {
                    if (aux._foto.Equals(""))
                    {
                        aux._foto = "default.png";
                    }
                    aux._foto.ToString();
                }
                ListToDataTable convert = new ListToDataTable();
                DataTable retorno = convert.ToDataTable<UEUVista_Tot_Prod>(res);
                return retorno;
            }
        }

        public List<UEUVista_Tot_Prod> find_products2(int categ)
        {
            using (var db = new Mapeo("public"))
            {
                var data = (from x in db.empre
                            join h in db.productos on x.Id equals h.IdEmpresa
                            join l in db.categ on h.Categoria equals l.Id_cate
                            where h.Estado_producto == 1 && h.Categoria==categ
                            select new UEUVista_Tot_Prod
                            {
                                _nomcategoria = l.nomCategoria,
                                _idproducto = h.Id,
                                _nomproducto = h.Nombre,
                                _desproducto = h.Descripcion,
                                _precioproducto = h.Precio,
                                _canproducto = h.Cantidad,
                                _nomempresa = x.Nombre,
                                _idempresa = x.Id,
                                _foto = (from k in db.fotosPro where h.Id == k.Id_Product && h.Estado_producto == 1 select k).Take(1).FirstOrDefault().NomArchi.ToString()
                            });
                List<UEUVista_Tot_Prod> res = data.ToList<UEUVista_Tot_Prod>();
                return res;
            }
        }

        //METODO PARA OBTENER UN PRODUCTO
        public DataTable obtener_producto(int id_produ)
        {
            using (var db = new Mapeo("public"))
            {
                var datos = (from p in db.productos join c in db.categ on p.Categoria equals c.Id_cate
                             join e in db.empre on p.IdEmpresa equals e.Id
                             select new vistaProductoSingle  {
                                 nomProducto=p.Nombre,
                                 idProducto=p.Id,
                                 canProducto=p.Cantidad,
                                 precioProducto=(double)p.Precio,
                                 desProducto=p.Descripcion,
                                 estadoProducto=p.Estado_producto,
                                 bajoInventario=p.BajoInventario,
                                 idEmpresa=p.IdEmpresa,
                                 nomCategoria=c.nomCategoria,
                                 nomEmpresa=e.Nombre,
                                 idCategoria=p.Categoria,
                                 nomArchivo=e.NomArchivo
                             });
                datos = (from d in datos where d.idProducto == id_produ select d);
                ListToDataTable conv = new ListToDataTable();
                DataTable data = conv.ToDataTable<vistaProductoSingle>(datos.ToList<vistaProductoSingle>());
                data.Rows[0]["nomProducto"].ToString();
                return data;

            }
        }

        public DataTable get_picture_product(int id_produ)
        {
            using (var db= new Mapeo("public"))
            {
                var pictures = db.fotosPro.Where(x=>x.Id_Product==id_produ).ToList<UEUFotoProd>();
                ListToDataTable conv = new ListToDataTable();
                return conv.ToDataTable<UEUFotoProd>(pictures);
            }
        }

        public void delete_picture(UEUProducto prod)
        {
            using (var db= new Mapeo("public"))
            {
                var update=db.fotosPro.Find(prod.IdFoto);
                UEUFotoProd old_Prod = (UEUFotoProd)update.Clone();
                update.Modif_By = prod.ModifBy;
                db.SaveChanges();
                DBAuditoria.update(update, old_Prod, crearAcceso(), "dbo", "Foto_producto");

                var delete = db.fotosPro.Find(prod.IdFoto);
                db.Entry(delete).State = EntityState.Deleted;
                db.SaveChanges();
                DBAuditoria.delete(prod, crearAcceso(), "dbo", "Foto_producto");
            }
        }

        public DataTable MostrarCategoria()
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.categ.OrderBy(x=>x.Id_cate);
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<UEUCategoria>(data.ToList<UEUCategoria>());
                return res;
            }
        }

        public void ModificarInventario(UEUProducto EU_Producto, string modif)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.productos.Find(EU_Producto.Id);
                UEUProducto old_Prod = (UEUProducto)data.Clone();
                data.Cantidad = EU_Producto.Cantidad;
                data.BajoInventario = EU_Producto.BajoInventario;
                data.ModifBy = modif;
                db.SaveChanges();
                DBAuditoria.update(data,old_Prod,crearAcceso(),"dbo","Producto");

            }
        }

        public void CompraProducto(UEUVenta venta, string modif)
        {
            using (var db= new Mapeo("public"))
            {
                venta.modified_by = modif;
                db.ventas.Add(venta);
                db.SaveChanges();
                DBAuditoria.insert(venta,crearAcceso(),"dbo","Venta");
            }
        }

        public void ConfirmarRecibido(int idVenta, int estado, string modif)
        {
            using (var db= new Mapeo("public"))
            {
                var update = db.ventas.Find(idVenta);
                UEUVenta old_Vent = (UEUVenta)update.Clone();
                update.EstadoVenta = estado;
                update.FechaEntr = DateTime.Now;
                update.modified_by = modif;
                db.SaveChanges();
                DBAuditoria.update(update, old_Vent, crearAcceso(), "dbo", "Venta");
            }
        }

        public EAcceso crearAcceso()
        {
            EAcceso acc = new EAcceso();
            acc.Ip = EAcceso.obtenerIP();
            acc.Mac = EAcceso.obtenerMAC();
            acc.Id = 0;
            acc.IdUsuario = 0;
            acc.FechaInicio = DateTime.Now.ToString();
            acc.FechaFin = DateTime.Now.ToString();
            return acc;
        }


        //public void ProductosDetalle(int idPdto)
        //{
        //    using (var data= new Mapeo("public"))
        //    {

        //    }
        //}
    }
}
