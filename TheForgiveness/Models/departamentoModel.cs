using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class departamentoModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [RegularExpression("/[^a-zA-ZáéíóúAÉÍÓÚÑñ]*$/", ErrorMessage ="No se Admiten Espacios, Ni numeros")]
        [DisplayName("Nombre del Departamento")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Departamento { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        // [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        //[Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        //[CompareAttribute("NewPassword", ErrorMessage = "The New Password and Confirm New Password fields did not match.")]
        //[RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ]*$/", ErrorMessage ="No se Admiten Espacios, Ni numeros")]   -> solo palabras
        //  /[^a-zA-ZáéíóúAÉÍÓÚÑñ]*$/ -> solo palabras sn espacio
        /// /^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/  -> palabras con espacio
        /// /[^a-zA-ZáéíóúAÉÍÓÚÑñ0-9]*$/ -> letras y numeros sin espacio
        /// /[^a-zA-ZáéíóúAÉÍÓÚÑñ0-9\s]*$/ -> LEtras y numeros con espacios
        /// /^([a-z]+[a-z1-9._-]*)@{1}([a-z1-9\.]{2,})\.([a-z]{2,3})$/     -> Email
        /// /^[0-9]*$/  -> SOlo numerois sin espacio
        /// /[^0-9\s]*$/
        /*
                 [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su contraseña:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Su Nuevo concepto:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [CompareAttribute("NewPassword", ErrorMessage = "The New Password and Confirm New Password fields did not match.")]
             */
        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Seleccione pais!")]
        [RegularExpression(@"/^[0-9]+$/", ErrorMessage ="ERR")]
        public int Pais { get; set; }

        public departamentoModel()
        {

        }

        public departamentoModel(string Departamento, int Pais)
        {
            this.Departamento = Departamento;
            this.Pais = Pais;
        }
        public departamentoModel(int ID, string Departamento, int Pais)
        {
            this.ID = ID;
            this.Departamento = Departamento;
            this.Pais = Pais;
        }
    }
}