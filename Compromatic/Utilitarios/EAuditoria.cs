using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("auditoria", Schema = "audit")]
    public class EAuditoria
    {
        private int id;

        private string fecha;

        private string accion;

        private string usuarioDB;

        private string esquema;

        private string tabla;

        private int idAcceso;

        private string data;

        private EAuditoria()
        {
            Id = -1;
            Fecha = DateTime.MinValue.ToString();
            Accion = "";
            UsuarioDB = "";
            Esquema = "";
            Tabla = "";
            IdAcceso = -1;
            Data = "{}";
        }

        public static EAuditoria newEmpty()
        {
            return new EAuditoria();
        }

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("fecha")]
        public string Fecha { get => fecha; set => fecha = value; }

        [Column("accion")]
        public string Accion { get => accion; set => accion = value; }

        [Column("usuariodb")]
        public string UsuarioDB { get => usuarioDB; set => usuarioDB = value; }

        [Column("esquema")]
        public string Esquema { get => esquema; set => esquema = value; }

        [Column("tabla")]
        public string Tabla { get => tabla; set => tabla = value; }

        [Column("id_acceso")]
        public int IdAcceso { get => idAcceso; set => idAcceso = value; }

        [Column("data")]
        public string Data { get => data; set => data = value; }
    }
}