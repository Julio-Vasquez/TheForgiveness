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

        [Required]
        [DisplayName("Nombre Del Genero")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Genero { get; set; }

        [Required]
        [DisplayName("Seleccione El Estado")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        public generoModel()
        {

        }

        public generoModel(int ID,string Genero,string State)
        {
            this.ID = ID;
            this.Genero = Genero;
            this.State = State;
        }

        public generoModel(string Genero, string State)
        {
            this.Genero = Genero;
            this.State = State;
        }
    }
}