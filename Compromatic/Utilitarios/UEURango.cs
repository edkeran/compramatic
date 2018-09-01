using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UEURango
    {
        private int idUsr;

        public int IdUsr
        {
            get { return idUsr; }
            set { idUsr = value; }
        }
        private int idEmp;

        public int IdEmp
        {
            get { return idEmp; }
            set { idEmp = value; }
        }
        private string comentario;

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }
        private double rango;

        public double Rango
        {
            get { return rango; }
            set { rango = value; }
        }
    }
}
