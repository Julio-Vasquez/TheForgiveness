using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class conceptoModel
    {
        public int ID { get; set; }


        [DisplayName("Nombre del Concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }


        [DisplayName("Descripcion del Concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        public conceptoModel() {

        }
        public conceptoModel(string Titulo, string Descripcion)
        {
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
        }
        public conceptoModel(int ID,string Titulo, string Descripcion)
        {
            this.ID = ID;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
        }
    }
}