using System;
using System.Data;


namespace Utilitarios
{
    public class U_Modificar_Pfi_Usr
    {
        private DataTable datos;
        public DataTable Datos { get => datos; set => datos = value; }
        private bool valido;
        public bool Valido { get => valido; set => valido = value; }
        private String mensage, pagina_redir;
        public string Mensage { get => mensage; set => mensage = value; }
        public string Pagina_redir { get => pagina_redir; set => pagina_redir = value; }
    }
}
