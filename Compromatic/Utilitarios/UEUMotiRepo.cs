using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("MotivoR", Schema = "public")]
    public class UEUMotiRepo
    {
        private int idMoti;
        private String desMotiv;
        private String modifBy;

        [Key]
        [Column("idMotivoR")]
        public int IdMoti {
            get => idMoti;
            set => idMoti = value;
        }
        [Column("desMotivo")]
        public string DesMotiv {
            get => desMotiv;
            set => desMotiv = value;
        }
        [Column("modified_by")]
        public string ModifBy {
            get => modifBy;
            set => modifBy = value;
        }
    }
}
