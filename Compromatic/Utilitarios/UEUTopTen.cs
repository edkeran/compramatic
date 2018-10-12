using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Utilitarios
{
    [Serializable]
    [Table("Top_10", Schema = "public")]
    public class UEUTopTen
    {
        private int id_prod;
        private int id_usr;
        private int id_top;
        private DateTime fecha_top= DateTime.Now;
        private String Modified_by;

        [Column("idProducto")]
        public int Id_prod { get => id_prod; set => id_prod = value; }
        [Column("idUsuario")]
        public int Id_usr { get => id_usr; set => id_usr = value; }
        [Key]
        [Column("idTop")]
        public int Id_top { get => id_top; set => id_top = value; }
        [Column("fechaTop")]
        public DateTime Fecha_top { get => fecha_top; set => fecha_top = value; }
        [Column("modified_by")]
        public string Modified_by1 { get => Modified_by; set => Modified_by = value; }
    }
}
