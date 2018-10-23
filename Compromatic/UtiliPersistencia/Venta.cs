namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venta")]
    public partial class Venta
    {
        [Key]
        public int idVenta { get; set; }

        public DateTime fechaVenta { get; set; }

        public int cantVenta { get; set; }

        public int estadoVenta { get; set; }

        public double valorVenta { get; set; }

        public int idProducto { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaEntrega { get; set; }

        public int? calEmp { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL726 { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Rango Rango { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
