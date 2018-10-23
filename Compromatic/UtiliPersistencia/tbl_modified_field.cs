namespace UtiliPersistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("audit.tbl_modified_field")]
    public partial class tbl_modified_field
    {
        public long id { get; set; }

        public long? table_id { get; set; }

        [StringLength(60)]
        public string field_name { get; set; }

        [Column(TypeName = "text")]
        public string old_value { get; set; }

        [Column(TypeName = "text")]
        public string new_value { get; set; }

        [StringLength(1)]
        public string TRIAL367 { get; set; }

        public virtual tbl_modification tbl_modification { get; set; }
    }
}
