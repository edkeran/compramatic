using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Tipo_membresia", Schema = "dbo")]
    public class UEUTipoMembresia : ICloneable
    {
        //PARAMETROS DE LA TABLA DE LOS TIPOS
        private int id_tipo_mem;
        private int tmpo_mem;
        private String nom_mem;
        private Double valor_mem;
        private String modifBy;

        [Key]
        [Column("idTipo_membresia")]
        public int Id_tipo_mem { get => id_tipo_mem; set => id_tipo_mem = value; }
        [Column("tiempoMembresia")]
        public int Tmpo_mem { get => tmpo_mem; set => tmpo_mem = value; }
        [Column("nomMembresia")]
        public string Nom_mem { get => nom_mem; set => nom_mem = value; }
        [Column("valorMembresia")]
        public double Valor_mem { get => valor_mem; set => valor_mem = value; }
        [Column("modified_by")]
        public string ModifBy { get => modifBy; set => modifBy = value; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
