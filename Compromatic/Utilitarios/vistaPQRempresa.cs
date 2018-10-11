using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaPQRempresa
    {
        private String desQuja;
        private DateTime fechaQuja;
        private String nomQj;
        private String nomUs;
        private String picture;

        public string desQueja { get => desQuja; set => desQuja = value; }
        public DateTime fechaQueja { get => fechaQuja; set => fechaQuja = value; }
        public string nomQueja { get => nomQj; set => nomQj = value; }
        public string Emisor { get => nomUs; set => nomUs = value; }
        public string foto { get => picture; set => picture = value; }
    }
}
