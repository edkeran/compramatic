namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Membresia")]
    public partial class Membresia
    {
        [Key]
        public int idMembresia { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public int estadoMembresia { get; set; }

        public int idTipo_membresia { get; set; }

        public int idEmpresa { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL720 { get; set; }

        public virtual Tipo_membresia Tipo_membresia { get; set; }
    }
}
