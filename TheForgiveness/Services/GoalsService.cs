using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class GoalsService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateGoals(Models.GoalsModel meta)
        {
            return MySQL.Operations("CALL Insert_Metas('" + meta.Meta + "'," + meta.Escenario + ")");
        }

        public IEnumerable<Models.GoalsModel> listgoals()
        {
            System.Data.DataTable listgoal = MySQL.Querys("SELECT ID,Metas,Escenario FROM Metas");
            List<Models.GoalsModel> goal = new List<Models.GoalsModel>();
            foreach (System.Data.DataRow item in listgoal.Rows)
            {
                goal.Add(new Models.GoalsModel(int.Parse(item["ID"].ToString()),item["Metas"].ToString(),int.Parse(item["Escenario"].ToString())));
            }
            IEnumerable<Models.GoalsModel> result = goal;
            return result;
        }

        public System.Data.DataRow Goal(int? id)
        {
            return MySQL.Querys("SELECT * FROM Metas WHERE ID = " + id).Rows[0];
        }

        public bool UpdateGoal(Models.GoalsModel dpm)
        {
            return MySQL.Operations("UPDATE Metas SET Metas ='" + dpm.Meta + "',Escenario =" + dpm.Escenario + " WHERE ID = " + dpm.ID);
        }
    }
}