using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    //DSFASD
    [Serializable]
    [Table("Membresia", Schema = "public")]
    public class UEUMembresia
    {
        private int id_memb;
        private String fecha_inicio;
        private String fecha_fin;
        private int estado_mem;
        private int id_tipo_mem;
        private int id_empresa;
        private String modifieBy;

        [Key]
        [Column("idMembresia")]
        public int Id_memb { get => id_memb; set => id_memb = value; }
        [Column("fechaInicio")]
        public string Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        [Column("fechaFin")]
        public string Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        [Column("estadoMembresia")]
        public int Estado_mem { get => estado_mem; set => estado_mem = value; }
        [Column("idTipo_membresia")]
        public int Id_tipo_mem { get => id_tipo_mem; set => id_tipo_mem = value; }
        [Column("idEmpresa")]
        public int Id_empresa { get => id_empresa; set => id_empresa = value; }
        [Column("modified_by")]
        public string ModifieBy { get => modifieBy; set => modifieBy = value; }
    }
}
