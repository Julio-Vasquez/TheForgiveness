using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class SchoolViewModel
    {
        public int ID { get; set; }

        [DisplayName("Nombre del Colegio:")]
        public string Nombre { get; set; }

        [DisplayName("Municipio")]
        public string Municipio { get; set; }

        public SchoolViewModel()
        {
        }

        public SchoolViewModel(int ID, string Nombre, string Municipio)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Municipio = Municipio;
        }
    }
}