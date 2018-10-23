namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_registro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud_registro()
        {
            ArchivoSolicitud = new HashSet<ArchivoSolicitud>();
        }

        [Key]
        public int idSolicitud_registro { get; set; }

        public int estadoSolicitud { get; set; }

        public int idEmpresa { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        [StringLength(1)]
        public string TRIAL723 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArchivoSolicitud> ArchivoSolicitud { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
