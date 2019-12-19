using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class ActivitiesService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateActivities(Models.ActivitiesModel activi)
        {
            return MySQL.Operations("CALL Insert_Asignatura('" + activi.Actividad + "')");
        }

        public IEnumerable<Models.ActivitiesModel> listActivities()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Actividad FROM actividades");
            List<Models.ActivitiesModel> activ = new List<Models.ActivitiesModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.ActivitiesModel(int.Parse(item["ID"].ToString()), item["Actividad"].ToString()));
            }
            IEnumerable<Models.ActivitiesModel> result = activ;
            return result;
        }

        public System.Data.DataRow Activi(int? id)
        {
            if (id!= null)
                return MySQL.Querys("SELECT * FROM actividades WHERE ID = " + id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool UpdateActivi(Models.ActivitiesModel dpm)
        {
            return MySQL.Operations("UPDATE actividades SET Actividad ='" + dpm.Actividad + "' WHERE ID = " + dpm.ID);
        }
    }
}