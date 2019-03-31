using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class usuarioModel
    {
        public  int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Usuario:")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ0-9]*$/", ErrorMessage = "No se Admiten Espacios")]
        [MinLength(4, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su contraseña:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public usuarioModel()
        {
        }

        public usuarioModel(string UserName, string PassWord)
        {
            this.UserName = UserName;
            this.PassWord = PassWord;
        }

        public usuarioModel(int ID, string UserName, string PassWord)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.PassWord = PassWord;
        }
    }
}