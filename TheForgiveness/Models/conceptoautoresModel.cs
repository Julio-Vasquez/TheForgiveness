using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class conceptoautoresModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha De Publicacion")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public int AñoPublicacion { get; set; }
        public int Concepto { get; set; }
        public int Autor { get; set; }

        public conceptoautoresModel()
        {

        }

        public conceptoautoresModel(int AñoPublicacion, int Concepto, int Autor)
        {
            this.AñoPublicacion = AñoPublicacion;
            this.Concepto = Concepto;
            this.Autor = Autor;
        }

        public conceptoautoresModel(int ID,int AñoPublicacion,int Concepto,int Autor)
        {
            this.ID = ID;
            this.AñoPublicacion = AñoPublicacion;
            this.Concepto = Concepto;
            this.Autor = Autor;
        }
    }
}