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

        [Required]
        [DisplayName("Escribir El Titulo De La Pagina")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Icon { get; set; }

        [Required]
        [DisplayName("Selecione El Estado")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        public vistaModel()
        {

        }

        public vistaModel(int ID, string Titulo, string Icon, string State)
        {
            this.ID = ID;
            this.Titulo = Titulo;
            this.Icon = Icon;
            this.State = State;
        }

        public vistaModel(string Titulo, string Icon, string State)
        {
            this.Titulo = Titulo;
            this.Icon = Icon;
            this.State = State;
        }
    }
}