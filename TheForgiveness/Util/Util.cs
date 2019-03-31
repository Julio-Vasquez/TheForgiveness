using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Util
{
    public class Util
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public Util()
        {
        }
        
        public bool testcontrol(string session)
        {
            return (session == "Login");
        }

        public System.Data.DataRow repoPassword(string usuario)
        {
           System.Data.DataRow dr = MySQL.Querys("call Recuperar_Contraseña_Usuario('"+usuario+"')").Rows[0];
           return dr;
        }

    }
}