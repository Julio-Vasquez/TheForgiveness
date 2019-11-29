using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class conceptoVictimaModel
    {
        public int ID { get; set; }
        public int Persona { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [StringLength(2200, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string ConceptoInicial { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [StringLength(2200, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string ConceptoFinal { get; set; }

        public conceptoVictimaModel()
        {
        }

        public conceptoVictimaModel(int ID, string ConceptoInicial)
        {
            this.ID = ID;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = "";
        }

        public conceptoVictimaModel(int ID,int Persona, string ConceptoInicial)
        {
            this.Persona = Persona;
            this.ID = ID;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = "";
        }

        public conceptoVictimaModel(int ID, int Persona, string ConceptoInicial, string ConceptoFinal)
        {
            this.Persona = Persona;
            this.ID = ID;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = ConceptoFinal;
        }
    }
}