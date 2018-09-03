using System;
using System.Data;

namespace Utilitarios
{
    public class U_aux_PeticionesCompra
    {
        private DataTable producto;
        private DataTable producto2;
        private DataTable producto3;
        private DataTable producto4;
        private String redireccion;

        public DataTable Producto { get => producto; set => producto = value; }
        public DataTable Producto2 { get => producto2; set => producto2 = value; }
        public DataTable Producto3 { get => producto3; set => producto3 = value; }
        public DataTable Producto4 { get => producto4; set => producto4 = value; }
        public string Redireccion { get => redireccion; set => redireccion = value; }
    }
}
