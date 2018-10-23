namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("idioma.idioma")]
    public partial class idioma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public idioma()
        {
            controles = new HashSet<controles>();
        }

        [Key]
        public int id_idioma { get; set; }

        [Column(TypeName = "text")]
        public string nombre_idioma { get; set; }

        [StringLength(10)]
        public string terminacion { get; set; }

        [StringLength(1)]
        public string TRIAL605 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<controles> controles { get; set; }
    }
}
