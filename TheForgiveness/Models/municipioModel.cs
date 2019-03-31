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

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Nombre Del Municipio")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]+$/", ErrorMessage = "No se Admiten Numeros")]
        [StringLength(50, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Municipio { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Seleccione El Departamento")]
        public int Departamento { get; set; }

        public municipioModel()
        {
        }

        public municipioModel(int ID,string Municipio,int Departamento)
        {
            this.ID = ID;
            this.Municipio = Municipio;
            this.Departamento = Departamento;
        }

        public municipioModel(string Municipio, int Departamento)
        {
            this.Municipio = Municipio;
            this.Departamento = Departamento;
        }
    }
}