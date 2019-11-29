using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class victimiologiaSevice
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateVictimiologies(Models.victimiologiaModel activi)
        {
            return MySQL.Operations("CALL Insert_Victimologia('" + activi.Nombre + "','" + activi.Descripcion + "')");
        }

        public IEnumerable<Models.victimiologiaModel> listVictimiologies()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Nombre,Descripcion FROM Victimologia");
            List<Models.victimiologiaModel> activ = new List<Models.victimiologiaModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.victimiologiaModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString(), item["Descripcion"].ToString()));
            }
            IEnumerable<Models.victimiologiaModel> result = activ;
            return result;
        }

        public System.Data.DataRow Victimiology(int? id)
        {
            return MySQL.Querys("SELECT * FROM Victimologia WHERE ID = " + id).Rows[0];
        }

        public bool UpdateVictimiology(Models.victimiologiaModel dpm)
        {
            return MySQL.Operations("UPDATE Victimologia SET Nombre ='" + dpm.Nombre + "',Descripcion ='" + dpm.Descripcion + "' WHERE ID = " + dpm.ID);
        }

        public Models.victimiologiaModel specify(int? id)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT * FROM Victimologia WHERE ID = " + id).Rows[0];
            return dr.ItemArray.Length > 0 ? new Models.victimiologiaModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(), dr["Descripcion"].ToString()) : new Models.victimiologiaModel();
        }
    }
}