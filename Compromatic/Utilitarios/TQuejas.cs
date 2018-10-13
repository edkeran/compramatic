using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Quejas", Schema = "public")]
    public class TQuejas
    {
        private int idQuje;
        private String desQuej;
        private int? idEmpre;
        private int id_Moti_Quej;
        private int? id_user;
        private int receptorQ;
        private DateTime fechaQuj;
        private string modified_by = "";

        [Key]
        [Column("idQueja")]
        public int IdQuje { get => idQuje; set => idQuje = value; }
        [Column("desQueja")]
        public string DesQuej { get => desQuej; set => desQuej = value; }
        [Column("idEmpresa")]
        public int? IdEmpre { get => idEmpre; set => idEmpre = value; }
        [Column("idMotivo_queja")]
        public int Id_Moti_Quej { get => id_Moti_Quej; set => id_Moti_Quej = value; }
        [Column("idUsuario")]
        public int? Id_user { get => id_user; set => id_user = value; }
        [Column("receptorQ")]
        public int ReceptorQ { get => receptorQ; set => receptorQ = value; }
        [Column("fechaQueja")]
        public DateTime FechaQuj { get => fechaQuj; set => fechaQuj = value; }
        [Column("modified_by")]
        public string Modified_by { get => modified_by; set => modified_by = value; }
    }
}
