using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("publicacion_user", Schema = "dbo")]
    public class UEUPublic_User
    {
        //CLASE PARA REALIZAR LA PUBLICACION
        
        private long id_pub;
        private string email_user;
        private string nombreUs;
        private string publicacion;


        [Key]
        [Column("id_publicacion")]
        public long Id_pub { get => id_pub; set => id_pub = value; }

        [Column("email_user")]
        public string Email_user { get => email_user; set => email_user = value; }

        [Column("nom_user")]
        public string NombreUs { get => nombreUs; set => nombreUs = value; }

        [Column("publiacion")]
        public string Publicacion { get => publicacion; set => publicacion = value; }
    }
}
