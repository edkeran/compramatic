using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{

    [Serializable]
    [Table("Usuario", Schema = "dbo")]
    public class UEUsuario
    {
        private int idUsr;

        [Key]
        [Column("idUsuario")]
        public int IdUsr
        {
            get { return idUsr; }
            set { idUsr = value; }
        }
        private String nomUsr;

        [Column("nomUsuario")]
        public String NomUsr
        {
            get { return nomUsr; }
            set { nomUsr = value; }
        }

        private String apelUsr;

        [Column("apeUsuario")]
        public String ApelUsr
        {
            get { return apelUsr; }
            set { apelUsr = value; }
        }

        private String telUsr;

        [Column("telUsuario")]
        public String TelUsr
        {
            get { return telUsr; }
            set { telUsr = value; }
        }

        private String correoUsr;

        [Column("correoUsuario")]
        public String CorreoUsr
        {
            get { return correoUsr; }
            set { correoUsr = value; }
        }

        private String passUsr;

        [Column("passUsuario")]
        public String PassUsr
        {
            get { return passUsr; }
            set { passUsr = value; }
        }

        private String ccUsr;

        [Column("ccUsuario")]
        public String CcUsr
        {
            get { return ccUsr; }
            set { ccUsr = value; }
        }

        private String dirUsr;

        [Column("dirUsuario")]
        public String DirUsr
        {
            get { return dirUsr; }
            set { dirUsr = value; }
        }
        private String nomArch;

        [Column("nomArchivo")]
        public String NomArch
        {
            get { return nomArch; }
            set { nomArch = value; }
        }

        private String rutaArch;

        [Column("rutaArchivo")]
        public String RutaArch
        {
            get { return rutaArch; }
            set { rutaArch = value; }
        }

        private int idTipo;

        [Column("idTipo")]
        public int IdTipo {
            get => idTipo;
            set => idTipo = value;
        }

        private int estUsr;

        [Column("estadoUsuario")]
        public int EstUsr
        {
            get { return estUsr; }
            set { estUsr = value; }
        }

        private String modifBy;

        [Column("modified_by")]
        public string ModifBy {
            get => modifBy;
            set => modifBy = value;
        }

        private String redireccion;

        [NotMapped]
        public string Redireccion
        { get => redireccion;
            set => redireccion = value; }

        private String calificacion;

        [NotMapped]
        public string Calificacion
        { get => calificacion;
            set => calificacion = value; }

        private int sessiones;

        [Column("Sesiones_Abiertas")]
        public int Sessiones
        { get => sessiones;
            set => sessiones = value; }

        private DateTime? inc_bloq;
        [Column("inicio_bloqueo")]
        public DateTime? Inc_bloq {
            get => inc_bloq;
            set => inc_bloq = value;
        }

        private DateTime? fin_bloqu;
        [Column("fin_bloqueo")]
        public DateTime? Fin_bloqu {
            get => fin_bloqu;
            set => fin_bloqu = value;
        }

        private DateTime crea_Usr;
        [Column("fechaCreacion_usuario")]
        public DateTime Crea_Usr {
            get => crea_Usr;
            set => crea_Usr = value;
        }

        private int intentos;
        [Column("intentos")]
        public int Intentos {
            get => intentos;
            set => intentos = value;
        }

        private Double? calificacion2;
        [Column("calificacionUsuario")]
        public Double? Calificacion2 {
            get => calificacion2;
            set => calificacion2 = value;
        }
       
        private string current_sessions;
        [Column("Sessiones_Info")]
        public string Current_sessions {
            get => current_sessions;
            set => current_sessions = value;
        }

    }
}
