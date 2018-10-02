using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DBEmpresa
    {
        //INSERT DE LA EMPRESA ME TOCA REVISAR SI DEBO USAR OTRA TABLA
        public void InsertarEmpresa(UEUEmpresa empresa)
        {
            using (var db = new Mapeo("public"))
            {
                empresa.Calificacion = 5;
                empresa.Sessiones = 0;
                empresa.EstadoEmpre = 0;
                //PASO 1 INSERTAR LA EMPRESA EN LA BASE DE DATOS
                db.empre.Add(empresa);
                db.SaveChanges();
                //PASO 2 OBTENER LA EMPRESA INSERTADA POR EL NIT DE LA MISMA
                List<UEUEmpresa> emp = db.empre.Where(x => x.Nit == empresa.Nit).ToList<UEUEmpresa>();
                //PASO 3 INSERTAR EN LA SOLICITUD REGISTRO
                UEUEmpresa empres = emp.ElementAt(0);
                UEUSolici_Regist soli = new UEUSolici_Regist();
                soli.ModifBy = empresa.ModifBy;
                soli.Id_empresa = empres.Id;
                soli.Estado_solici = 1;

                db.sol_reg.Add(soli);
                db.SaveChanges();

                //PASO 4 INSERTAR EN LA TABLA MEMBRESIA 
                UEUMembresia mem = new UEUMembresia();
                mem.Fecha_inicio = empresa.FechaInicio;
                mem.Fecha_fin = empresa.FechaFin;
                mem.ModifieBy = empresa.ModifBy;
                mem.Id_tipo_mem = empresa.IdTipoMembresia;
                mem.Estado_mem = 0;
                mem.Id_empresa = empres.Id;

                db.membresia.Add(mem);
                db.SaveChanges();
            }
        }

    }
}
