using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class percepcionService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.percepcionPostconfictoModel convicmo, int persona)
        {
            return MySQL.Operations("CALL PercepcionPosconflicto('" + convicmo.Descripcion+"','"+convicmo.Fecha+"',(SELECT Persona FROM usuario WHERE ID = " + persona + "))");
        }

        public IEnumerable<Models.percepcionPostconfictoModel> listConcVic()
        {
            System.Data.DataTable listconcepvict = MySQL.Querys("SELECT ID,Descripcion,Fecha,Usuario FROM PercepcionPosconflicto");
            List<Models.percepcionPostconfictoModel> concepvict = new List<Models.percepcionPostconfictoModel>();
            foreach (System.Data.DataRow item in listconcepvict.Rows)
            {
                concepvict.Add(new Models.percepcionPostconfictoModel(int.Parse(item["ID"].ToString()), item["Fecha"].ToString(), item["Descripcion"].ToString(), int.Parse(item["Usuario"].ToString())));
            }
            IEnumerable<Models.percepcionPostconfictoModel> result = concepvict;
            return result;
        }

        public System.Data.DataRow ConVict(int? persona)
        {
            if (persona != null)
            {
                return MySQL.Querys("SELECT * FROM PercepcionPosconflicto WHERE Usuario = " + persona).Rows[0];
            }
            else {
                return MySQL.Querys("SELECT NO DATA").Rows[0];
            }
        }

        public bool UpdateConVict(Models.percepcionPostconfictoModel dpm)
        {
            return MySQL.Operations("UPDATE PercepcionPosconflicto SET Descripcion ='" + dpm.Descripcion + "',Fecha ='" + dpm.Fecha + "'  WHERE ID = " + dpm.ID);
        }
    }
}