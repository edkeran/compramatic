using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaMostrarMembre
    {
        private string Tiempo;
        private string NomMembresia;
        private string Valor;
        private double old_value;

        public string tiempo {
            get => Tiempo;
            set => Tiempo = value;
        }

        public string nomMembresia {
            get => NomMembresia;
            set => NomMembresia = value;
        }

        public string valor {
            get => Valor;
            set => Valor = value;
        }

        public double Old_value {
            get => old_value;
            set => old_value = value;
        }
    }
}
