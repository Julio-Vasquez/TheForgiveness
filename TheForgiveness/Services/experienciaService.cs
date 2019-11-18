using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class experienciaService
    {

        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateExperiences(Models.experienciaModel experien)
        {
            return MySQL.Operations("CALL Insert_Experiencia('" + experien.FechaExperiencia + "','" + experien.Experiencia + "'," + experien.Persona + "," + experien.Municipio + ")");
        }

        public IEnumerable<Models.experienciaModel> listExperiencess()
        {
            System.Data.DataTable listexp = MySQL.Querys("SELECT ID,FechaExperiencia,Experiencia,Persona,Municipio FROM Experiencia");
            List<Models.experienciaModel> exp = new List<Models.experienciaModel>();
            foreach (System.Data.DataRow item in listexp.Rows)
            {
                exp.Add(new Models.experienciaModel(int.Parse(item["ID"].ToString()),DateTime.Parse(item["FechaExperiencia"].ToString()), item["Experiencia"].ToString(), int.Parse(item["Persona"].ToString()), int.Parse(item["Municipio"].ToString())));
            }
            IEnumerable<Models.experienciaModel> result = exp;
            return result;
        }

        public System.Data.DataRow Exper(int? id)
        {
            return MySQL.Querys("SELECT * FROM Experiencia WHERE ID = " + id).Rows[0];
        }
    }
}