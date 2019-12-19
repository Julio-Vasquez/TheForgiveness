using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class ScoreService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateCalifications(Models.ScoreModel nota)
        {
            return MySQL.Operations("CALL Insert_Notas(" + nota.Nota + ",'" + nota.Concepto + "'," + nota.Grupo + "," + nota.Estudiante + ")");
        }

        public IEnumerable<Models.ScoreModel> listCalifications()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Nota,FechaNota,Concepto,Grupo,Estudiante FROM Nota");
            List<Models.ScoreModel> activ = new List<Models.ScoreModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.ScoreModel(int.Parse(item["ID"].ToString()), int.Parse(item["Nota"].ToString()), DateTime.Parse(item["FechaNota"].ToString()),item["Concepto"].ToString(), int.Parse(item["Grupo"].ToString()), int.Parse(item["Estudiante"].ToString())));
            }
            IEnumerable<Models.ScoreModel> result = activ;
            return result;
        }

        public System.Data.DataRow Califications(int? id)
        {
            return MySQL.Querys("SELECT * FROM Nota WHERE ID = " + id).Rows[0];
        }

        public bool UpdateCalifi(Models.ScoreModel dpm)
        {
            return MySQL.Operations("UPDATE Nota SET Nota ='" + dpm.Nota + "' WHERE ID = " + dpm.ID);
        }
    }
}