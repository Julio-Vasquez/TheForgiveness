using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class PerceptionModel
    {
        public int ID { get; set; }        

        [DisplayName("Breve Descripción:")]
        [StringLength(2500, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [MinLength(10, ErrorMessage = "Minimo {1}")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }


        public int Usuario { get; set; }

        public PerceptionModel()
        {
        }

        public PerceptionModel( string Descripcion, int Usuario)
        {
            this.Descripcion = Descripcion;
            this.Usuario = Usuario;
        }

        public PerceptionModel(int ID, string Descripcion, int Usuario)
        {
            this.ID = ID;
            this.Descripcion = Descripcion;
            this.Usuario = Usuario;
        }
    }
}