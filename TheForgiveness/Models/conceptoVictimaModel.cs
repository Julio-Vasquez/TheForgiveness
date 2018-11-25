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

        public int Victimologia { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string ConceptoInicial { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string ConceptoFinal { get; set; }


        public conceptoVictimaModel()
        {

        }

        public conceptoVictimaModel(int Victimologia, string ConceptoInicial)
        {
            this.Victimologia = Victimologia;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = "";
        }

        public conceptoVictimaModel(int Victimologia, string ConceptoInicial, string ConceptoFinal)
        {
            this.Victimologia = Victimologia;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = ConceptoFinal;
        }

    }
}