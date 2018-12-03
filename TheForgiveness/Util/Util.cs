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

        public System.Data.DataTable getMenu(string un)
        {
            return MySQL.Querys("SELECT v.Titulo AS 'Titulo_Vista', v.Icon AS 'Icono_Vista', p.Titulo AS 'Titulo_SubVista', p.Icon AS 'Icono_SubVista', p.Url AS 'Url_Carpeta', p.Archivo AS 'Url_Vista' FROM Vista AS v INNER JOIN Permiso AS p ON p.Vista = v.ID AND p.State = 'Activo' AND v.State = 'Activo' LEFT JOIN RolPermiso AS rp ON rp.Permiso = p.ID AND rp.Rol = "+ GetRole(un) + " AND rp.State = 'Activo'  ; ");
        }
        public int GetRole(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT u.Rol AS Role FROM Usuario AS u WHERE u.UserName = '" + un + "';").Rows[0];
            Console.Write(int.Parse(dr["Role"].ToString()));
            return int.Parse(dr["Role"].ToString());
        }

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