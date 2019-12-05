using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class grupoModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Codigo del Grupo")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nombre del Grupo")]
        [StringLength(45, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Año del Grupo")]
        public int AñoEscolar { get; set; }

        public int Docente { get; set; }

        public int Asignatura { get; set; }

        public int Colegio { get; set; }

        public grupoModel()
        {
        }

        public grupoModel(int Codigo, string Nombre, int AñoEscolar, int Docente, int Asignatura, int Colegio)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.AñoEscolar = AñoEscolar;
            this.Docente = Docente;
            this.Asignatura = Asignatura;
            this.Colegio = Colegio;
        }

        public grupoModel(int ID, int Codigo, string Nombre, int AñoEscolar, int Docente, int Asignatura, int Colegio)
        {
            this.ID = ID;
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.AñoEscolar = AñoEscolar;
            this.Docente = Docente;
            this.Asignatura = Asignatura;
            this.Colegio = Colegio;
        }
    }
}