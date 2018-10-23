namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Palabra_clave
    {
        [Key]
        public int idPalabra_clave { get; set; }

        [Required]
        [StringLength(15)]
        public string palabra { get; set; }

        public int idProducto { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
