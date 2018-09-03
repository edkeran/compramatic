using System;
using System.Data;

namespace Utilitarios
{
    public class UEUProducto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int categoria;

        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        private int idEmpresa;

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        private String nomArchivo;

        public String NomArchivo
        {
            get { return nomArchivo; }
            set { nomArchivo = value; }
        }
        private int idFoto;

        public int IdFoto
        {
            get { return idFoto; }
            set { idFoto = value; }
        }
        private String rutaArchivo;

        public String RutaArchivo
        {
            get { return rutaArchivo; }
            set { rutaArchivo = value; }
        }
        private int bajoInventario;

        public int BajoInventario
        {
            get { return bajoInventario; }
            set { bajoInventario = value; }
        }
        private String redireccion;

        public string Redireccion
        {
            get => redireccion;
            set => redireccion = value;
        }

        private String precioString;

        public string PrecioString
        {
            get => precioString;
            set => precioString = value;
        }
        public string NomEmp { get => nomEmp; set => nomEmp = value; }
        public string NomCategoria { get => nomCategoria; set => nomCategoria = value; }
        public DataTable Fotos { get => fotos; set => fotos = value; }

        private String nomEmp;
        private String nomCategoria;
        private DataTable fotos;

    }
}
