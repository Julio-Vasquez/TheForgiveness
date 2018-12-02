using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class victimiologiaModel
    {
        public int ID { get; set; }

        [DisplayName("Titulo de la Victimiologia:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [DisplayName("DEscripcion de la Victimiologia:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        public victimiologiaModel()
        {

        }

        public victimiologiaModel(string Nombre,string Descripcion)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }

        public victimiologiaModel(int ID, string Nombre, string Descripcion)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }
    }
}