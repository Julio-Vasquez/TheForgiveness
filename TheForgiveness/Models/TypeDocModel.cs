using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class TypeDocModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="{0} Requerido")]
        [DisplayName("Nombre Del Tipo De Documento")]
        [StringLength(100, ErrorMessage = "{0} = El número de caracteres  debe ser al menos {2} y Maximo de {1}", MinimumLength = 6)]
        [DataType(DataType.Text)]
        public string TipoDocumento { get; set; }

        public TypeDocModel()
        {
        }

        public TypeDocModel(int ID, string TipoDocumento)
        {
            this.ID = ID;
            this.TipoDocumento = TipoDocumento;
        }

        public TypeDocModel(string TipoDocumento)
        {
            this.TipoDocumento = TipoDocumento;
        }
    }
}