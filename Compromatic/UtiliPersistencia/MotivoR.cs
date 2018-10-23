namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MotivoR")]
    public partial class MotivoR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MotivoR()
        {
            Reporte = new HashSet<Reporte>();
        }

        [Key]
        public int idMotivoR { get; set; }

        [Required]
        [StringLength(25)]
        public string desMotivo { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reporte> Reporte { get; set; }
    }
}
