using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Session
    {
        public void reportar_session_usr(string id_session, int id_user) {
            using (var db = new Mapeo("public"))
            {
                var consult = db.user.Find(id_user);
                if (consult.Current_sessions == null)
                {
                    //INSERTAR LA SESSION ACTUAL
                    List<UEUSession> insert = new List<UEUSession>();
                    UEUSession new_session = new UEUSession();
                    new_session.Fecha_fin_old = DateTime.Now;
                    new_session.Fecha_fin_new = DateTime.Now.AddSeconds(30);
                    new_session.Sesion = id_session;
                    insert.Add(new_session);
                    consult.Current_sessions = JsonConvert.SerializeObject(insert);
                    db.SaveChanges();
                }
                else
                {
                    //  VALIDAR SI EXISTE LA SESSION EN CASO CONTRARIO INSERTARLO EN LA LISTA
                    List<UEUSession> data = JsonConvert.DeserializeObject<List<UEUSession>>(consult.Current_sessions);
                    bool caso_more = true;
                    foreach (UEUSession inf in data)
                    {
                        if (inf.Sesion == id_session)
                        {
                            caso_more = false;
                            inf.Fecha_fin_old = inf.Fecha_fin_new;
                            inf.Fecha_fin_new = DateTime.Now.AddSeconds(30);
                        }
                    }
                    if (caso_more)
                    {
                        UEUSession n_see = new UEUSession();
                        n_see.Sesion = id_session;
                        n_see.Fecha_fin_old = DateTime.Now;
                        n_see.Fecha_fin_new = DateTime.Now.AddSeconds(30);
                        data.Add(n_see);
                    }
                    consult.Current_sessions = JsonConvert.SerializeObject(data);
                    db.SaveChanges();
                }
            }
        }

        public void reportar_session_empre(string id_session)
        {
            using (var db = new Mapeo("public"))
            {

            }
        }

        public List<UEUSession> obtener_sessiones_reportes_usr(string id_user)
        {
            using (var db = new Mapeo("public"))
            {
                var usr = db.user.Find(int.Parse(id_user));
                if (usr.Current_sessions != null)
                {
                    List<UEUSession> data = JsonConvert.DeserializeObject<List<UEUSession>>(usr.Current_sessions);
                    return data;
                }
                else
                {
                    return null;
                }

            }
        }

        public void update_sessiones_usr(List<UEUSession> data, string id_user)
        {
            using (var db= new Mapeo("public"))
            {
                var usr = db.user.Find(int.Parse(id_user));
                if (data == null)
                {
                    usr.Current_sessions = null;
                }
                else
                {
                    usr.Current_sessions = JsonConvert.SerializeObject(data);
                }
                db.SaveChanges();
            }
        }
    }
}
