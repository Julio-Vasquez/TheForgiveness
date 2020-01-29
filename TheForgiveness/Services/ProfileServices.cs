using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class ProfileServices
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public System.Data.DataTable queryDocentes() {
            return MySQL.Querys("SELECT p.ID AS ID,concat(PriNombre,' ',SegNombre,' ',PriApellido,' ',SegApellido) as Docente FROM persona AS p INNER JOIN usuario AS u on u.Persona = p.ID where u.Rol = 2");
        }

        public System.Data.DataRow myData(string un)
        {
            long id = myIDentification(un);
            return MySQL.Querys("SELECT * FROM DatosPersonales WHERE Identificacion ="+id).Rows[0];
        }

        public System.Data.DataRow studenData(string un)
        {
            long id = myID(un);
            try
            {
                return MySQL.Querys("SELECT * FROM datosestudiantes WHERE Docente = " + id).Rows[0];
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public bool updateProfile(Models.PerfilModel modelps, string un)
        {
            int idper = myID(un);
            return MySQL.Operations("UPDATE persona SET NumIdentificacion='"+ modelps.NumIdentificacion+"',PriNombre='"+ modelps.PriNombre+ "',SegNombre='"+ modelps.SegNombre+ "',PriApellido='"+ modelps.PriApellido+ "',SegApellido='"+ modelps.SegApellido+ "',FechaNacimiento='"+ modelps.FechaNacimiento+ "',Genero="+ modelps.Genero+ ",TipoDocumento="+ modelps.TipoDocumento+ ",Municipio="+ modelps.Municipio+ " WHERE ID=" + idper + ";");
        }

        private long myIDentification(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT p.NumIdentificacion as NumID FROM Persona as p INNER JOIN Usuario as u ON u.Persona=p.ID WHERE UserName='"+un+"'").Rows[0];
            return long.Parse(dr["NumID"].ToString());
        }

        private int myID(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT u.Persona as NumID FROM usuario as u WHERE u.UserName='" + un + "'").Rows[0];
            return int.Parse(dr["NumID"].ToString());
        }
    }
}