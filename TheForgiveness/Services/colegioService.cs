using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class colegioService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool createSchool( Models.colegioModel school)
        {
            return MySQL.Operations("CALL Insert_Colegio('"+school.Nombre+"',"+school.Municipio+")");
        }
    }
}