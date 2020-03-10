using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TheForgiveness.Models
{
    public class MyHistoryModel
    {
        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Hace cuanto tiempo sucedio:")]
        [StringLength(2500, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [MinLength(10, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string TiempoExperiencia { get; set; }

        [DisplayName("Expeiencia Ocurrida:")]
        [StringLength(2200, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Experiencia { get; set; }

        public int Usuario { get; set; } //con este toca obtener la persona y el usuario

        public int Municipio { get; set; }
    }
}