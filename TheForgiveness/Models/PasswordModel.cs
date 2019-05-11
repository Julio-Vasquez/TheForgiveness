using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class PasswordModel
    {
        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Nueva contraseña:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Repetir Nueva contraseña:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage ="No coinciden las contrase;as")]
        public string RepeatPassWord { get; set; }



        public PasswordModel(string PassWord, string RepeatPassWord)
        {
            this.PassWord = PassWord;
            this.RepeatPassWord = RepeatPassWord;
        }

        public PasswordModel()
        { }
    }
}