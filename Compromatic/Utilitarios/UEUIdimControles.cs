using System;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Utilitarios
{
    [Serializable]
    [Table("controles", Schema = "idioma")]
    public class UEUIdimControles
    {
        private int Id_control;
        private String Nom_control;
        private int Idioma_id;
        private int Form_id;
        private String Texto;

        [Key]
        [Column("id_control")]
        public int id_control { get => Id_control; set => Id_control = value; }
        [Column("nom_control")]
        public string nom_control { get => Nom_control; set => Nom_control = value; }
        [Column("idioma_id")]
        public int idioma_id { get => Idioma_id; set => Idioma_id = value; }
        [Column("form_id")]
        public int form_id { get => Form_id; set => Form_id = value; }
        [Column("texto")]
        public string texto { get => Texto; set => Texto = value; }
    }
}
