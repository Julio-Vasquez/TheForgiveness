using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class evaluacionService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateActivities(Models.evaluacionModel evaluat)
        {
            return MySQL.Operations("CALL Insert_Evaluacion('" + evaluat.Calificacion + "',"+evaluat.Actividad+ ",," + evaluat.Grupo + ",," + evaluat.Estudiante + ")");
        }


        public IEnumerable<Models.evaluacionModel> listEvaluacion()
        {
            System.Data.DataTable listeval = MySQL.Querys("SELECT ID,Actividad,Calificacion,FechaEvaluacion,Grupo,Estudiante FROM actividades");
            List<Models.evaluacionModel> eval = new List<Models.evaluacionModel>();
            foreach (System.Data.DataRow item in listeval.Rows)
            {
                eval.Add(new Models.evaluacionModel(int.Parse(item["ID"].ToString()),item["Calificacion"].ToString(), DateTime.Parse(item["FechaEvaluacion"].ToString()), int.Parse(item["Actividad"].ToString()), int.Parse(item["Grupo"].ToString()), int.Parse(item["Estudiante"].ToString())));
            }
            IEnumerable<Models.evaluacionModel> result = eval;
            return result;
        }

        public System.Data.DataRow Activi(int? id)
        {
            return MySQL.Querys("SELECT * FROM Evaluacion WHERE ID = " + id).Rows[0];
        }

        public bool UpdateActivi(Models.evaluacionModel dpm)
        {
            return MySQL.Operations("UPDATE Evaluacion SET Calificacion ='" + dpm.Calificacion + "',FechaEvaluacion ='" + dpm.FechaEvaluacion + "' WHERE ID = " + dpm.ID);
        }
    }
}