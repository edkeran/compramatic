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

        public void actualizar_contrasena_empresa(UEUEmpresa emp)
        {
            using (var db = new Mapeo("public"))
            {
                //UPDATE PASSWORD OF THE COMPANY
                var empresa = db.empre.Find(emp.Id);
                empresa.Contraseña = emp.Contraseña;
                empresa.ModifBy = emp.ModifBy;
                db.SaveChanges();
            }
        }

        //METODO PARA TRAER LA EMPRESA ACTUAL Y POR LO LO TANTO SABER LA CONTRASEÑA ACTUAL
        public UEUEmpresa traer_empresa_actual(UEUEmpresa emp)
        {
            using (var db= new Mapeo("public"))
            {
                var empresa = db.empre.Find(emp.Id);
                return (UEUEmpresa)empresa;
            }
        }

        //METODO PARA ACTUALIZAR LA EMPRESA
        public void update_Empresa(UEUEmpresa datos)
        {
            using (var db= new Mapeo("public"))
            {
                var old = db.empre.Find(datos.Id);
                old.Nombre = datos.Nombre;
                old.Nit = datos.Nit;
                old.Numero = datos.Numero;
                old.Correo = datos.Correo;
                old.Direccion = datos.Direccion;
                old.ModifBy = datos.ModifBy;
                db.SaveChanges();
            }
        }


    }
}
