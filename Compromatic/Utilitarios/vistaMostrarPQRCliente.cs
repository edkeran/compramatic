using System;

namespace Utilitarios
{
    public class vistaMostrarPQRCliente
    {
        private string DesQueja;
        private DateTime FechaQueja;
        private string NomQueja;
        private string emisor;
        private string Foto;

        public string desQueja {
            get => DesQueja;
            set => DesQueja = value;
        }

        public DateTime fechaQueja {
            get => FechaQueja;
            set => FechaQueja = value;
        }

        public string nomQueja {
            get => NomQueja;
            set => NomQueja = value;
        }

        public string Emisor {
            get => emisor;
            set => emisor = value;
        }

        public string foto {
            get => Foto;
            set => Foto = value;
        }
    }
}
