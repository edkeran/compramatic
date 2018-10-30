using DatosPersistencia;
using System.Collections.Generic;
using Utilitarios;

namespace Logica
{
    public class L_WebService
    {
        public List<UEUVista_Tot_Prod> busqueda(string data)
        {
            DB_Producto busq= new DB_Producto();
            List<UEUVista_Tot_Prod> res = busq.find_products2(data);
            return res;
        }
    }
}
