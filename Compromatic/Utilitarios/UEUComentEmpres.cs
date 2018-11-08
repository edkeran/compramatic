using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("ComentariosEmpresa", Schema = "dbo")]
    public class UEUComentEmpres
    {
        private int id_coment;
        private int idEmpres;
        private string comentario;

        [Key]
        [Column("id_Coment")]
        public int Id_coment {
            get => id_coment;
            set => id_coment = value;
        }

        [Column("id_Empresa")]
        public int IdEmpres {
            get => idEmpres;
            set => idEmpres = value;
        }

        [Column("comentario")]
        public string Comentario {
            get => comentario;
            set => comentario = value;
        }
    }
}
