using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class autoresModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primier Nombre:")]
        [MinLength(3, ErrorMessage = "Minimo")]
        [DataType(DataType.Text)]
        public string PriNombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Segundo Nombre:")]
        [MinLength(3, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string SegNombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Primer Apellido:")]
        [MinLength(3, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string PriApellido { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Segundo Apellido:")]
        [MinLength(3, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string SegApellido { get; set; }

        public autoresModel()
        {   
        }

        public autoresModel(string PriNombre, string SegNombre, string PriApellido, string SegApellido)
        {
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
            this.SegApellido = SegApellido;
        }

        public autoresModel(int ID, string PriNombre,string SegNombre,string PriApellido,string SegApellido)
        {
            this.ID = ID;
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
            this.SegApellido = SegApellido;
        }
    }
}