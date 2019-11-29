using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class percepcionPostconfictoModel
    {
        public int ID { get; set; }        

        [DisplayName("Descripcion del Concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public string Fecha { get; set; }
        public int Usuario { get; set; }

        public percepcionPostconfictoModel()
        {
        }

        public percepcionPostconfictoModel(string Fecha, string Descripcion, int Usuario)
        {
            this.Fecha = Fecha;
            this.Descripcion = Descripcion;
            this.Usuario = Usuario;
        }

        public percepcionPostconfictoModel(int ID, string Fecha, string Descripcion, int Usuario)
        {
            this.ID = ID;
            this.Fecha = Fecha;
            this.Descripcion = Descripcion;
            this.Usuario = Usuario;
        }
    }
}