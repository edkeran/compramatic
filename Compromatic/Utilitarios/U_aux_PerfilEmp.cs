using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Utilitarios
{
    public class U_aux_PerfilEmp
    {
        private DataTable data;
        private String response, mensage;

        public DataTable Data { get => data; set => data = value; }
        public string Response { get => response; set => response = value; }
        public string Mensage { get => mensage; set => mensage = value; }
    }
}
