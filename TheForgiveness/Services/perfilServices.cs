using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class perfilServices
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public System.Data.DataRow myData(string un)
        {
            long id = myIDentification(un);
            return MySQL.Querys("SELECT * FROM DatosPersonales WHERE Identificacion ="+id).Rows[0];
        }

        public bool updateprofile(Models.PerfilModel modelps){
            return MySQL.Operations("UPDATE persona SET NumIdentificacion='"+ modelps.NumIdentificacion+"',PriNombre='"+ modelps.PriNombre+ "',SegNombre='"+ modelps.SegNombre+ "',PriApellido='"+ modelps.PriApellido+ "',SegApellido='"+ modelps.SegApellido+ "',FechaNacimiento='"+ modelps.FechaNacimiento+ "',Genero="+ modelps.Genero+ ",TipoDocumento="+ modelps.TipoDocumento+ ",Municipio="+ modelps.Municipio+ " WHERE ID="+ modelps.ID+ ";");
        }

        private long myIDentification(string un)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT p.NumIdentificacion as NumID FROM Persona as p INNER JOIN Usuario as u ON u.Persona=p.ID WHERE UserName='"+un+"'").Rows[0];
            return long.Parse(dr["NumID"].ToString());
        }
    }
}