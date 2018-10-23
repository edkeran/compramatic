namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MotivoQ")]
    public partial class MotivoQ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MotivoQ()
        {
            Quejas = new HashSet<Quejas>();
        }

        [Key]
        public int idMotivo_queja { get; set; }

        [Required]
        [StringLength(45)]
        public string nomQueja { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }
    }
}
