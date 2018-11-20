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

        public bool signup(Models.usuarioModel um, Models.personaModel pm, int td, int gender, int tel, string email, int municipio)
        {
            try
            {
                return MySQL.Operations(
                    "CALL Create_Cuenta("
                    + pm.NumIdentificacion
                    + ",'" + pm.PriNombre
                    + "','" + pm.SegNombre
                    + "','" + pm.PriApellido
                    + "','" + pm.SegApellido
                    + "','" + pm.FechaNacimiento
                    + "'," + gender
                    + "," + td
                    + "," + municipio
                    + ",'" + um.UserName 
                    + "','" + um.PassWord 
                    + "'," + tel + ",'" 
                    + email + "',3);");
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}