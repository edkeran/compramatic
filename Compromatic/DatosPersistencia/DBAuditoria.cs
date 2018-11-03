using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBAuditoria
    {
        public static void add(EAuditoria eAuditoria)
        {
            using (var dbc = new Mapeo("audit"))
            {
                dbc.Entry(eAuditoria).State = EntityState.Added;
                dbc.SaveChanges();
            }
        }

        public static EAuditoria get(int id)
        {
            using (var dbc = new Mapeo("audit"))
            {
                EAuditoria eAuditoria = dbc.auditoria.Find(id);
                return eAuditoria != null ? eAuditoria : EAuditoria.newEmpty();
            }
        }

        public static List<EAuditoria> getAll(int id)
        {
            using (var dbc = new Mapeo("audit"))
            {
                return dbc.auditoria.ToList();
            }
        }

        public static List<EAuditoria> getAuditoriaTabla(string nombreTabla)
        {
            using (var dbc = new Mapeo("audit"))
            {
                return (from x in dbc.auditoria where x.Tabla == nombreTabla select x).ToList();
            }
        }

        public static void insert(Object obj, EAcceso eAcceso, string esquema, string tabla)
        {
            EAuditoria eAuditoria = EAuditoria.newEmpty();
            eAuditoria.Fecha = DateTime.Now.ToString();
            eAuditoria.Accion = "INSERT";
            eAuditoria.UsuarioDB = "Postgres";
            eAuditoria.Esquema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.IdAcceso = eAcceso.Id;

            //CICLO FOR PARA OBTENER LAS PROPIEDADES DEL ENCAPSULADO A INTERTAR EN LA DB
            JObject jObject = new JObject();

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    jObject[propertyInfo.Name] = propertyInfo.GetValue(obj).ToString();
                }
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            add(eAuditoria);
        }

        public static void update(Object newObj, Object oldObj, EAcceso eAcceso, string esquema, string tabla)
        {
            EAuditoria eAuditoria = EAuditoria.newEmpty();
            eAuditoria.Fecha = DateTime.Now.ToString();
            eAuditoria.Accion = "UPDATE";
            eAuditoria.UsuarioDB = "Postgres";
            eAuditoria.Esquema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.IdAcceso = eAcceso.Id;

            JObject jObject = new JObject();

            Boolean sinCambios = true;
            //CICLO PARA RECORRER LOS DATOS ANTIGUIOS Y NUEVOS QUE SE VAN A CAMBIAR
            foreach (PropertyInfo propertyInfo in newObj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    if (propertyInfo.Name.Equals("Id"))
                    {
                        jObject[propertyInfo.Name] = propertyInfo.GetValue(newObj).ToString();
                    }
                    if (!propertyInfo.GetValue(newObj).ToString().Equals(propertyInfo.GetValue(oldObj).ToString()) && !propertyInfo.Name.Equals("IdAcceso"))
                    {
                        jObject["new_" + propertyInfo.Name] = propertyInfo.GetValue(newObj).ToString();
                        jObject["old_" + propertyInfo.Name] = propertyInfo.GetValue(oldObj).ToString();
                        sinCambios = false;
                    }
                }
                else if (propertyInfo.PropertyType == typeof(List<int>) && !JsonConvert.SerializeObject(propertyInfo.GetValue(newObj)).Equals(JsonConvert.SerializeObject(propertyInfo.GetValue(oldObj))))
                {
                    jObject["new_" + propertyInfo.Name] = JsonConvert.SerializeObject(propertyInfo.GetValue(newObj));
                    jObject["old_" + propertyInfo.Name] = JsonConvert.SerializeObject(propertyInfo.GetValue(oldObj));
                    sinCambios = false;
                }
            }

            if (sinCambios)
            {
                return;
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            add(eAuditoria);
        }

        public static void delete(Object obj, EAcceso eAcceso, string esquema, string tabla)
        {
            EAuditoria eAuditoria = EAuditoria.newEmpty();
            eAuditoria.Fecha = DateTime.Now.ToString();
            eAuditoria.Accion = "DELETE";
            eAuditoria.UsuarioDB = "Postgres";
            eAuditoria.Esquema = esquema;
            eAuditoria.Tabla = tabla;
            eAuditoria.IdAcceso = eAcceso.Id;

            JObject jObject = new JObject();

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Boolean))
                {
                    jObject[propertyInfo.Name] = propertyInfo.GetValue(obj).ToString();
                }
            }

            eAuditoria.Data = JsonConvert.SerializeObject(jObject);
            add(eAuditoria);
        }
    }
}
