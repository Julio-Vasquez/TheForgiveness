using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class departamentoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryDepartamento()
        {
            return MySQL.Querys("SELECT ID,Departamento FROM Departamento");
        }
    }
}