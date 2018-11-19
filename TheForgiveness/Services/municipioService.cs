using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class municipioService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryMunicipio()
        {
            return MySQL.Querys("SELECT ID,Municipio,Departamento FROM Municipio");
        }
    }
}