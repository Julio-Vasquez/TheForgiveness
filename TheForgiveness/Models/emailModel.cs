using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class emailModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Email:")]
        [RegularExpression(@"//^([a-z]+[a-z1-9._-]*)@{1}([a-z1-9\.]{2,})\.([a-z]{2,3})$/", ErrorMessage = "E-Mail Invalido")]
        [StringLength(200, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 8)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public emailModel()
        {
        }

        public emailModel(string Email)
        {
            ID = 0;
            this.Email = Email;
        }

        public emailModel(int ID, string Email)
        {
            this.ID = ID;
            this.Email = Email;
        }
    }
}