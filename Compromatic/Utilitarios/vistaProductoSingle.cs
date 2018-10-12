using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaProductoSingle
    {
            private string NomProducto;
            private int IdProducto;
            private int CanProducto;
            private double PrecioProducto;
            private string DesProducto;
            private int EstadoProducto;
            private int BajoInventario;
            private int IdEmpresa;
            private string NomCategoria;
            private string NomEmpresa;
            private int IdCategoria;
            private string NomArchivo;

        public string nomProducto { get => NomProducto; set => NomProducto = value; }
        public int idProducto { get => IdProducto; set => IdProducto = value; }
        public int canProducto { get => CanProducto; set => CanProducto = value; }
        public double precioProducto { get => PrecioProducto; set => PrecioProducto = value; }
        public string desProducto { get => DesProducto; set => DesProducto = value; }
        public int estadoProducto { get => EstadoProducto; set => EstadoProducto = value; }
        public int bajoInventario { get => BajoInventario; set => BajoInventario = value; }
        public int idEmpresa { get => IdEmpresa; set => IdEmpresa = value; }
        public string nomCategoria { get => NomCategoria; set => NomCategoria = value; }
        public string nomEmpresa { get => NomEmpresa; set => NomEmpresa = value; }
        public int idCategoria { get => IdCategoria; set => IdCategoria = value; }
        public string nomArchivo { get => NomArchivo; set => NomArchivo = value; }
    }
}
