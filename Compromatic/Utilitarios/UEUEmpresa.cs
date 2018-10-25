using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Empresa", Schema = "dbo")]

    public class UEUEmpresa
    {
        private String nit;
        //[Key]

        [Column("nitEmpresa")]
        public String Nit
        {
            get { return nit; }
            set { nit = value; }
        }
        private String nombre;

        [Column("nomEmpresa")]
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String nomArchivo;

        [Column("nomArchivo")]
        public String NomArchivo
        {
            get { return nomArchivo; }
            set { nomArchivo = value; }
        }
        private String rutaArchivo;

        [Column("rutaArchivo")]
        public String RutaArchivo
        {
            get { return rutaArchivo; }
            set { rutaArchivo = value; }
        }
        private String numero;

        [Column("telEmpresa")]
        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private String correo;

        [Column("correoEmpresa")]
        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private String direccion;

        [Column("dirEmpresa")]
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private String contraseña;

        [Column("passEmpresa")]
        public String Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        private int idTipo;

        [Column("idTipo")]
        public int IdTipo
        {
            get { return idTipo; }
            set { idTipo = value; }
        }

        private DateTime fechaInicio;

        //[Column("idTipo")]
        [NotMapped]
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        private DateTime fechaFin;

        [NotMapped]
        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        private int idTipoMembresia;

        //[Column("idTipo")]
        [NotMapped]
        public int IdTipoMembresia
        {
            get { return idTipoMembresia; }
            set { idTipoMembresia = value; }
        }
        private int id;

        [Key]
        [Column("idEmpresa")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private double calificacion;

        [Column("calificacionEmpresa")]
        public double Calificacion
        {
            get { return calificacion; }
            set { calificacion = value; }
        }

        private String redireccion;

        [NotMapped]
        public string Redireccion
        { get => redireccion;
            set => redireccion = value;
        }

        private int sessiones;

        [Column("Sesiones_Abiertas")]
        public int Sessiones
        { get => sessiones;
            set => sessiones = value;
        }

        private String modifBy;
        [Column("modified_by")]
        public string ModifBy { get => modifBy; set => modifBy = value; }


        private int estadoEmpre;
        [Column("estadoEmpresa")]
        public int EstadoEmpre { get => estadoEmpre; set => estadoEmpre = value; }

        private DateTime fecha_Crea = DateTime.Now;
        [Column("fechaCreacion_empresa")]
        public DateTime Fecha_Crea {
            get => fecha_Crea;
            set => fecha_Crea = value;
        }
        private int intentos = 0;
        [Column("intentos")]
        public int Intentos {
            get => intentos;
            set => intentos = value;
        }


        private DateTime? fch_in;
        private DateTime? fch_fn;

        [Column("inicio_bloqueo")]
        public DateTime? Fch_in {
            get => fch_in;
            set => fch_in = value;
        }

        [Column("fin_bloqueo")]
        public DateTime? Fch_fn {
            get => fch_fn;
            set => fch_fn = value;
        }
    }
}
