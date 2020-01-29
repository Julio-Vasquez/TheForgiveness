using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class VictimologyModel
    {
        public int ID { get; set; }

        [DisplayName("Titulo de la Victimiologia:")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [DisplayName("Descripcion de la Victimiologia:")]
        [StringLength(2250, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        public VictimologyModel()
        {
        }

        public VictimologyModel(string Nombre,string Descripcion)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }

        public VictimologyModel(int ID, string Nombre, string Descripcion)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }
    }
}