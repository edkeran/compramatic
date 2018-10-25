using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Bloqueos", Schema = "dbo")]
    public class UEUBloqueo
    {
        private int IdBloqueo;
        private DateTime FechaInicio;
        private DateTime FechaFinal;
        private int? IdEmpresa;
        private int IdUsuario;
        private string Modified_by;

        [Key]
        public int idBloqueo { get => IdBloqueo; set => IdBloqueo = value; }
        public DateTime fechaInicio { get => FechaInicio; set => FechaInicio = value; }
        public DateTime fechaFinal { get => FechaFinal; set => FechaFinal = value; }
        public int? idEmpresa { get => IdEmpresa; set => IdEmpresa = value; }
        public int idUsuario { get => IdUsuario; set => IdUsuario = value; }
        public string modified_by { get => Modified_by; set => Modified_by = value; }
    }
}
