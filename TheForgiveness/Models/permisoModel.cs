﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class permisoModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Escribir El Titulo De La Pagina")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }

        [Required]
        [DisplayName("Escribir La Url De La Pagina")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Url { get; set; }

        [Required]
        [DisplayName("Seleccione El Estado")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string State { get; set; }
	    public int Vista { get; set; }

        public permisoModel()
        {

        }

        public permisoModel(int ID, string Titulo,string Url,string State,int Vista)
        {
            this.ID = ID;
            this.Titulo = Titulo;
            this.Url = Url;
            this.State = State;
            this.Vista = Vista;
        }

        public permisoModel(string Titulo, string Url, string State, int Vista)
        {
            this.Titulo = Titulo;
            this.Url = Url;
            this.State = State;
            this.Vista = Vista;
        }
    }
}