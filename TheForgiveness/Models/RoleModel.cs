using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class RoleModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Rol :")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]+$/",ErrorMessage ="NO se admiten NUmeros")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Rol { get; set; }

        public RoleModel()
        {
        }

        public RoleModel(int ID, string Rol)
        {
            this.ID = ID;
            this.Rol = Rol;
        }

        public RoleModel(string Rol)
        {
            this.Rol = Rol;
        }
    }
}