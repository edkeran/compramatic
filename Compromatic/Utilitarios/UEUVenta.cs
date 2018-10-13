using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Venta", Schema = "public")]
    public class UEUVenta
    {
        private int valor;

        [Column("valorVenta")]
        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private int cantidad;

        [Column("cantVenta")]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private int idVenta;


        [Key]
        [Column("idVenta")]
        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }
        private int idUsr;

        [Column("idUsuario")]
        public int IdUsr
        {
            get { return idUsr; }
            set { idUsr = value; }
        }

        private int idProducto;

        [Column("idProducto")]
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private int estadoVenta;

        [Column("estadoVenta")]
        public int EstadoVenta
        {
            get { return estadoVenta; }
            set { estadoVenta = value; }
        }

        private DateTime fechaVent= DateTime.Now;
        [Column("fechaVenta")]
        public DateTime FechaVent {
            get => fechaVent;
            set => fechaVent = value;
        }
        private DateTime fechaEntr;

        [Column("fechaEntrega")]
        public DateTime FechaEntr {
            get => fechaEntr;
            set => fechaEntr = value;
        }

        private String modif_by;
        [Column("modified_by")]
        public string modified_by
        {
            get => modif_by;
            set => modif_by = value;
        }


    }
}
