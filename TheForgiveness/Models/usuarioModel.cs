using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Usuario:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su contraseña:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        

        public UsuarioModel(string UserName, string PassWord)
        {
            this.Username = UserName;
            this.PassWord = PassWord;
        }

        public UsuarioModel(int ID, string UserName, string PassWord)
        {
            this.ID = ID;
            this.Username = UserName;
            this.PassWord = PassWord;
        }

        public UsuarioModel()
        {
        }
    }
}