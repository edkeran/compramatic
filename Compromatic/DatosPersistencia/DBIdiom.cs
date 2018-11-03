using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBIdiom
    {
        //METODO PARA INSERTAR UN NUEVO IDIOMA
        public void insertar_idioma(UEUIdioma idioma) {
            using (var db = new Mapeo("idioma"))
            {
                db.idiom.Add(idioma);
                db.SaveChanges();
                EAcceso acc = new EAcceso();
                acc.Ip = EAcceso.obtenerIP();
                acc.Mac = EAcceso.obtenerMAC();
                acc.Id = 0;
                acc.IdUsuario = 0;
                acc.FechaInicio = DateTime.Now.ToString();
                acc.FechaFin = DateTime.Now.ToString();
                DBAuditoria.insert(idioma,acc,"idioma","idioma");
            }
        }

        //METODO PARA TAER UN IDIOMA
        public List<UEUIdioma> traer_idioma()
        {
            using (var db = new Mapeo("idioma"))
            {
                return db.idiom.Where(x => x.Id_Idioma != 1).ToList<UEUIdioma>();
            }
        }

        //METODO PARA ELIMINAR UN IDIOMA
        public void delete_idiom(int id)
        {
            using (var db = new Mapeo("idioma"))
            {
                var idioma = db.idiom.Find(id);
                EAcceso acc = new EAcceso();
                acc.Ip = EAcceso.obtenerIP();
                acc.Mac = EAcceso.obtenerMAC();
                acc.Id = 0;
                acc.IdUsuario = 0;
                acc.FechaInicio = DateTime.Now.ToString();
                acc.FechaFin = DateTime.Now.ToString();
                DBAuditoria.delete(idioma,acc, "idioma", "idioma");
                db.Entry(idioma).State = EntityState.Deleted;
                db.SaveChanges();
                
            }
        }

        //METODO PARA TRAER UN SOLO IDI0OMA
        public UEUIdioma get_idiom(int id) {
            using (var db = new Mapeo("idioma"))
            {
                var idioma = db.idiom.Find(id);
                return idioma;
            }
        }

        public void update_idioma(UEUIdioma new_idiom)
        {
            using (var db = new Mapeo("idioma"))
            {
                db.idiom.Attach(new_idiom);
                var entry = db.Entry(new_idiom);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //metodo para obtener todos los idiomas
        public List<UEUIdioma> get_all_idioms()
        {
            using (var db = new Mapeo("idioma"))
            {
                var data = from u in db.idiom select u;
                return data.ToList<UEUIdioma>();
            }
        }

        public UEUIdimControles[] obtener_Idioma(int formulario, int idioma)
        {
            using (var db = new Mapeo("idioma"))
            {
                var data = (from cont in db.idiom_contro where cont.form_id == formulario && cont.idioma_id == idioma
                            select cont);
                return data.ToArray();
            }
        }

        public DataTable formularios()
        {
            using (var db = new Mapeo("idioma"))
            {
                ListToDataTable conv = new ListToDataTable();
                List<UEUFormula_Idiom> data = db.form_idioma.ToList<UEUFormula_Idiom>();
                return conv.ToDataTable<UEUFormula_Idiom>(data);
            }
        }

        public DataTable obtener_controles(int id_form, int id_idioma)
        {
            using (var db= new Mapeo("idioma"))
            {
                List<UEUIdimControles> control = db.idiom_contro.
                    Where(x=>x.form_id==id_form).
                    Where(x=>x.idioma_id!=id_idioma).
                    Where(x=>x.idioma_id==1).ToList<UEUIdimControles>();
                ListToDataTable conv = new ListToDataTable();
                return conv.ToDataTable<UEUIdimControles>(control);
            }
        }


        public void insertar_traduccion(UEUTraduccion data)
        {
            using (var db= new Mapeo("idioma")) {
                int cont = (from controles in db.idiom_contro
                           where controles.nom_control == data.Control &&
                           controles.idioma_id == data.Idioma &&
                           controles.form_id == data.Form
                           select controles).Count();
                if (cont > 0)
                {
                    //UPDATE REGIST
                    var control = (from controles in db.idiom_contro
                                   where
                                        controles.nom_control == data.Control &&
                                        controles.idioma_id == data.Idioma &&
                                        controles.form_id == data.Form
                                   select controles).FirstOrDefault();
                    EAcceso acc = new EAcceso();
                    acc.Ip = EAcceso.obtenerIP();
                    acc.Mac = EAcceso.obtenerMAC();
                    acc.Id = 0;
                    acc.IdUsuario = 0;
                    acc.FechaInicio = DateTime.Now.ToString();
                    acc.FechaFin = DateTime.Now.ToString();
                    UEUIdimControles new_trad = new UEUIdimControles();
                    new_trad.form_id = control.form_id;
                    new_trad.texto = data.Texto;
                    new_trad.nom_control = control.nom_control;
                    new_trad.id_control = control.id_control;
                    new_trad.idioma_id = control.idioma_id;
                    DBAuditoria.update(control, new_trad, acc,"idioma","controles");
                    control.texto = data.Texto;
                    db.SaveChanges();

                    
                } 
                else
                {
                    //CREATE REGIST
                    UEUIdimControles insertData = new UEUIdimControles();
                    insertData.nom_control = data.Control;
                    insertData.texto = data.Texto;
                    insertData.idioma_id = data.Idioma;
                    insertData.form_id = data.Form;
                    db.idiom_contro.Add(insertData);
                    db.SaveChanges();
                    EAcceso acc = new EAcceso();
                    acc.Ip = EAcceso.obtenerIP();
                    acc.Mac = EAcceso.obtenerMAC();
                    acc.Id = 0;
                    acc.IdUsuario = 0;
                    acc.FechaInicio = DateTime.Now.ToString();
                    acc.FechaFin = DateTime.Now.ToString();
                    DBAuditoria.insert(insertData,acc,"idioma","controles");
                }
            }
        }

    }
}
