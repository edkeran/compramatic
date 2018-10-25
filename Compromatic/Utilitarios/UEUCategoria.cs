using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Categoria", Schema = "dbo")]
    public class UEUCategoria
    {
        //CREO LOS PARAMETROS DE LA BASE DE DATOS
        
        private String nomCateg;
        private String modifBy;
        private int id_cate;

        [Column("nomCategoria")]
        public string nomCategoria
        {
            get => nomCateg;
            set => nomCateg = value;
        }
        [Column("modified_by")]
        public string ModifBy {
            get => modifBy;
            set => modifBy = value;
        }

        [Key]
        [Column("idCategoria")]
        public int Id_cate {
            get => id_cate;
            set => id_cate = value;
        }
    }
}
