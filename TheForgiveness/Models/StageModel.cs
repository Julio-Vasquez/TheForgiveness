using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class StageModel
    {
        public int ID { get; set; }

        [DisplayName("Nombre del Escenarios:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [DisplayName("Direccion del Escenario:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Link { get; set; }
        public int SubCategoria { get; set; }

        public StageModel()
        {
        }

        public StageModel(string Nombre, string Link, int SubCategoria)
        {
            this.Nombre = Nombre;
            this.Link = Link;
            this.SubCategoria = SubCategoria;
        }

        public StageModel(int ID,string Nombre, string Link, int SubCategoria)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Link = Link;
            this.SubCategoria = SubCategoria;
        }
    }
}