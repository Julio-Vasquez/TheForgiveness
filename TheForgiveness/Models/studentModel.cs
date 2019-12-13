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
        [DisplayName("Num Identificación")]
        [Range(100000, int.MaxValue, ErrorMessage = "Numero no valido")]
        public long NumIdentificacion { get; set; }


        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Num Telefonico")]
        [Range(100000, int.MaxValue, ErrorMessage = "Numero no valido")]
        public long Telefono { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primer Nombre")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string PriNombre { get; set; }

        [DefaultValue("")]
        [DisplayName("Segundo Nombre")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string SegNombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primer Apellido")]
        [StringLength(55, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string PriApellido { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Segundo Apellido")]
        [StringLength(55, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string SegApellido { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha De Nacimiento")]
        [DataType(DataType.Date)]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Email:")]
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

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Seleccione El Grupo")]
        public int Grupo { get; set; }

        public studentModel()
        {
        }

        public studentModel(long numIdentificacion, string priNombre, string segNombre, string priApellido, string segApellido, string fechaNacimiento, string email, int genero, int municipio)
        {
            NumIdentificacion = numIdentificacion;
            PriNombre = priNombre;
            SegNombre = segNombre;
            PriApellido = priApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Genero = genero;
            Municipio = municipio;
        }
        public studentModel(long numIdentificacion, string priNombre, string segNombre, string priApellido, string segApellido, string fechaNacimiento, string email)
        {
            NumIdentificacion = numIdentificacion;
            PriNombre = priNombre;
            SegNombre = segNombre;
            PriApellido = priApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
        }
        public studentModel(long numIdentificacion, string priNombre, string segNombre, string priApellido, string segApellido, string fechaNacimiento, string email, int genero)
        {
            NumIdentificacion = numIdentificacion;
            PriNombre = priNombre;
            SegNombre = segNombre;
            PriApellido = priApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Genero = genero;
        }
    }
}