using DatosPersistencia;
using System.Collections.Generic;
using Utilitarios;

namespace Logica
{
    public class L_WebService
    {
        public List<UEUVista_Tot_Prod> busqueda(int id_categoria)
        {
            DB_Producto busq= new DB_Producto();
            List<UEUVista_Tot_Prod> res = busq.find_products2(id_categoria);
            return res;
        }

        public List<UEUCategoria> get_all_Cate()
        {
            DBCategoria daoCateg = new DBCategoria();
            return daoCateg.leer_categorias();
        }
    }
}
