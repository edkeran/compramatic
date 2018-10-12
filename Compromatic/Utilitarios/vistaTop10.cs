using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaTop10
    {
        private int id_user;
        private int id_prod;
        private DateTime fecha_top;
        private String nom_producto;
        private String nom_empresa;

        public int idUsuario { get => id_user; set => id_user = value; }
        public int idProducto { get => id_prod; set => id_prod = value; }
        public DateTime fechaTop { get => fecha_top; set => fecha_top = value; }
        public string nomProducto { get => nom_producto; set => nom_producto = value; }
        public string nomEmpresa { get => nom_empresa; set => nom_empresa = value; }
    }
}
