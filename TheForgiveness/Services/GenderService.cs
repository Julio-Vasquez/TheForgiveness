using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class GenderService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryGenero()
        {
            return MySQL.Querys("SELECT ID,Genero FROM Genero WHERE State = 'Activo'");
        }

        public void createGenero() { }
    }
}