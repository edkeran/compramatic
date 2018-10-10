using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Foto_producto", Schema = "public")]
    public class UEUFotoProd
    {
        private int id_foto;
        private String rutaArchi;
        private String nomArchi="default.png";
        private int id_Product;
        private String modif_By;

        [Key]
        [Column("idFoto_producto")]
        public int Id_foto { get => id_foto; set => id_foto = value; }
        [Column("rutaArchivo")]
        public string RutaArchi { get => rutaArchi; set => rutaArchi = value; }
        [Column("nomArchivo")]
        public string NomArchi { get => nomArchi; set => nomArchi = value; }
        [Column("idProducto")]
        public int Id_Product { get => id_Product; set => id_Product = value; }
        [Column("modified_by")]
        public string Modif_By { get => modif_By; set => modif_By = value; }
    }
}
