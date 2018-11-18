using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class generoModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nombre Del Genero")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ]+$/", ErrorMessage = "No se Admiten Espacios ni numeros")]
        [StringLength(20, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Genero { get; set; }

        public generoModel()
        {

        }

        public generoModel(int ID, string Genero)
        {
            this.ID = ID;
            this.Genero = Genero;
        }

        public generoModel(string Genero)
        {
            this.Genero = Genero;
        }
    }
}