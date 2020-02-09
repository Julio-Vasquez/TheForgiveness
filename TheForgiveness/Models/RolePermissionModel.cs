using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class RolePermissionModel
    {
        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Seleccione El Rol")]
        public int Rol { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Seleccione El Permiso")]
        public int Permiso {get;set;}

        public RolePermissionModel()
        {
        }

        public RolePermissionModel(int Rol,int Permiso)
        {
            this.Rol = Rol;
            this.Permiso = Permiso;
        }
    }
}