using System.Data;
using System.Linq;
using Utilitarios;


namespace DatosPersistencia
{
    public class DBReporteEmpresa
    {
        //METODO PARA OBTENER LOS DATOS DEL REPORTE
        public UEURango [] obtener_calificaciones(int id_empresa)
        {
            using (var db= new Mapeo("public"))
            {
                var datosNom = (from j in db.user
                             from l in db.rangos
                             where l.IdUsr == j.IdUsr &&
                             l.IdEmp == id_empresa
                             select j.NomUsr);

                var datosRango= (from j in db.user
                                 from l in db.rangos
                                 where l.IdUsr == j.IdUsr &&
                                 l.IdEmp == id_empresa
                                 select l);

                UEURango [] rang = datosRango.ToArray();
                string [] nom = datosNom.ToArray();
                //SETEAR LOS NOMBRES DE LOS USUARIOS PARA EL REPORTE
                for (int i = 0; i < rang.Length; i++)
                {
                    rang[i].Nom_usuario = nom[i];
                }
                return rang;
            }
            
        }

    }
}
