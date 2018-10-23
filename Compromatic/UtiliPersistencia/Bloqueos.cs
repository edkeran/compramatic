namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bloqueos
    {
        [Key]
        public int idBloqueo { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFinal { get; set; }

        public int? idEmpresa { get; set; }

        public int? idUsuario { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL720 { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
