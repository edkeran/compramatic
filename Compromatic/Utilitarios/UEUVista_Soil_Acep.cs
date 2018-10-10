using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UEUVista_Soil_Acep
    {
        private int id_Emp;
        private String nom_emp;
        private String tel_emp;
        private String correoEmp;
        private String dir_emp;
        private String nit_emp;
        private String ruta_arch;
        private int estado_emp;
        private Double cal_emp;
        private DateTime fecha_crea;
        private int id_solicit;
        private int? estado_solict;

        //REVISAR ID´S
        public int idEmpresa { get => id_Emp; set => id_Emp = value; }
        public string nomEmpresa { get => nom_emp; set => nom_emp = value; }
        public string telEmpresa { get => tel_emp; set => tel_emp = value; }
        public string correoEmpresa { get => correoEmp; set => correoEmp = value; }
        public string dirEmpresa { get => dir_emp; set => dir_emp = value; }
        public string nitEmpresa { get => nit_emp; set => nit_emp = value; }
        public string rutaArchivo { get => ruta_arch; set => ruta_arch = value; }
        public int estadoEmpresa { get => estado_emp; set => estado_emp = value; }
        public double calificacionEmpresa { get => cal_emp; set => cal_emp = value; }
        public DateTime fechaCreacion_empresa { get => fecha_crea; set => fecha_crea = value; }
        public int idSolicitud_registro { get => id_solicit; set => id_solicit = value; }
        public int? estadoSolicitud { get => estado_solict; set => estado_solict = value; }
    }
}
