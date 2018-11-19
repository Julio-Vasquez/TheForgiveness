using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class tipoDocumentoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryTipoDocumento()
        {
            return MySQL.Querys("SELECT ID,TipoDocumento FROM TipoDocumento");
        }
    }
}