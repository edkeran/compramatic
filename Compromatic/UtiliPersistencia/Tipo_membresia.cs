namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_membresia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_membresia()
        {
            Membresia = new HashSet<Membresia>();
        }

        [Key]
        public int idTipo_membresia { get; set; }

        public int tiempoMembresia { get; set; }

        [Required]
        [StringLength(15)]
        public string nomMembresia { get; set; }

        public double valorMembresia { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membresia> Membresia { get; set; }
    }
}
