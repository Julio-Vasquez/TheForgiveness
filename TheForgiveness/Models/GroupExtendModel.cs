using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class GroupExtendModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Codigo:")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Año Escolar:")]
        public int AñoEscolar { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Docente:")]
        [DataType(DataType.Text)]
        public string Docente { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Asignatura:")]
        [DataType(DataType.Text)]
        public string Asignatura { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Asignatura:")]
        [DataType(DataType.Text)]
        public string Colegio { get; set; }

        public GroupExtendModel(int ID, int Codigo, string Nombre, int AñoEscolar, string Docente, string Asignatura, string Colegio)
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