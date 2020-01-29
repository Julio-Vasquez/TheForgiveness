using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class ExperienceModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha del Suceso")]
        [DataType(DataType.Date)]
        public string FechaExperiencia { get; set; }

        [DisplayName("Expeiencia Ocurrida:")]
        [StringLength(2200, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Experiencia { get; set; }
	    public int Persona { get; set; }
        public int Municipio { get; set; }

        public ExperienceModel()
        {
        }

        public ExperienceModel(string FechaExperiencia, string Experiencia, int Persona, int Municipio)
        {
            this.FechaExperiencia = FechaExperiencia;
            this.Experiencia = Experiencia;
            this.Persona = Persona;
            this.Municipio = Municipio;
        }

        public ExperienceModel(int ID, string FechaExperiencia,string Experiencia,int Persona,int Municipio)
        {
            this.ID = ID;
            this.FechaExperiencia = FechaExperiencia;
            this.Experiencia = Experiencia;
            this.Persona = Persona;
            this.Municipio = Municipio;
        }
    }
}