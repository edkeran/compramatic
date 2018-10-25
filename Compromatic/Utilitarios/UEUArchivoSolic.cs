using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("ArchivoSolicitud", Schema = "dbo")]
    public class UEUArchivoSolic
    {
        private int idAr;
        private string rutaAr;
        private string nomAr;
        private int idSolicitud_reg;
        private string Modif_by;

        [Key]
        [Column("idArchivo")]
        public int idArchivo { get => idAr; set => idAr = value; }
        [Column("rutaArchivo")]
        public string rutaArchivo { get => rutaAr; set => rutaAr = value; }
        [Column("nombreArchivo")]
        public string nombreArchivo { get => nomAr; set => nomAr = value; }
        [Column("idSolicitud_registro")]
        public int idSolicitud_registro { get => idSolicitud_reg; set => idSolicitud_reg = value; }
        [Column("modified_by")]
        public string modified_by { get => Modif_by; set => Modif_by = value; }
    }
}
