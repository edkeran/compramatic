using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class vistaMostraVentByEmp
    {
        private string NitEmpresa;
        private string NomEmpresa;
        private double CalificacionEmpresa;
        private double Valor;
        private int Ventas;
        private string RutaArchivo;
        private string valorDef;

        public string nitEmpresa { get => NitEmpresa; set => NitEmpresa = value; }
        public string nomEmpresa { get => NomEmpresa; set => NomEmpresa = value; }
        public double calificacionEmpresa { get => CalificacionEmpresa; set => CalificacionEmpresa = value; }
        public double valorAux { get => Valor; set => Valor = value; }
        public int ventas { get => Ventas; set => Ventas = value; }
        public string rutaArchivo { get => RutaArchivo; set => RutaArchivo = value; }
        public string valor { get => valorDef; set => valorDef = value; }
    }
}
