using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaMostrEmpres
    {
        private string NomEmpresa;
        private string TelEmpresa;
        private string CorreoEmpresa;
        private string DirEmpresa;
        private string NitEmpresa;
        private double CalificacionEmpresa;
        private int EstadoEmpresa;
        private string NomMembresia;

        public string nomEmpresa { get => NomEmpresa; set => NomEmpresa = value; }
        public string telEmpresa { get => TelEmpresa; set => TelEmpresa = value; }
        public string correoEmpresa { get => CorreoEmpresa; set => CorreoEmpresa = value; }
        public string dirEmpresa { get => DirEmpresa; set => DirEmpresa = value; }
        public string nitEmpresa { get => NitEmpresa; set => NitEmpresa = value; }
        public double calificacionEmpresa { get => CalificacionEmpresa; set => CalificacionEmpresa = value; }
        public int estadoEmpresa { get => EstadoEmpresa; set => EstadoEmpresa = value; }
        public string nomMembresia { get => NomMembresia; set => NomMembresia = value; }
    }
}
