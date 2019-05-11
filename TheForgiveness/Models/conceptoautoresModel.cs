using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class conceptoautoresModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha De Publicacion")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public int AñoPublicacion { get; set; }
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
        public int Autor { get; set; }

        public conceptoautoresModel()
        {
        }

        public conceptoautoresModel(int AñoPublicacion, string Titulo, string Descripcion, int Autor)
        {
            this.AñoPublicacion = AñoPublicacion;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Autor = Autor;
        }

        public conceptoautoresModel(int ID, int AñoPublicacion, int Concepto, int Autor)
        {
            this.ID = ID;
            this.AñoPublicacion = AñoPublicacion;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Autor = Autor;
        }
    }
}