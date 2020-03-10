using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TheForgiveness.Models
{
    public class PerdonPosCoflicModel
    {
        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Breve Descripción del posconflicto:")]
        [StringLength(2500, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [MinLength(10, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su concepto el perdon!:")]
        [StringLength(2200, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 20)]
        [DataType(DataType.Text)]
        public string ConceptoInicial { get; set; }
    }
}