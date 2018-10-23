namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("audit.tbl_modification")]
    public partial class tbl_modification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_modification()
        {
            tbl_modified_field = new HashSet<tbl_modified_field>();
        }

        public long id { get; set; }

        [StringLength(30)]
        public string schema_name { get; set; }

        [StringLength(50)]
        public string table_name { get; set; }

        [StringLength(10)]
        public string operation { get; set; }

        public DateTime? date_time { get; set; }

        [Column(TypeName = "text")]
        public string table_pk { get; set; }

        [StringLength(30)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string user_db { get; set; }

        [StringLength(1)]
        public string TRIAL367 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_modified_field> tbl_modified_field { get; set; }
    }
}
