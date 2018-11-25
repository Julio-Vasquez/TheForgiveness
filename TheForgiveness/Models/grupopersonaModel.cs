using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class grupopersonaModel
    {
        public int Grup { get; set; }
        public int Estudiante { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Codigo del Estudiante")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string CodigoEstudiante { get; set; }

        public grupopersonaModel()
        {

        }

        public grupopersonaModel(string CodigoEstudiante)
        {
            this.CodigoEstudiante = CodigoEstudiante;
        }

        public grupopersonaModel(int Grup,int Estudiante,string CodigoEstudiante)
        {
            this.Grup = Grup;
            this.Estudiante = Estudiante;
            this.CodigoEstudiante = CodigoEstudiante;
        }
    }
}