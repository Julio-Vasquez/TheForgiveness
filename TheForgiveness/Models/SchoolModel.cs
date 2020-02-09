using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class SchoolModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nombre del Colegio:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Seleccione El Municipio")]
        public int Municipio { get; set; }

        public SchoolModel()
        {
        }

        public SchoolModel(string Nombre, int Municipio)
        {
            this.Nombre = Nombre;
            this.Municipio = Municipio;
        }

        public SchoolModel(int ID, string Nombre,int Municipio)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Municipio = Municipio;
        }
    }

}