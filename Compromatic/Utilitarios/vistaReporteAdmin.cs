using System;

namespace Utilitarios
{
    public class vistaReporteAdmin
    {
        private String nit_empresa;
        private String nom_empresa;
        private Double cal_empresa;
        private String valor;
        private int ventas;
        private String rutaArchivo;

        public string Nit_empresa { get => nit_empresa; set => nit_empresa = value; }
        public string Nom_empresa { get => nom_empresa; set => nom_empresa = value; }
        public double Cal_empresa { get => cal_empresa; set => cal_empresa = value; }
        public string Valor { get => valor; set => valor = value; }
        public int Ventas { get => ventas; set => ventas = value; }
        public string RutaArchivo { get => rutaArchivo; set => rutaArchivo = value; }
    }
}
