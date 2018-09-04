using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_AuxQuejAdm
    {
        private String redir="0";
        private bool acceHeader;
        private Object Header;
        private int num = 0;

        public string Redir { get => redir; set => redir = value; }
        public bool AcceHeader { get => acceHeader; set => acceHeader = value; }
        public object Header1 { get => Header; set => Header = value; }
        public int Num { get => num; set => num = value; }
    }
}
