using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_APP_TEST.Services
{
    public class PaisRepositorioEnMemoria:IRepositorioPais
    {
        public List<string> ObtenerTodos()
        {
            List<string> paises = new List<string>() { "COLOMBIA", "ESTADOS UNIDOS", "CHINA" };
            return paises;
        }
       
    }
}
