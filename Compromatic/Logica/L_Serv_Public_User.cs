using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_Serv_Public_User
    {

        public void crear_Publicacion(UEUPublic_User data)
        {
            try
            {
                DB_Publicacion_Use daoPublic = new DB_Publicacion_Use();
                daoPublic.insertar_publicacion(data);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
