using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class asignaturaModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nombre de Asignatura:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        public asignaturaModel()
        {
        }

        public asignaturaModel(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public asignaturaModel(int ID, string Nombre)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}