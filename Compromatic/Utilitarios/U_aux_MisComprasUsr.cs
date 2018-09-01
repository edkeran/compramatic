using System.Data;


namespace Utilitarios
{
    public class U_aux_MisComprasUsr
    {
        private DataTable peticiones=null, aceptadas=null, rechazadas=null, hechas=null;
        private string redireccion="0";
        private string mensaje = "";

        public DataTable Peticiones { get => peticiones; set => peticiones = value; }
        public DataTable Aceptadas { get => aceptadas; set => aceptadas = value; }
        public DataTable Rechazadas { get => rechazadas; set => rechazadas = value; }
        public DataTable Hechas { get => hechas; set => hechas = value; }
        public string Redireccion { get => redireccion; set => redireccion = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
