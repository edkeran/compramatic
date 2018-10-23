namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Top_10
    {
        public int idProducto { get; set; }

        public int idUsuario { get; set; }

        [Key]
        public int idTop { get; set; }

        public DateTime fechaTop { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL726 { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
