using System;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Utilitarios
{
    [Serializable]
    [Table("formulario", Schema = "idioma")]
    public class UEUFormula_Idiom
    {
        private int idForm;
        private string nom_form;
        private string urt_f;

        [Key]
        [Column("id_form")]
        public int id_form { get => idForm; set => idForm = value; }
        [Column("nombre_form")]
        public string nombre_form { get => nom_form; set => nom_form = value; }
        [Column("url")]
        public string url { get => urt_f; set => urt_f = value; }
    }
}
