namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            Bloqueos = new HashSet<Bloqueos>();
            Producto = new HashSet<Producto>();
            Quejas = new HashSet<Quejas>();
            Rango = new HashSet<Rango>();
            Solicitud_registro = new HashSet<Solicitud_registro>();
        }

        [Key]
        public int idEmpresa { get; set; }

        [Required]
        [StringLength(45)]
        public string nomEmpresa { get; set; }

        [Required]
        [StringLength(15)]
        public string telEmpresa { get; set; }

        [Required]
        [StringLength(30)]
        public string correoEmpresa { get; set; }

        [Required]
        [StringLength(20)]
        public string dirEmpresa { get; set; }

        [Required]
        [StringLength(15)]
        public string nitEmpresa { get; set; }

        [StringLength(80)]
        public string nomArchivo { get; set; }

        [StringLength(80)]
        public string rutaArchivo { get; set; }

        public int estadoEmpresa { get; set; }

        public double calificacionEmpresa { get; set; }

        public int idTipo { get; set; }

        [Required]
        [StringLength(45)]
        public string passEmpresa { get; set; }

        public DateTime fechaCreacion_empresa { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        public int Sesiones_Abiertas { get; set; }

        public bool bloqueo { get; set; }

        public DateTime? inicio_bloqueo { get; set; }

        public DateTime? fin_bloqueo { get; set; }

        public int intentos { get; set; }

        [StringLength(1)]
        public string TRIAL720 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bloqueos> Bloqueos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rango> Rango { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_registro> Solicitud_registro { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
