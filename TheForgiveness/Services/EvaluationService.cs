using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class EvaluationService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateActivities(Models.EvaluationModel evaluat)
        {
            return MySQL.Operations("CALL Insert_Evaluacion('" + evaluat.Calificacion + "',"+evaluat.Actividad+ ",," + evaluat.Grupo + ",," + evaluat.Estudiante + ")");
        }


        public IEnumerable<Models.EvaluationModel> listEvaluacion()
        {
            System.Data.DataTable listeval = MySQL.Querys("SELECT ID,Actividad,Calificacion,FechaEvaluacion,Grupo,Estudiante FROM Evaluacion");
            List<Models.EvaluationModel> eval = new List<Models.EvaluationModel>();
            foreach (System.Data.DataRow item in listeval.Rows)
            {
                eval.Add(new Models.EvaluationModel(int.Parse(item["ID"].ToString()),item["Calificacion"].ToString(), DateTime.Parse(item["FechaEvaluacion"].ToString()), int.Parse(item["Actividad"].ToString()), int.Parse(item["Grupo"].ToString()), int.Parse(item["Estudiante"].ToString())));
            }
            IEnumerable<Models.EvaluationModel> result = eval;
            return result;
        }

        public System.Data.DataRow Evaluacion(int? id)
        {
            return MySQL.Querys("SELECT * FROM Evaluacion WHERE ID = " + id).Rows[0];
        }

        public bool UpdateEvaluacion(Models.EvaluationModel dpm)
        {
            return MySQL.Operations("UPDATE Evaluacion SET Calificacion ='" + dpm.Calificacion + "',FechaEvaluacion ='" + dpm.FechaEvaluacion + "' WHERE ID = " + dpm.ID);
        }
    }
}