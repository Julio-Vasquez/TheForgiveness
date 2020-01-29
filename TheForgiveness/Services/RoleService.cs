using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class RoleService
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public RoleService()
        {
        }

        public int GetRole(string un)
        {//id
            System.Data.DataRow dr = MySQL.Querys("SELECT u.Rol AS Role FROM Usuario AS u WHERE u.UserName = '" + un + "';").Rows[0];
            Console.Write(int.Parse(dr["Role"].ToString()));
            return int.Parse(dr["Role"].ToString());
        }

        public string getRole(string un)
        {//NOmbre rol
            System.Data.DataRow dr = MySQL.Querys("SELECT r.Rol AS Role FROM  Rol as r INNER JOIN Usuario as u ON u.Rol = r.ID WHERE u.UserName = '" + un + "';").Rows[0];
            return dr["Role"].ToString();
        }
    }
}