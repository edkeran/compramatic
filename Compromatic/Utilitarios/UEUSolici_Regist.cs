using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Solicitud_registro", Schema = "dbo")]
    public class UEUSolici_Regist
    {
        private int id_solici;
        [Key]
        [Column("idSolicitud_registro")]
        public int Id_solici {
            get => id_solici;
            set => id_solici = value;
        }

        private int? estado_solici;
        [Column("estadoSolicitud")]
        public int? Estado_solici {
            get => estado_solici;
            set => estado_solici = value;
        }

        private int id_empresa;
        [Column("idEmpresa")]
        public int Id_empresa {
            get => id_empresa;
            set => id_empresa = value;
        }
        
        private string modifBy;
        [Column("modified_by")]
        public string ModifBy {
            get => modifBy;
            set => modifBy = value;
        }

    }
}
