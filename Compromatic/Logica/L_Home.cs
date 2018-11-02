using System;
using System.Collections.Generic;
using DatosPersistencia;
using Utilitarios;

namespace Logica
{
    public class L_Home {

        //public DataTable obtener_Idiomas()
        //{
        //    DDAOHome data = new DDAOHome();
        //    return data.Idiomas();
        //}

        public List<UEUIdioma> get_idioms(){
            DBIdiom daoIdiom = new DBIdiom();
            return daoIdiom.get_all_idioms();
        }

        public Object validar_ses_idioma(Object idiom)
        {
            if (idiom == null)
            {
                return 1;
            }
            else
            {
                return idiom;
            }
        }

        public Object validar_region(Object region)
        {
            if (region == null)
            {
                return "es-Co";
            }
            else
            {
                return region;
            }
        }

        public void reportar_sesion_user(string id_session,int id_user)
        {
            DB_Session daoSession = new DB_Session();
            daoSession.reportar_session_usr(id_session,id_user);
        }

        public void reportar_session_empres(string id_session)
        {
            DB_Session daoSes = new DB_Session();
        }
    }
}
