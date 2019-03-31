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

        [DisplayName("Primier Nombre:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string PriNombre { get; set; }

        [DisplayName("Segundo Nombre:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string SegNombre { get; set; }

        [DisplayName("Primer Apellido:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string PriApellido { get; set; }

        [DisplayName("Segundo Apellido:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
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
        }

        public autoresModel(int ID, string PriNombre,string SegNombre,string PriApellido,string SegApellido)
        {
            this.ID = ID;
            this.PriNombre = PriNombre;
            this.SegNombre = SegNombre;
            this.PriApellido = PriApellido;
        }
    }
}