using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaHistorialCompra
    {
        private int IdVenta;
        private DateTime FechaVenta;
        private int IdUsuario;
        private DateTime FechaEntrega;
        private int CantVenta;
        private int EstadoVenta;
        private Double ValorVenta;
        private string NomProducto;
        private string NomEmpresa;
        private int IdEmpresa;
        private double CalificacionEmpresa;

        public int idVenta { get => IdVenta; set => IdVenta = value; }
        public DateTime fechaVenta { get => FechaVenta; set => FechaVenta = value; }
        public int idUsuario { get => IdUsuario; set => IdUsuario = value; }
        public DateTime fechaEntrega { get => FechaEntrega; set => FechaEntrega = value; }
        public int cantVenta { get => CantVenta; set => CantVenta = value; }
        public int estadoVenta { get => EstadoVenta; set => EstadoVenta = value; }
        public Double valorVenta { get => ValorVenta; set => ValorVenta = value; }
        public string nomProducto { get => NomProducto; set => NomProducto = value; }
        public string nomEmpresa { get => NomEmpresa; set => NomEmpresa = value; }
        public int idEmpresa { get => IdEmpresa; set => IdEmpresa = value; }
        public double calificacionEmpresa { get => CalificacionEmpresa; set => CalificacionEmpresa = value; }
    }
}
