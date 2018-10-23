namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rango")]
    public partial class Rango
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rango()
        {
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int idRango { get; set; }

        [Column("rango")]
        public double rango1 { get; set; }

        [Required]
        [StringLength(100)]
        public string comentarios { get; set; }

        public int calificador { get; set; }

        public DateTime fechaRango { get; set; }

        public int idEmpresa { get; set; }

        public int idUsuario { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
