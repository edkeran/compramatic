using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaMostrarVenta
    {
        private int IdVenta;
        private DateTime FechaVenta;
        private int EstadoVenta;
        private Double ValorVenta;
        private String NomUsuario;
        private String ApeUsuario;
        private String TelUsuario; 
        private String CorreoUsuario;
        private String DirUsuario;
        private int IdEmpresa;
        private Double? CalificacionUsuario;
        private int CanProducto;
        private int CantVenta;
        private String NomProducto;

        public int idVenta { get => IdVenta; set => IdVenta = value; }
        public DateTime fechaVenta { get => FechaVenta; set => FechaVenta = value; }
        public int estadoVenta { get => EstadoVenta; set => EstadoVenta = value; }
        public Double valorVenta { get => ValorVenta; set => ValorVenta = value; }
        public string nomUsuario { get => NomUsuario; set => NomUsuario = value; }
        public string apeUsuario { get => ApeUsuario; set => ApeUsuario = value; }
        public string telUsuario { get => TelUsuario; set => TelUsuario = value; }
        public string correoUsuario { get => CorreoUsuario; set => CorreoUsuario = value; }
        public string dirUsuario { get => DirUsuario; set => DirUsuario = value; }
        public int idEmpresa { get => IdEmpresa; set => IdEmpresa = value; }
        public double? calificacionUsuario { get => CalificacionUsuario; set => CalificacionUsuario = value; }
        public int canProducto { get => CanProducto; set => CanProducto = value; }
        public int cantVenta { get => CantVenta; set => CantVenta = value; }
        public string nomProducto { get => NomProducto; set => NomProducto = value; }
    }
}
