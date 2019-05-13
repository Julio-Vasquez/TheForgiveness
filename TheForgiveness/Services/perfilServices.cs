using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class perfilServices
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public System.Data.DataRow myData(string un)
        {
            long id = myIDentification(un);
            return MySQL.Querys("SELECT * FROM DatosPersonales WHERE Identificación ="+id).Rows[0];
        }

        private long myIDentification(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT p.NumIdentificacion as NumID FROM Persona as p INNER JOIN Usuario as u ON u.Persona=p.ID WHERE UserName='"+un+"'").Rows[0];
            return long.Parse(dr["NumID"].ToString());
        }
    }
}