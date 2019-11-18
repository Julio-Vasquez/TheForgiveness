using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class metasService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateGoals(Models.metasModel meta)
        {
            return MySQL.Operations("CALL Insert_Metas('" + meta.Meta + "'," + meta.Escenario + ")");
        }

        public IEnumerable<Models.metasModel> listgoals()
        {
            System.Data.DataTable listgoal = MySQL.Querys("SELECT ID,Metas,Escenario FROM Metas");
            List<Models.metasModel> goal = new List<Models.metasModel>();
            foreach (System.Data.DataRow item in listgoal.Rows)
            {
                goal.Add(new Models.metasModel(int.Parse(item["ID"].ToString()),item["Metas"].ToString(),int.Parse(item["Escenario"].ToString())));
            }
            IEnumerable<Models.metasModel> result = goal;
            return result;
        }

        public System.Data.DataRow Goal(int? id)
        {
            return MySQL.Querys("SELECT * FROM Metas WHERE ID = " + id).Rows[0];
        }

        public bool UpdateGoal(Models.metasModel dpm)
        {
            return MySQL.Operations("UPDATE Metas SET Metas ='" + dpm.Meta + "',Escenario =" + dpm.Escenario + " WHERE ID = " + dpm.ID);
        }
    }
}