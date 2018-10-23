namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("idioma.formulario")]
    public partial class formulario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formulario()
        {
            controles = new HashSet<controles>();
        }

        [Key]
        public int id_form { get; set; }

        [StringLength(200)]
        public string nombre_form { get; set; }

        [Column(TypeName = "text")]
        public string url { get; set; }

        [StringLength(1)]
        public string TRIAL605 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<controles> controles { get; set; }
    }
}
