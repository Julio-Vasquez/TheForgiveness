using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class tipodocumentoModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre Del Tipo De Documento")]
        [StringLength(30, ErrorMessage = "{0} = El número de caracteres de {1} debe ser al menos {2}.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string TipoDocumento { get; set; }

        [Required]
        [DisplayName("Seleccione El Estado")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        public tipodocumentoModel()
        {

        }

        public tipodocumentoModel(int ID, string TipoDocumento, string State)
        {
            this.ID = ID;
            this.TipoDocumento = TipoDocumento;
            this.State = State;
        }

        public tipodocumentoModel(string Genero, string State)
        {
            this.TipoDocumento = TipoDocumento;
            this.State = State;
        }
    }
}