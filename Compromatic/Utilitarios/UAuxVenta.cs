using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UAuxVenta
    {
        private bool valido=false,btnYes;
        private string msg;
        private string redireccion;

       
        public string Msg { get => msg; set => msg = value; }
        public string Redireccion { get => redireccion; set => redireccion = value; }
        public bool BtnYes { get => btnYes; set => btnYes = value; }
        public bool Valido { get => valido; set => valido = value; }
    }
}
