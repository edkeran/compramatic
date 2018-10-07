using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Utilitarios
{
    [Serializable]
    [Table("Palabra_clave", Schema = "public")]
    public class UEUTag
    {
        int idTag;

        [Key]
        [Column("idPalabra_clave")]
        public int IdTag
        {
            get { return idTag; }
            set { idTag = value; }
        }
        String palabra;

        [Column("palabra")]
        public String Palabra
        {
            get { return palabra; }
            set { palabra = value; }
        }
        int idProducto;
        [Column("idProducto")]
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private String modifiedBy;
        [Column("modified_by")]
        public string ModifiedBy {
            get => modifiedBy;
            set => modifiedBy = value;
        }
    }
}
