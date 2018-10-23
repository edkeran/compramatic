namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Foto_producto
    {
        [Key]
        public int idFoto_producto { get; set; }

        [Required]
        [StringLength(80)]
        public string rutaArchivo { get; set; }

        [Required]
        [StringLength(80)]
        public string nomArchivo { get; set; }

        public int idProducto { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL720 { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
