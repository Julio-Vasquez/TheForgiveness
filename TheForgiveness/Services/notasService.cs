using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class notasService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateCalifications(Models.notasModel nota)
        {
            return MySQL.Operations("CALL Insert_Notas(" + nota.Nota + ",'" + nota.Concepto + "'," + nota.Grupo + "," + nota.Estudiante + ")");
        }

        public IEnumerable<Models.notasModel> listCalifications()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Nota,FechaNota,Concepto,Grupo,Estudiante FROM Nota");
            List<Models.notasModel> activ = new List<Models.notasModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.notasModel(int.Parse(item["ID"].ToString()), int.Parse(item["Nota"].ToString()), DateTime.Parse(item["FechaNota"].ToString()),item["Concepto"].ToString(), int.Parse(item["Grupo"].ToString()), int.Parse(item["Estudiante"].ToString())));
            }
            IEnumerable<Models.notasModel> result = activ;
            return result;
        }

        public System.Data.DataRow Califications(int? id)
        {
            return MySQL.Querys("SELECT * FROM Nota WHERE ID = " + id).Rows[0];
        }

        public bool UpdateCalifi(Models.notasModel dpm)
        {
            return MySQL.Operations("UPDATE Nota SET Nota ='" + dpm.Nota + "' WHERE ID = " + dpm.ID);
        }
    }
}