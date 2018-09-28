using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Utilitarios
{
    [Serializable]
    [Table("idioma", Schema = "idioma")]
    public class UEUIdioma
    {

        private int id_Idioma;
        [Key]
        [Column("id_idioma")]
        public int Id_Idioma {
            get => id_Idioma;
            set => id_Idioma = value;
        }

        private String nombre_Idioma;

        [Column("nombre_idioma")]
        public string Nombre_Idioma {
            get => nombre_Idioma;
            set => nombre_Idioma = value;
        }

        private String terminacion;

        [Column("terminacion")]
        public string Terminacion {
            get => terminacion;
            set => terminacion = value;
        }
    }
}
