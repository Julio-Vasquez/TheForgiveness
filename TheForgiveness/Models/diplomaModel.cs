using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class DiplomaModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Tipo de Diploma")]
        [StringLength(55, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string TipoDoploma { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Contenido")]
        [StringLength(55, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Contenido { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha De Expedicion")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public DateTime FechaExpedicion { get; set; }
        public int Plantilla { get; set; }
        public int Estudiante { get; set; }
        public int Grupo { get; set; }

        public DiplomaModel()
        {
        }

        public DiplomaModel(string TipoDoploma,string Contenido,DateTime FechaExpedicion,int Plantilla,int Estudiante,int Grupo)
        {
            this.TipoDoploma = TipoDoploma;
            this.Contenido = Contenido;
            this.FechaExpedicion = FechaExpedicion;
            this.Plantilla = Plantilla;
            this.Estudiante = Estudiante;
            this.Grupo = Grupo;
        }

        public DiplomaModel(int ID, string TipoDoploma, string Contenido, DateTime FechaExpedicion, int Plantilla, int Estudiante, int Grupo)
        {
            this.ID = ID;
            this.TipoDoploma = TipoDoploma;
            this.Contenido = Contenido;
            this.FechaExpedicion = FechaExpedicion;
            this.Plantilla = Plantilla;
            this.Estudiante = Estudiante;
            this.Grupo = Grupo;
        }
    }
}