using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_Componentes
    {
        public DataTable MostrarMotivosReporte()
        {
            DDAOPqr db = new DDAOPqr();
            return db.MostrarMotivosReporte();
        }

        public DataTable MostrarArchivos(String nit)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Nit = nit;
            DataTable Archivos = DAO_Empresa.MostrarArchivos(EU_Empresa);
            return Archivos;
        }

        public DataTable MostrarVentasPorCategoria()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarVentasPorCategoria();
        }

    }
}
