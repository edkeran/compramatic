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

        //METODO PARA TRAER EL PRODUCTO A EDITAR
        public void traer_productos(UEUProducto prod)
        {
            using (var db= new Mapeo("public"))
            {
                //SE TRAEN LOS PRODUCTOS ACTIVOS DEL PROYECTO
                var producto = db.productos.Where(y=>y.IdEmpresa==prod.IdEmpresa).Where(x=>x.Estado_producto == 1).ToList<UEUProducto>();
                //SE RETORNA LA LISTA COMPLETA DE PRODUCTOS 
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
    }
}
