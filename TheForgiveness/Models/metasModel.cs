using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class metasModel
    {
        public int ID { get; set; }

        [DisplayName("Meta:")]
        [RegularExpression(@"/^[a-zA-ZáéíóúAÉÍÓÚÑñ\s]*$/", ErrorMessage = "No se Admiten numeros")]
        [MinLength(10, ErrorMessage = "Minimo {2}")]
        [DataType(DataType.Text)]
        public string Meta { get; set; }

        public int Escenario { get; set; }

        public metasModel()
        {

        }

        public metasModel(string Meta,int Escenario)
        {
            this.Meta = Meta;
            this.Escenario = Escenario;
        }

        public metasModel(int ID,string Meta,int Escenario)
        {
            this.ID = ID;
            this.Meta = Meta;
            this.Escenario = Escenario;
        }
    }
}