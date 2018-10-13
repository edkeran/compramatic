using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("Reporte", Schema = "public")]
    public class UEUReporte
    {
        private int idRep;
        private int idmotivoR;
        private int idUsua;
        private int idProduct;
        private DateTime fechaRep;
        private String modifBy;

        [Key]
        [Column("idReporte")]
        public int idReporte
        {
            get => idRep;
            set => idRep = value;
        }

        [Column("idMotivoR")]
        public int idMotivoR
        {
            get => idmotivoR;
            set => idmotivoR = value;
        }

        [Column("idUsuario")]
        public int idUsuario
        {
            get => idUsua;
            set => idUsua = value;
        }

        [Column("idProducto")]
        public int idProducto
        {
            get => idProduct;
            set => idProduct = value;
        }

        [Column("fechaReporte")]
        public DateTime fechaReporte
        {
            get => fechaRep;
            set => fechaRep = value;
        }

        [Column("modified_by")]
        public string modified_by
        {
            get => modifBy;
            set => modifBy = value;
        }
    }
}
