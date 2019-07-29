using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class generoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryGenero()
        {
            return MySQL.Querys("SELECT ID,Genero FROM Genero");
        }

        public void createGenero() { }
    }
}