using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class rolModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Escribir El Rol")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Rol { get; set; }

        [Required]
        [DisplayName("Selecione El Estado")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        public rolModel()
        {

        }

        public rolModel(int ID, string Rol, string State)
        {
            this.ID = ID;
            this.Rol = Rol;
            this.State = State;
        }

        public rolModel(string Rol, string State)
        {
            this.Rol = Rol;
            this.State = State;
        }
    }
}