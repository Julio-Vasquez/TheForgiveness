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

        [Required]
        [DisplayName("Numero De Identificacion")]
        public int NumIdentificacion { get; set; }

        [Required]
        [DisplayName("Primer Nombre")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string PriNombre { get; set; }

        [Required]
        [DisplayName("Segundo Nombre")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string SegNombre { get; set; }

        [Required]
        [DisplayName("Primer Apellido")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string PriApellido { get; set; }

        [Required]
        [DisplayName("Segundo Apellido")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string SegApellido { get; set; }

        [Required]
        [DisplayName("Fecha De Nacimiento")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DisplayName("Seleccione El Estado")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required]
        [DisplayName("Seleccione El Genero")]
        public int Genero { get; set; }

        [Required]
        [DisplayName("Seleccione El Tipo De Documento")]
        public int TipoDocumento { get; set; }

        [Required]
        [DisplayName("Seleccione El Municipio")]
        public int Municipio { get; set; }

        public personaModel()
        {

        }

        public personaModel(int ID,int NumIdentificacion,string PriNombre,string SegNombre,string PriApellido,string SegApellido,DateTime FechaNacimiento,string State,int Genero,int TipoDocumento,int Municipio)
        {
            this.ID = ID;
            this.NumIdentificacion = NumIdentificacion;
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
            this.SegNombre = SegNombre;
            this.FechaNacimiento = FechaNacimiento;
            this.State = State;
            this.Genero = Genero;
            this.TipoDocumento = TipoDocumento;
            this.Municipio = Municipio;
        }

        public personaModel(int NumIdentificacion, string PriNombre, string SegNombre, string PriApellido, string SegApellido, DateTime FechaNacimiento, string State, int Genero, int TipoDocumento, int Municipio)
        {
            this.NumIdentificacion = NumIdentificacion;
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
            this.SegNombre = SegNombre;
            this.FechaNacimiento = FechaNacimiento;
            this.State = State;
            this.Genero = Genero;
            this.TipoDocumento = TipoDocumento;
            this.Municipio = Municipio;
        }
    }
}