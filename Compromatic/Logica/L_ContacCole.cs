using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_ContacCole
    {
        public void validarToken(string token)
        {
            if (token.Equals("-1")) throw new Exception("Requiere Validacion");
        }
    }
}
