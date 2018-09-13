using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using System.Data;
using Datos;
using System.Collections;


namespace Logica
{
    public class L_Idioma
    {
        public void mostraridioma(Int32 formulario, Int32 idiom, Hashtable compIdioma)
        {
            DDAOidioma idioma = new DDAOidioma();
            DataTable info = idioma.obtenerIdioma(formulario, idiom);


            for (int i = 0; i < info.Rows.Count; i++)
            {
                compIdioma.Add(info.Rows[i]["control"].ToString(), info.Rows[i]["valor"].ToString());
            }


        }

        public DataTable editaridioma()
        {
            DDAOidioma data = new DDAOidioma();
            DataTable datos = data.vereditidioma();
            return datos;
        }

        public U_aux_loggin textoedit(String id, String texto)
        {
            U_aux_loggin aux_log = new U_aux_loggin();
            DDAOidioma daotexto = new DDAOidioma();

            if (texto == "")
            {
                aux_log.Modal_message = "No se puede enviar datos nulos";

            }
            else
            {
                //UsingPer peridiom = new UsingPer();
                //peridiom.textoedit(id, texto);
                daotexto.textoedit(Int32.Parse(id), texto);


                aux_log.Modal_message = "Dato modificado";
            }
            return aux_log;
        }
    }
}
