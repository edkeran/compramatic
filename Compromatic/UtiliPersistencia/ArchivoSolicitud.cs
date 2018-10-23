namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArchivoSolicitud")]
    public partial class ArchivoSolicitud
    {
        [Key]
        public int idArchivo { get; set; }

        [Required]
        [StringLength(255)]
        public string rutaArchivo { get; set; }

        [Required]
        [StringLength(255)]
        public string nombreArchivo { get; set; }

        public int idSolicitud_registro { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL720 { get; set; }

        public virtual Solicitud_registro Solicitud_registro { get; set; }
    }
}
