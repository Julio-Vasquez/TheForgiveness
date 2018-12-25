using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheForgiveness.Models
{
    public class studentModel
    {

        //username = email
        //password = numIdentificacion

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Numero De Identificacion")]
        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "SOlo Numeros")]
        [Range(100000, int.MaxValue, ErrorMessage = "NUmero no valido")]
        public long NumIdentificacion { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primer Nombre")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ]+$/", ErrorMessage = "NO se admiten espacios ni numeros")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string PriNombre { get; set; }

        [DisplayName("Segundo Nombre")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ]*$/", ErrorMessage = "NO se admiten espacios ni numeros")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string SegNombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primer Apellido")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ]+$/", ErrorMessage = "NO se admiten espacios ni numeros")]
        [StringLength(55, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string PriApellido { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Segundo Apellido")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ]+$/", ErrorMessage = "NO se admiten espacios ni numeros")]
        [StringLength(55, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string SegApellido { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha De Nacimiento")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Email:")]
        [RegularExpression(@"//^([a-z]+[a-z1-9._-]*)@{1}([a-z1-9\.]{2,})\.([a-z]{2,3})$/", ErrorMessage = "E-Mail Invalido")]
        [StringLength(400, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 8)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Seleccione El Genero")]
        public int Genero { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Seleccione El Municipio")]
        public int Municipio { get; set; }

    }
}