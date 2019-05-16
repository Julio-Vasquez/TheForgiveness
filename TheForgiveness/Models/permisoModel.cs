using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class permisoModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Titulo De La Pagina")]
        [StringLength(40, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2}. y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Icono de la vista")]
        [StringLength(120, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2}. y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Icon { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Url De La Pagina")]
        [MinLength(4,ErrorMessage ="Minimo {2} Caracteres")]
        [DataType(DataType.Text)]
        public string Url { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Archivo")]
        [MinLength(3, ErrorMessage = "Minimo {2} Caracteres")]
        [DataType(DataType.Text)]
        public string Archivo { get; set; }

        public int Vista { get; set; }

        public permisoModel()
        {
        }

        public permisoModel(int ID, string Titulo,string Url,int Vista)
        {
            this.ID = ID;
            this.Titulo = Titulo;
            this.Url = Url;
            this.Vista = Vista;
        }

        public permisoModel(string Titulo, string Url, int Vista)
        {
            this.Titulo = Titulo;
            this.Url = Url;
            this.Vista = Vista;
        }
    }
}