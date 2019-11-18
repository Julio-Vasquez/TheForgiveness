using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class evaluacionModel
    {
        public int ID { get; set; }

        public string Calificacion { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Fecha de Evaluacion")]
        [StringLength(11, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 11)]
        [DataType(DataType.Date)]
        public DateTime FechaEvaluacion { get; set; }
        public int Actividad { get; set; }
        public int Grupo { get; set; }
        public int Estudiante { get; set; }

        public evaluacionModel() { }
        public evaluacionModel(string Calificacion,DateTime FechaEvaluacion,int Actividad,int Grupo, int Estudiante) {
            this.Calificacion = Calificacion;
            this.FechaEvaluacion = FechaEvaluacion;
            this.Actividad = Actividad;
            this.Grupo = Grupo;
            this.Estudiante = Estudiante;
        }
        public evaluacionModel(int ID,string Calificacion, DateTime FechaEvaluacion, int Actividad, int Grupo, int Estudiante) {
            this.ID = ID;
            this.Calificacion = Calificacion;
            this.FechaEvaluacion = FechaEvaluacion;
            this.Actividad = Actividad;
            this.Grupo = Grupo;
            this.Estudiante = Estudiante;
        }
    }
}