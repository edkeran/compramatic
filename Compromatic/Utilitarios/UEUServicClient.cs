using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("clientes", Schema = "servicios")]
    public class UEUServicClient
    {
        private int id_serv;
        private string nomClient;
        private string hash;

        [Key]
        [Column("id_Cliente")]
        public int Id_serv { get => id_serv; set => id_serv = value; }
        [Column("nom_cliente")]
        public string NomClient { get => nomClient; set => nomClient = value; }
        [Column("password")]
        public string Hash { get => hash; set => hash = value; }
    }
}
