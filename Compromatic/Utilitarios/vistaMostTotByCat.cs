using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaMostTotByCat
    {
        private string NomCategoria;
        private int Empresas;
        private int Ventas;
        private string Valor;

        public string nomCategoria {
            get => NomCategoria;
            set => NomCategoria = value;
        }

        public int empresas {
            get => Empresas;
            set => Empresas = value;
        }

        public int ventas {
            get => Ventas;
            set => Ventas = value;
        }

        public string valor {
            get => Valor;
            set => Valor = value;
        }
    }
}
