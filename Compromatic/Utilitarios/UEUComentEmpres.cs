using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("ComentariosEmpresa", Schema = "dbo")]
    public class UEUComentEmpres
    {
        private Int64 id_coment;
        private int idEmpres;
        private string comentario;
        private string nomUser;
        private string correoUser;

        [Key]
        [Column("id_Coment")]
        public Int64 Id_coment {
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
        
        [Column("nomUser")]
        public string NomUser {
            get => nomUser;
            set => nomUser = value;
        }

        [Column("correUsr")]
        public string CorreoUser {
            get => correoUser;
            set => correoUser = value;
        }
    }
}
