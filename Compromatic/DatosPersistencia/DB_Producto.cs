using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Producto
    {
        //SETEAR LIBRERIAS
        public void insertar_producto(UEUProducto produ)
        {
            using (var db = new Mapeo("public"))
            {
                db.productos.Add(produ);
                db.SaveChanges();
            }
        }

        //METODO PARA ELIMINAR PRODUCTO
        public void delete_producto(UEUProducto data)
        {
            using (var db= new Mapeo("public"))
            {
                var prod_del = db.productos.Find(data.Id);
                prod_del.Estado_producto = 0;
                prod_del.ModifBy = data.ModifBy;
                db.SaveChanges();

            }
        }

        //METODO PARA ACTUALIZAR UN PRODUCTO
        public void actualizar_producto(UEUProducto prod)
        {
            using (var db = new Mapeo("public"))
            {
                var update = db.productos.Find(prod.Id);
                update.Nombre = prod.Nombre;
                update.Cantidad = prod.Cantidad;
                update.Precio = prod.Precio;
                update.Descripcion = prod.Descripcion;
                update.Categoria = prod.Categoria;
                update.Id = prod.Id;
                update.ModifBy = prod.ModifBy;
                db.SaveChanges();
            }

        }

        //METODO PARA TRAER TODOS LOS PRODUCTOS
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
            }
        }

        //METODO PARA AÑADIR UN NUEVO TAG
        public void añadir_tag(UEUTag data)
        {
            using (var db= new Mapeo("public"))
            {
                db.tag.Add(data);
                db.SaveChanges();
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
            }
        }

        //METODO PARA MODIFICAR LA ALERTA DEL PRODUCTO
        public void modify_alert(UEUProducto nData)
        {
            using (var db= new Mapeo("public"))
            {
                var data = db.productos.Find(nData.Id);
                data.BajoInventario = nData.BajoInventario;
                data.ModifBy = nData.ModifBy;
                db.SaveChanges();
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
    }
}
