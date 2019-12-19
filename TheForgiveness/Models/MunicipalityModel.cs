using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Models
{
    public class MunicipalityModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Nombre Del Municipio")]
        [StringLength(50, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Municipio { get; set; }

        [DisplayName("Departamento")]
        public int DepartamentoFK { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        public IEnumerable<SelectListItem> Departamento { get; set; }
        public MunicipalityModel()
        {
        }

        public MunicipalityModel(int ID,string Municipio,int Departamento)
        {
            this.ID = ID;
            this.Municipio = Municipio;
            this.DepartamentoFK = Departamento;
        }

        public MunicipalityModel(string Municipio, int Departamento)
        {
            this.Municipio = Municipio;
            this.DepartamentoFK = Departamento;
        }
    }
}