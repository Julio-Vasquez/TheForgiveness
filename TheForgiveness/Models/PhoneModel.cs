﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class PhoneModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [DisplayName("Numero De Telefono")]
        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Solo Numeros")]
        [Range(100000, int.MaxValue, ErrorMessage = "Numero no valido")]
        public int Telefono { get; set; }

        public int Persona { get; set; }

        public PhoneModel()
        {
        }

        public PhoneModel(int ID, int Telefono, int Persona)
        {
            this.ID = ID;
            this.Telefono = Telefono;
            this.Persona = Persona;
        }

        public PhoneModel(int Telefono, int Persona)
        {
            this.Telefono = Telefono;
            this.Persona = Persona;
        }
    }
}