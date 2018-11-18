using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class paisModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre del Pais")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Pais { get; set; }

        public paisModel()
        {

        }
        public paisModel(string Pais)
        {
            this.Pais = Pais;
        }
        public paisModel(int ID, string Pais)
        {
            this.ID = ID;
            this.Pais = Pais;
        }

    }
}