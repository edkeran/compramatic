using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    //DSFASD
    [Serializable]
    [Table("Membresia", Schema = "dbo")]
    public class UEUMembresia : ICloneable
    {
        private int id_memb;
        private DateTime fecha_inicio;
        private DateTime fecha_fin;
        private int estado_mem;
        private int id_tipo_mem;
        private int id_empresa;
        private String modifieBy;

        [Key]
        [Column("idMembresia")]
        public int Id_memb { get => id_memb; set => id_memb = value; }
        [Column("fechaInicio")]
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        [Column("fechaFin")]
        public DateTime Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        [Column("estadoMembresia")]
        public int Estado_mem { get => estado_mem; set => estado_mem = value; }
        [Column("idTipo_membresia")]
        public int Id_tipo_mem { get => id_tipo_mem; set => id_tipo_mem = value; }
        [Column("idEmpresa")]
        public int Id_empresa { get => id_empresa; set => id_empresa = value; }
        [Column("modified_by")]
        public string ModifieBy { get => modifieBy; set => modifieBy = value; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
