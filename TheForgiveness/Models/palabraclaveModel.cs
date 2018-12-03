using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class palabraclaveModel
    {
        public int ID { get; set; }

        [DisplayName("Palabra Clave:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Palabra { get; set; }
        public int SubCategoria { get; set; }

        public palabraclaveModel(int ID,string Palabra,int SubCategoria)
        {
            this.ID = ID;
            this.Palabra = Palabra;
            this.SubCategoria = SubCategoria;
        }
    }
}