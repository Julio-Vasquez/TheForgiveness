using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class experienciaModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha del Suceso")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public DateTime FechaExperiencia { get; set; }

        [DisplayName("Expeiencia Ocurrida:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Experiencia { get; set; }
	    public int Persona { get; set; }
        public int Municipio { get; set; }

        public experienciaModel()
        {

        }

        public experienciaModel(DateTime FechaExperiencia, string Experiencia, int Persona, int Municipio)
        {
            this.FechaExperiencia = FechaExperiencia;
            this.Experiencia = Experiencia;
            this.Persona = Persona;
            this.Municipio = Municipio;
        }

        public experienciaModel(int ID,DateTime FechaExperiencia,string Experiencia,int Persona,int Municipio)
        {
            this.ID = ID;
            this.FechaExperiencia = FechaExperiencia;
            this.Experiencia = Experiencia;
            this.Persona = Persona;
            this.Municipio = Municipio;
        }
    }
}