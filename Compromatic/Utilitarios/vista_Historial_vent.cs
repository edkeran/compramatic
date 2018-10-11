using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vista_Historial_vent
    {
        private int idVen;
        private DateTime fechVen;
        private int cantVent;
        private int estadoVent;
        private Double valorVent;
        private String nomProd;
        private String nomEmp;
        private int idEmp;
        private Double calEmp;
        private int idUsr;
        private DateTime fechaEntre;

        public int idVenta { get => idVen; set => idVen = value; }
        public DateTime fechaVenta { get => fechVen; set => fechVen = value; }
        public int cantVenta { get => cantVent; set => cantVent = value; }
        public int estadoVenta { get => estadoVent; set => estadoVent = value; }
        public Double valorVenta { get => valorVent; set => valorVent = value; }
        public string nomProducto { get => nomProd; set => nomProd = value; }
        public string nomEmpresa { get => nomEmp; set => nomEmp = value; }
        public int idEmpresa { get => idEmp; set => idEmp = value; }
        public double calificacionEmpresa { get => calEmp; set => calEmp = value; }
        public int idUsuario { get => idUsr; set => idUsr = value; }
        public DateTime fechaEntrega { get => fechaEntre; set => fechaEntre = value; }
    }
}
