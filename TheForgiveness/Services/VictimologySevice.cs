using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class VictimologySevice
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateVictimiologies(Models.VictimologyModel activi)
        {
            return MySQL.Operations("CALL Insert_Victimologia('" + activi.Nombre + "','" + activi.Descripcion + "')");
        }

        public IEnumerable<Models.VictimologyModel> listVictimiologies()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Nombre,Descripcion FROM Victimologia WHERE State = 'Activo'");
            List<Models.VictimologyModel> activ = new List<Models.VictimologyModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.VictimologyModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString(), item["Descripcion"].ToString()));
            }
            IEnumerable<Models.VictimologyModel> result = activ;
            return result;
        }

        public System.Data.DataRow Victimiology(int? id)
        {
            return MySQL.Querys("SELECT * FROM Victimologia WHERE State = 'Activo' AND ID = " + id).Rows[0];
        }

        public bool UpdateVictimiology(Models.VictimologyModel dpm)
        {
            return MySQL.Operations("UPDATE Victimologia SET Nombre ='" + dpm.Nombre + "',Descripcion ='" + dpm.Descripcion + "' WHERE ID = " + dpm.ID);
        }

        public Models.VictimologyModel specify(int? id)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT * FROM Victimologia WHERE State = 'Activo' AND  ID = " + id).Rows[0];
            return dr.ItemArray.Length > 0 ? new Models.VictimologyModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(), dr["Descripcion"].ToString()) : new Models.VictimologyModel();
        }

        public bool DeleteVictimology(int id)
        {
            return MySQL.Operations("UPDATE Victimologia SET State = 'Inactivo' WHERE ID = "+id);
        }
    }
}