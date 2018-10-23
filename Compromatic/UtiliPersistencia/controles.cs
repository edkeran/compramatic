namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("idioma.controles")]
    public partial class controles
    {
        [Key]
        public int id_control { get; set; }

        [StringLength(100)]
        public string nom_control { get; set; }

        public int idioma_id { get; set; }

        public int form_id { get; set; }

        [Column(TypeName = "text")]
        public string texto { get; set; }

        [StringLength(1)]
        public string TRIAL605 { get; set; }

        public virtual formulario formulario { get; set; }

        public virtual idioma idioma { get; set; }
    }
}
