﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class departamentoModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre del Departamento")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Departamento { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        // [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        //[Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [Required]
        [DisplayName("Seleccione pais!")]
        public int Pais { get; set; }

        public departamentoModel()
        {

        }
        public departamentoModel(string Departamento, int Pais)
        {
            this.Departamento = Departamento;
            this.Pais = Pais;
        }
        public departamentoModel(int ID, string Departamento, int Pais)
        {
            this.ID = ID;
            this.Departamento = Departamento;
            this.Pais = Pais;
        }
    }
}