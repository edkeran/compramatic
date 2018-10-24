using System;

namespace Utilitarios
{
    public class UAuxTipoMem
    {
        private int id_tipo_mem;
        private int tmpo_mem;
        private String nom_mem;
        private Double valor_mem;
        private String modifBy;

        public int idTipo_membresia
        {
            get => id_tipo_mem;
            set => id_tipo_mem = value;
        }

        public int tiempoMembresia
        {
            get => tmpo_mem;
            set => tmpo_mem = value;
        }

        public string nomMembresia
        {
            get => nom_mem;
            set => nom_mem = value;
        }

        public double valorMembresia
        {
            get => valor_mem;
            set => valor_mem = value;
        }

        public string modified_by
        {
            get => modifBy;
            set => modifBy = value;
        }
    }
}
