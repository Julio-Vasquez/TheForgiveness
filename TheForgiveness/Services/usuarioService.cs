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

        public bool signup(Models.usuarioModel um, Models.personaModel pm, long tel, string email)
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
                    + "'," + pm.Genero
                    + "," + pm.TipoDocumento
                    + "," + pm.Municipio
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

        public bool ResetPassword(string un) {
            return MySQL.Querys("select ID from usuario where UserName = '" + un + "'").Rows.Count > 0;
        }

        public bool ResetPassWordUser(Models.PasswordModel pm, string un)
        {
            return MySQL.Operations("CALL `CambiarContraseña`('"+pm.RepeatPassWord+"','"+un+"')");
        }

    }
}