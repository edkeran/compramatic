using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Rango", Schema = "public")]
    public class UEURango
    {
        private int idUsr;
        [Column("idUsuario")]
        public int IdUsr
        {
            get { return idUsr; }
            set { idUsr = value; }
        }
        private int idEmp;

        [Column("idEmpresa")]
        public int IdEmp
        {
            get { return idEmp; }
            set { idEmp = value; }
        }
        private string comentario;

        [Column("comentarios")]
        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }
        private double rango;

        [Column("rango")]
        public double Rango
        {
            get { return rango; }
            set { rango = value; }
        }

        private int calificador;

        [Column("calificador")]
        public int Calificador {
            get => calificador;
            set => calificador = value;
        }

        private int idRango;
        [Key]
        [Column("idRango")]
        public int IdRango {
            get => idRango;
            set => idRango = value;
        }

        private String modifiBy;

        [Column("modified_by")]
        public string ModifiBy {
            get => modifiBy;
            set => modifiBy = value;
        }

        private DateTime fechaRango;
        [Column("fechaRango")]
        public DateTime FechaRango {
            get => fechaRango;
            set => fechaRango = value;
        }

        private String nom_usuario;
        [NotMapped]
        public string Nom_usuario {
            get => nom_usuario;
            set => nom_usuario = value;
        }

    }
}
