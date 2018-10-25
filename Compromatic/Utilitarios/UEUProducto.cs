using System;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Utilitarios
{
    [Serializable]
    [Table("Producto", Schema = "dbo")]
    public class UEUProducto
    {
        private int id;
        [Key]
        [Column("idProducto")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String nombre;

        [Column("nomProducto")]
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int cantidad;

        [Column("canProducto")]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private double precio;

        [Column("precioProducto")]
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private String descripcion;

        [Column("desProducto")]
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int categoria;
       
        [Column("idCategoria")]
        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        private int idEmpresa;

        [Column("idEmpresa")]
        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        private String nomArchivo;

        [NotMapped]
        public String NomArchivo
        {
            get { return nomArchivo; }
            set { nomArchivo = value; }
        }
        private int idFoto;

        [NotMapped]
        public int IdFoto
        {
            get { return idFoto; }
            set { idFoto = value; }
        }
        private String rutaArchivo;

        [NotMapped]
        public String RutaArchivo
        {
            get { return rutaArchivo; }
            set { rutaArchivo = value; }
        }
        private int bajoInventario;

        [Column("bajoInventario")]
        public int BajoInventario
        {
            get { return bajoInventario; }
            set { bajoInventario = value; }
        }
        private String redireccion;

        [NotMapped]
        public string Redireccion
        {
            get => redireccion;
            set => redireccion = value;
        }

        private String precioString;

        [NotMapped]
        public string PrecioString
        {
            get => precioString;
            set => precioString = value;
        }

        [NotMapped]
        public string NomEmp { get => nomEmp; set => nomEmp = value; }
        [NotMapped]
        public string NomCategoria { get => nomCategoria; set => nomCategoria = value; }
        [NotMapped]
        public DataTable Fotos { get => fotos; set => fotos = value; }
        [Column("modified_by")]
        public string ModifBy { get => modifBy; set => modifBy = value; }
        [Column("estadoProducto")]
        public int Estado_producto { get => estado_producto; set => estado_producto = value; }

        private String nomEmp;
        private String nomCategoria;
        private DataTable fotos;
        private string modifBy="";
        private int estado_producto;

    }
}
