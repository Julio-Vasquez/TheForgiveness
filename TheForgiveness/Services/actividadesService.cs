using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class actividadesService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateActivities(Models.actividadesModel activi)
        {
            return MySQL.Operations("CALL Insert_Asignatura('" + activi.Actividad + "')");
        }

        public IEnumerable<Models.actividadesModel> listActivities()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Actividad FROM actividades");
            List<Models.actividadesModel> activ = new List<Models.actividadesModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.actividadesModel(int.Parse(item["ID"].ToString()), item["Actividad"].ToString()));
            }
            IEnumerable<Models.actividadesModel> result = activ;
            return result;
        }

        public System.Data.DataRow Activi(int? id)
        {
            if (id!= null)
                return MySQL.Querys("SELECT * FROM actividades WHERE ID = " + id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool UpdateActivi(Models.actividadesModel dpm)
        {
            return MySQL.Operations("UPDATE actividades SET Actividad ='" + dpm.Actividad + "' WHERE ID = " + dpm.ID);
        }
    }
}