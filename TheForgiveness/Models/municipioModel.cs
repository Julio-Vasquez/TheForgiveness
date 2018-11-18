using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class municipioModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre Del Municipio")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Municipio { get; set; }

        [Required]
        [DisplayName("Seleccione El Estado")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required]
        [DisplayName("Seleccione El Departamento")]
        public int Departamento { get; set; }

        public municipioModel()
        {

        }

        public municipioModel(int ID,string Municipio,string State,int Departamento)
        {
            this.ID = ID;
            this.Municipio = Municipio;
            this.State = State;
            this.Municipio=Municipio;
        }
        public municipioModel(string Municipio, string State, int Departamento)
        {
            this.Municipio = Municipio;
            this.State = State;
            this.Municipio = Municipio;
        }
    }
}