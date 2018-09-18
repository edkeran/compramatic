using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UEUTraduccion
    {
        private int form, idioma;
        private String texto, control;

        public int Form { get => form; set => form = value; }
        public int Idioma { get => idioma; set => idioma = value; }
        public string Texto { get => texto; set => texto = value; }
        public string Control { get => control; set => control = value; }
    }
}
