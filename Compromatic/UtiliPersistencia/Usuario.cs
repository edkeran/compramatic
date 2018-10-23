namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Bloqueos = new HashSet<Bloqueos>();
            Quejas = new HashSet<Quejas>();
            Rango = new HashSet<Rango>();
            Reporte = new HashSet<Reporte>();
            Top_10 = new HashSet<Top_10>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(20)]
        public string nomUsuario { get; set; }

        [Required]
        [StringLength(20)]
        public string apeUsuario { get; set; }

        [Required]
        [StringLength(15)]
        public string telUsuario { get; set; }

        [Required]
        [StringLength(30)]
        public string correoUsuario { get; set; }

        [Required]
        [StringLength(45)]
        public string passUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string ccUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string dirUsuario { get; set; }

        [StringLength(80)]
        public string rutaArchivo { get; set; }

        [StringLength(80)]
        public string nomArchivo { get; set; }

        public int estadoUsuario { get; set; }

        public DateTime fechaCreacion_usuario { get; set; }

        public int idTipo { get; set; }

        public double calificacionUsuario { get; set; }

        [Column(TypeName = "text")]
        public string modified_by { get; set; }

        public int Sesiones_Abiertas { get; set; }

        public DateTime? inicio_bloqueo { get; set; }

        public DateTime? fin_bloqueo { get; set; }

        public int intentos { get; set; }

        [StringLength(1)]
        public string TRIAL726 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bloqueos> Bloqueos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quejas> Quejas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rango> Rango { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reporte> Reporte { get; set; }

        public virtual Rol Rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Top_10> Top_10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
