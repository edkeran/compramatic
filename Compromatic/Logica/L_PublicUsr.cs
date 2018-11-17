using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosPersistencia;
using Utilitarios;

namespace Logica
{
    public class L_PublicUsr
    {
        public List<UEUPublic_User> consultarPublicaciones()
        {
            DB_Publicacion_Use daoPublic = new DB_Publicacion_Use();
            return daoPublic.get_publicaciones();
        }
    }
}
