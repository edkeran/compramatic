using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_aux_AdminProd
    {
        private String redir="0";
        private DataTable productos;
        private String idProducto="";

        public string Redir { get => redir; set => redir = value; }
        public String IdProducto { get => idProducto; set => idProducto = value; }
        public DataTable Productos { get => productos; set => productos = value; }
    }
}
