using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class usuarioService
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public int idcuenta(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT ID FROM Usuario WHERE UserName = '" + un + "'").Rows[0];
            return int.Parse(dr["ID"].ToString());
        }

        public bool login(Models.usuarioModel um)
        {
            return MySQL.Querys("CALL Login('" + um.UserName + "','" + um.PassWord + "')").Rows.Count > 0;
        }

    }
}