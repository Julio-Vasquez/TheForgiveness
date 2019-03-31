using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class plantillaModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Plantilla del Diplomma:")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Plantilla { get; set; }

        public plantillaModel()
        {
        }

        public plantillaModel(string Plantilla)
        {
            this.Plantilla = Plantilla;
        }

        public plantillaModel(int ID, string Plantilla)
        {
            this.ID = ID;
            this.Plantilla = Plantilla;
        }
    }
}