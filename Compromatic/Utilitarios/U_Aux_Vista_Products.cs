using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_Aux_Vista_Products
    {
        private String nom_Empresa;
        private String nom_Categoria;
        private String nom_Archivo;
        private int id_Categoria;

        public string Nom_Empresa { get => nom_Empresa; set => nom_Empresa = value; }
        public string Nom_Categoria { get => nom_Categoria; set => nom_Categoria = value; }
        public string Nom_Archivo { get => nom_Archivo; set => nom_Archivo = value; }
        public int Id_Categoria { get => id_Categoria; set => id_Categoria = value; }
    }
}
