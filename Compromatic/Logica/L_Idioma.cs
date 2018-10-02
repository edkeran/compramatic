﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using System.Data;
using Datos;
using System.Collections;
using DatosPersistencia;


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

        public DataTable traer_idioma()
        {
            DDAOidioma db = new DDAOidioma();
            return db.Idiomas();
        }

        public List<UEUIdioma> traer_idioma_persistencia()
        {
            List<UEUIdioma> data = new List<UEUIdioma>();
            DBIdiom daoIdioma = new DBIdiom();
            data = daoIdioma.traer_idioma();
            return data;
        }

        public DataTable traer_formulario()
        {
            DDAOidioma db = new DDAOidioma();
            return db.Formularios();
        }

        public DataTable obtner_controles(int id_form,int id_idioma)
        {
            DDAOidioma db = new DDAOidioma();
            return db.Controles(id_form,id_idioma);
        }

        public void insertar_idioma(String idioma, String termin)
        {
            DDAOidioma db = new DDAOidioma();
            db.insertar_idioma(idioma, termin);
        }

        public void insertar_idioma_persistencia(UEUIdioma datos)
        {
            //DDAOidioma db= new DDAOidioma();
            DBIdiom db= new DBIdiom();
            db.insertar_idioma(datos);

        }

        public void insertar_traduccion(int idioma, int form,String texto, String control)
        {
            DDAOidioma db = new DDAOidioma();
            UEUTraduccion data = new UEUTraduccion();
            data.Idioma = idioma;
            data.Form = form;
            data.Texto = texto;
            data.Control = control;
            db.insertar_traduccion(data);
           
        }

        //ELIMINAR IDIOMA PERSISTENCIA
        public void eliminar_idioma(int id_idioma)
        {
            DBIdiom dao = new DBIdiom();
            dao.delete_idiom(id_idioma);
        }

        //METODO PARA TRAER UN SOLO IDIOMA
        public UEUIdioma traer_datos(int id)
        {
            DBIdiom dao = new DBIdiom();
            return dao.get_idiom(id);
        }

        //EVITAR ERROR DEL GV
        public void validar_postback(bool post)
        {
            if (post)
            {
                throw new SystemException();
            }
        }

        public void update_idiom(UEUIdioma idiom)
        {
            DBIdiom dao = new DBIdiom();
            dao.update_idioma(idiom);
        }
    }
}
