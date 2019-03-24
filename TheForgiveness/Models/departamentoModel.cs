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
        [Phone]
        [DataType(DataType.PhoneNumber)]
             */

        /*
         Uso de Ajax.BeginForm 
El Ajax.BeginForm toma los siguientes parámetros
actionName
controllerName
rutaValores
ajaxOpciones
htmlAtributos
actionName
Este parámetro se utiliza para definir el nombre de la acción para la que se ejecutará la acción. 

controllerName 

Este es un parámetro usado para definir el nombre del controlador. 

rutaValores
Este parámetro se utiliza para pasar el objeto que contiene los parámetros de ruta.
ajaxOpciones

Este parámetro se utiliza para pasar las propiedades de las solicitudes de Ajax, que realiza la solicitud al servidor de forma asíncrona. ajaxOptions tiene las siguientes propiedades.
Url: esta propiedad se usa para obtener y configurar la url.

HttpMethod: esta propiedad se utiliza para definir el método de envío de formulario, como POST, GET, PUT, Delete, etc.

Confirmar: esta propiedad se utiliza para mostrar el cuadro de confirmación antes de enviar la solicitud al servidor.

UpdateTargetId: esta propiedad se usa para especificar la identificación del elemento DOM para la parte que se actualizará; por ejemplo, si especificamos el ID de etiqueta DIV, solo esa parte del DIV en particular se actualizará.

OnSuccess: esta propiedad se utiliza para definir el archivo JavaScript que se activará después de la solicitud Ajax exitosa.

OnFailure: esta propiedad se utiliza para definir el archivo JavaScript que se activará después de la solicitud Ajax fallida.

OnComplete: esta propiedad se utiliza para definir el archivo JavaScript que se activará después de la solicitud completa de Ajax.

OnBegin: esta propiedad se utiliza para definir el archivo JavaScript que se activará después de completar la solicitud Ajax.

Modo de inserción: esta propiedad se utiliza para especificar cómo se insertará la respuesta en el elemento DOM. Tiene Insertar después, Insertar antes y
Reemplace los modos.         
AllowCache: esta es la propiedad booleana que decide si se permite o no el caché.

LoadingElementId: esta propiedad se utiliza para mostrar el símbolo de carga para solicitudes de larga ejecución.

LoadingElementDuration: esta propiedad se utiliza para definir la duración en miles de segundos para cargar el símbolo.
         */
        /*
         para controladores
         [ValidateAntiForgeryToken] valida el token
         [AllowAnonymous] para todo get
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
