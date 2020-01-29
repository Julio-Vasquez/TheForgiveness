using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class SubjectService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.SubjectModel asig)
        {
            return MySQL.Operations("CALL Insert_Asignatura('" + asig.Nombre + "')");
        }

        public IEnumerable<Models.SubjectModel> listSubject()
        {
            System.Data.DataTable listasig = MySQL.Querys("SELECT ID, Nombre FROM Asignatura WHERE State = 'Activo'");
            List<Models.SubjectModel> asign = new List<Models.SubjectModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.SubjectModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString()));
            }
            IEnumerable<Models.SubjectModel> result = asign;
            return result;
        }

        public System.Data.DataRow Subject(int? id)
        {
            return MySQL.Querys("SELECT * FROM Asignatura WHERE State = 'Activo' AND ID = " + id).Rows[0];
        }

        public bool UpdateSubject(Models.SubjectModel dpm)
        {
            return MySQL.Operations("UPDATE Asignatura SET Nombre ='" + dpm.Nombre + "' WHERE ID = " + dpm.ID);
        }

        public bool DeleteSubject(int id) 
        {
            return MySQL.Operations("UPDATE Asignatura SET State = 'Inactivo' WHERE ID = "+id);
        }
    }
}