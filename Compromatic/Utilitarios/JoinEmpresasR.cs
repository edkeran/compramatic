using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class JoinEmpresasR
    {
        private String nombre_empresa;
        private String forma_juridica;
        private String direccion_empresa;
        private String telefono_empresa;
        private String sector_economico;

        public string Nombre_empresa { get => nombre_empresa; set => nombre_empresa = value; }
        public string Forma_juridica { get => forma_juridica; set => forma_juridica = value; }
        public string Direccion_empresa { get => direccion_empresa; set => direccion_empresa = value; }
        public string Telefono_empresa { get => telefono_empresa; set => telefono_empresa = value; }
        public string Sector_economico { get => sector_economico; set => sector_economico = value; }
    }
}
