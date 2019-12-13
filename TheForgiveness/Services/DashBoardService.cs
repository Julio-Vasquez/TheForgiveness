using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class DashBoardService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public int CantStudent(int rol) 
        {
            var dr = MySQL.Querys("SELECT COUNT(ID) AS cantidad FROM Usuario WHERE Rol = "+ rol).Rows[0];
            return int.Parse(dr["cantidad"].ToString());
        }

        public int CantVitimology() 
        {
            var dr = MySQL.Querys("SELECT COUNT(ID) AS cantidad FROM Victimologia WHERE State = 'Activo'").Rows[0];
            return int.Parse(dr["cantidad"].ToString());
        }
    }
}