using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class personaModel
    {
        public int ID { get; set; }

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
        [DisplayName("Seleccione El Genero")]
        public int Genero { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("El Tipo De Documento")]
        public int TipoDocumento { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Seleccione El Municipio")]
        public int Municipio { get; set; }

        public personaModel()
        {

        }

        public personaModel(int ID, long NumIdentificacion, string PriNombre, string SegNombre, string PriApellido, string SegApellido, string FechaNacimiento, int Genero, int TipoDocumento, int Municipio)
        {
            this.ID = ID;
            this.NumIdentificacion = NumIdentificacion;
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
            this.SegNombre = SegApellido;
            this.FechaNacimiento = FechaNacimiento;
            this.Genero = Genero;
            this.TipoDocumento = TipoDocumento;
            this.Municipio = Municipio;
        }

        public personaModel(long NumIdentificacion, string PriNombre, string SegNombre, string PriApellido, string SegApellido, string FechaNacimiento, int Genero, int TipoDocumento, int Municipio)
        {
            this.NumIdentificacion = NumIdentificacion;
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
            this.SegApellido = SegApellido;
            this.FechaNacimiento = FechaNacimiento;
            this.Genero = Genero;
            this.TipoDocumento = TipoDocumento;
            this.Municipio = Municipio;
        }
    }
}