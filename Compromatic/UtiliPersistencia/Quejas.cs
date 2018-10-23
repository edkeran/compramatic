namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quejas
    {
        [Key]
        public int idQueja { get; set; }

        [Required]
        [StringLength(800)]
        public string desQueja { get; set; }

        public int? idEmpresa { get; set; }

        public int idMotivo_queja { get; set; }

        public int? idUsuario { get; set; }

        public int receptorQ { get; set; }

        public DateTime fechaQueja { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual MotivoQ MotivoQ { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
