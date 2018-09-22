using System;
using System.Collections.Generic;
using System.Data;
using Datos;
namespace Logica
{
    public class L_Home {
        public DataTable obtener_Idiomas()
        {
            DDAOHome data = new DDAOHome();
            return data.Idiomas();
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
    }
}
