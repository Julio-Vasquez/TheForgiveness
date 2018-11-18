using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class notasModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nota Del Estudiante")]
        public int Nota { get; set; }

        [Required]
        [DisplayName("Seleccione La Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaNota { get; set; }

        [Required]
        [DisplayName("Concepto De la Nota")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Concepto { get; set; }

        [Required]
        [DisplayName("Estado")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        public int Grupo { get; set; }
        public int Estudiante { get; set; }

        public notasModel()
        {
        }
        public notasModel(int ID, int Nota, DateTime FechaNota, string Concepto, string State, int Grupo, int Estudiante)
        {
            this.ID = ID;
            this.Nota = Nota;
            this.FechaNota = FechaNota;
            this.Concepto = Concepto;
            this.State = State;
            this.Grupo = Grupo;
            this.Estudiante = Estudiante;
        }
        public notasModel(int Nota, DateTime FechaNota, string Concepto, string State, int Grupo, int Estudiante)
        {
            this.Nota = Nota;
            this.FechaNota = FechaNota;
            this.Concepto = Concepto;
            this.State = State;
            this.Grupo = Grupo;
            this.Estudiante = Estudiante;
        }
    }
}