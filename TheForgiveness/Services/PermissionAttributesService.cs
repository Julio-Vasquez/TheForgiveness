using ConnectionDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class PermissionAttributesService
    {
        private ConnectionMySQL MySQL = new ConnectionMySQL();

        public bool Valid_Permission(string Role,string File)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT VerifyUrl('" + Role+"','"+File+"') AS drvalid").Rows[0];
            return Convert.ToBoolean(dr["drvalid"].ToString());
        }

        public bool testcontrol(string session)
        {
            return (session == "Login");
        }
    }
}