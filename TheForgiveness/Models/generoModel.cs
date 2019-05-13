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
        [DisplayName("Nombre del Genero:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Text)]
        public string Genero { get; set; }

        public generoModel(int iD, string genero)
        {
            ID = iD;
            Genero = genero;
        }

        public generoModel()
        { }

        public generoModel(string genero)
        {
            Genero = genero;
        }
    }
}