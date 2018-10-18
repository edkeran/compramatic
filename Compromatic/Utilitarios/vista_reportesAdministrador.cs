

using System;

namespace Utilitarios
{
    public class vista_reportesAdministrador
    {
        private string RutaArchivo;
        private string NomEmpresa;
        private string NomUsuario;
        private string NomProducto;
        private string DesMotivo;
        private DateTime FechaReporte;
        private String CorreoEmpresa;
        private int IdProducto;

        public string rutaArchivo { get => RutaArchivo; set => RutaArchivo = value; }
        public string nomEmpresa { get => NomEmpresa; set => NomEmpresa = value; }
        public string nomUsuario { get => NomUsuario; set => NomUsuario = value; }
        public string nomProducto { get => NomProducto; set => NomProducto = value; }
        public string desMotivo { get => DesMotivo; set => DesMotivo = value; }
        public DateTime fechaReporte { get => FechaReporte; set => FechaReporte = value; }
        public string correoEmpresa { get => CorreoEmpresa; set => CorreoEmpresa = value; }
        public int idProducto { get => IdProducto; set => IdProducto = value; }
    }
}
