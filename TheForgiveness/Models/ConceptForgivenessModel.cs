using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class ConceptForgivenessModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Año De Publicacion")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string AñoPublicacion { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Titulo del Concepto:")]
        [MinLength(7, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Descripcion del Concepto:")]
        [MinLength(10, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        public int Autor { get; set; }

        public ConceptForgivenessModel()
        {
        }

        public ConceptForgivenessModel(string AñoPublicacion, string Titulo, string Descripcion, int Autor)
        {
            this.AñoPublicacion = AñoPublicacion;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Autor = Autor;
        }

        public ConceptForgivenessModel(int ID, string AñoPublicacion, string Titulo, string Descripcion, int Autor)
        {
            this.ID = ID;
            this.AñoPublicacion = AñoPublicacion;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Autor = Autor;
        }

        public ConceptForgivenessModel(string AñoPublicacion, string Titulo, string Descripcion)
        {
            this.AñoPublicacion = AñoPublicacion;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
        }
    }
}