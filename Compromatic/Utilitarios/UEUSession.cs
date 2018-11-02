//CLASE PARA EL ENCAPSULAMIENTO DE LA SESION ALCTUAL
using System;

namespace Utilitarios
{
    public class UEUSession
    {
        private string sesion;
        private DateTime fecha_fin_old;
        private DateTime fecha_fin_new;

        public string Sesion { get => sesion; set => sesion = value; }
        public DateTime Fecha_fin_old { get => fecha_fin_old; set => fecha_fin_old = value; }
        public DateTime Fecha_fin_new { get => fecha_fin_new; set => fecha_fin_new = value; }
    }
}
