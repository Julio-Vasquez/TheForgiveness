using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class ActivitiesModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nombre De la Actividad")]
        [StringLength(100, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public string Actividad { get; set; }

        public ActivitiesModel()
        {
        }

        public ActivitiesModel(string Actividad)
        {
            this.Actividad = Actividad;
        }

        public ActivitiesModel(int ID, string Actividad)
        {
            this.ID = ID;
            this.Actividad = Actividad;
        }
    }
}