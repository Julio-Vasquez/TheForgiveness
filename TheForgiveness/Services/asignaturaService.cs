using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class asignaturaService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.asignaturaModel asig)
        {
            return MySQL.Operations("CALL Insert_Asignatura('"+asig.Nombre+"')");
        }

        public IEnumerable<Models.asignaturaModel> listSubject()
        {
            System.Data.DataTable listasig = MySQL.Querys("SELECT ID, Nombre FROM Asignatura");
            List<Models.asignaturaModel> asign = new List<Models.asignaturaModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.asignaturaModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString()));
            }
            IEnumerable<Models.asignaturaModel> result = asign;
            return result;
        }

        public System.Data.DataRow Subject(int? id)
        {
            return MySQL.Querys("SELECT * FROM Asignatura WHERE ID = " + id).Rows[0];
        }

        public bool UpdateSubject(Models.asignaturaModel dpm)
        {
            return MySQL.Operations("UPDATE Asignatura SET Nombre ='" + dpm.Nombre +"' WHERE ID = " + dpm.ID);
        }
    }
}