using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("MotivoQ", Schema = "public")]
    public class UEUQueja
    {
        private int id_queja;
        private string nom_queja;
        private string modifby;
        [Key]
        [Column("idMotivo_queja")]
        public int Id_queja {
            get => id_queja;
            set => id_queja = value;
        }

        [Column("nomQueja")]
        public string Nom_queja {
            get => nom_queja;
            set => nom_queja = value;
        }

        [Column("modified_by")]
        public string Modifby {
            get => modifby;
            set => modifby = value;
        }
    }
}
