using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class subcategoiaModel
    {
        public int ID { get; set; }

        [DisplayName("Nombre del la Sub Categoria:")]
        [StringLength(100, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [DisplayName("Definicion:")]
        [StringLength(22000, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string Explicacion { get; set; }
        public int Victimologia { get; set; }

        public subcategoiaModel()
        {

        }

        public subcategoiaModel(string Nombre, string Explicacion, int Victimologia)
        {
            this.Nombre = Nombre;
            this.Explicacion = Explicacion;
            this.Victimologia = Victimologia;
        }

        public subcategoiaModel(int ID,string Nombre,string Explicacion,int Victimologia)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Explicacion = Explicacion;
            this.Victimologia = Victimologia;
        }
    }
}