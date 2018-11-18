using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class vistaModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Titulo De La Pagina")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ0-9\s]+$/",ErrorMessage ="No se admiten caracteres raros")]
        [StringLength(40, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Icono De La Pagina")]
        [DataType(DataType.Text)]
        [MinLength(4,ErrorMessage ="Minimo {2}")]
        public string Icon { get; set; }


        public vistaModel()
        {

        }

        public vistaModel(int ID, string Titulo, string Icon)
        {
            this.ID = ID;
            this.Titulo = Titulo;
            this.Icon = Icon;
        }

        public vistaModel(string Titulo, string Icon)
        {
            this.Titulo = Titulo;
            this.Icon = Icon;
        }
    }
}