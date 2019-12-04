using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class PerfilModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Numero De Identificacion")]
        [Range(100000, int.MaxValue, ErrorMessage = "NUmero no valido")]
        public long NumIdentificacion { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primer Nombre")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string PriNombre { get; set; }

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
        [DisplayName("Tu edad:")]
        [Range(10, 125, ErrorMessage = "Edad no valido")]
        public int Edad { get; set; }

        public int Genero { get; set; }

        public int TipoDocumento { get; set; }

        public int Municipio { get; set; }

        public PerfilModel(long numIdentificacion, string priNombre, string segNombre, string priApellido, string segApellido, string fechaNacimiento, int edad, int genero, int tipoDocumento, int municipio)
        {
            NumIdentificacion = numIdentificacion;
            PriNombre = priNombre;
            SegNombre = segNombre;
            PriApellido = priApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
            Genero = genero;
            TipoDocumento = tipoDocumento;
            Municipio = municipio;
        }

        public PerfilModel(int iD, long numIdentificacion, string priNombre, string segNombre, string priApellido, string segApellido, string fechaNacimiento, int edad, int genero, int tipoDocumento, int municipio)
        {
            ID = iD;
            NumIdentificacion = numIdentificacion;
            PriNombre = priNombre;
            SegNombre = segNombre;
            PriApellido = priApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
            Genero = genero;
            TipoDocumento = tipoDocumento;
            Municipio = municipio;
        }

        public PerfilModel(int iD, long numIdentificacion, string priNombre, string segNombre, string priApellido, string segApellido, string fechaNacimiento, int edad)
        {
            ID = iD;
            NumIdentificacion = numIdentificacion;
            PriNombre = priNombre;
            SegNombre = segNombre;
            PriApellido = priApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
        }

        public PerfilModel()
        {
        }
    }
}