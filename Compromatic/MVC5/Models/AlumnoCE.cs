using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class AlumnoCE
    {
        [Required]
        [Display(Name ="Ingrese Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Edad Del Alumno")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Sexo Del Alumno")]
        public string Sexo { get; set; }
    }

    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno
    {
        public string NombreCompleto { get => Nombres + " " + Apellidos;}
    }
}