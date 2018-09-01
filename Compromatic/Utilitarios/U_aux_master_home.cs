using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_aux_master_home
    {
        private String rutaFoto="", nomUsuario="",url="",Modal_Info="";
        private bool registroVisible=true;
        private DataTable productos;


        public string RutaFoto { get => rutaFoto; set => rutaFoto = value; }
        public string NomUsuario { get => nomUsuario; set => nomUsuario = value; }
        public bool RegistroVisible { get => registroVisible; set => registroVisible = value; }
        public DataTable Productos { get => productos; set => productos = value; }
        public string Url { get => url; set => url = value; }
        public string Modal_Info1 { get => Modal_Info; set => Modal_Info = value; }
    }
}
