using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class rolpermisoModel
    {
        [Required]
        [DisplayName("Seleccione El Rol")]
        public int Rol { get; set; }

        [Required]
        [DisplayName("Seleccione El Permiso")]
        public int Permiso {get;set;}

        [Required]
        [DisplayName("Seleccione El Estado")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        public rolpermisoModel() {

        }

        public rolpermisoModel(int Rol,int Permiso,string State)
        {
            this.Rol = Rol;
            this.Permiso = Permiso;
            this.State = State;
        }

        public rolpermisoModel(string State)
        {
            this.State = State;
        }
    }
}