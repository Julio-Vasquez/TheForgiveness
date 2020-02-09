using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class CountryModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Nombre del Pais")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]+$/", ErrorMessage ="Solo se aceptan letras")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Pais { get; set; }

        public CountryModel()
        {
        }

        public CountryModel(string Pais)
        {
            this.Pais = Pais;
        }

        public CountryModel(int ID, string Pais)
        {
            this.ID = ID;
            this.Pais = Pais;
        }
    }
}