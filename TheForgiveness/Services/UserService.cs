using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class UserService
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public int idAccount(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT ID FROM Usuario WHERE UserName = '" + un + "'").Rows[0];
            return int.Parse(dr["ID"].ToString());
        }

        public bool login(Models.UsuarioModel um)
        {
            return MySQL.Querys("CALL Login('" + um.Username + "','" + um.PassWord + "')").Rows.Count > 0;
        }

        public bool signup(Models.UsuarioModel um, Models.PeopleModel pm, long tel, string email)
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
                    + ",'" + um.Username 
                    + "','" + um.PassWord 
                    + "'," + tel + ",'" 
                    + email + "',2);");
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ExistUser(string un) {
            return MySQL.Querys("select ID from usuario where UserName = '" + un + "'").Rows.Count > 0;
        }

        public bool ChangePassword(Models.PasswordModel pm, string un)
        {
            return MySQL.Operations("CALL `CambiarContraseña`('"+pm.RepeatPassWord+"','"+un+"')");
        }

        public System.Data.DataRow InfoEMailUser(string un)
        {
            return MySQL.Querys("SELECT Email  FROM Email  WHERE Persona = (Select Persona From Usuario WHERE UserName = '" + un + "' AND State='Activo') AND State='Activo' LIMIT 1").Rows[0];
        }

        public System.Data.DataRow MyUser(string un)
        {
            Console.WriteLine(un);
            return MySQL.Querys("SELECT ID, UserName, PassWord FROM Usuario WHERE UserName ='"+un+"'").Rows[0];
        }

        public bool ValidUser(string id, string un)
        {
            return MySQL.Querys("SELECT ID FROM Persona WHERE NumIdentificacion = '" + id + "' AND ID =(SELECT Persona FROM Usuario WHERE UserName = '" + un + "' AND State='Activo' ) AND State='Activo';").Rows.Count > 0;
        }

    }
}