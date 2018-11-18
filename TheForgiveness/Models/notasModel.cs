using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class notasModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nota Del Estudiante")]
        public double Nota { get; set; }

//lequite la validacion, porque este dato lo inserta el procedimiento
        [DataType(DataType.Date)]
        public DateTime FechaNota { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Concepto De la Nota")]
        [RegularExpression(@"/[^a-zA-ZáéíóúAÉÍÓÚÑñ0-9\s]+$/", ErrorMessage =" No se admiten caracteres raros")]
        [MinLength(10,ErrorMessage ="Minimo {2} Caracteres")]
        [DataType(DataType.Text)]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Seleccione Grupo")]
        public int Grupo { get; set; }

        [Required(ErrorMessage = "{1} Requerido")]
        [DisplayName("Seleccione Estudiante")]
        public int Estudiante { get; set; }

        public notasModel()
        {

        }

        public notasModel(int ID, int Nota, DateTime FechaNota, string Concepto, int Grupo, int Estudiante)
        {
            this.ID = ID;
            this.Nota = Nota;
            this.FechaNota = FechaNota;
            this.Concepto = Concepto;
            this.Grupo = Grupo;
            this.Estudiante = Estudiante;
        }

        public notasModel(int Nota, string Concepto, string State, int Grupo, int Estudiante)
        {
            this.Nota = Nota;
            this.Concepto = Concepto;
            this.Grupo = Grupo;
            this.Estudiante = Estudiante;
        }
    }
}