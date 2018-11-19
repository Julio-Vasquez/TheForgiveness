using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Util
{
    public class Util
    {
        public Util()
        {
        }
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public void getMenu() { }

        public string getRole(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT r.Rol AS Role FROM  Rol as r INNER JOIN Usuario as u ON u.Rol = r.ID WHERE u.UserName = '" + un + "';").Rows[0];
            return dr["Role"].ToString();
        }

        public bool testcontrol(string session)
        {
            return (session == "Login");
        }
    }
}