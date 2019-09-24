using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class colegioService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool createSchool(Models.colegioModel school)
        {
            return MySQL.Operations("CALL Insert_Colegio('" + school.Nombre + "'," + school.Municipio + ")");
        }

        public IEnumerable<Models.colegioModel> listSchools()
        { 
            System.Data.DataTable listasig = MySQL.Querys("select ID,Nombre,Municipio from colegio");
            List<Models.colegioModel> asign = new List<Models.colegioModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.colegioModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString(), int.Parse(item["Municipio"].ToString())));
            }
            IEnumerable<Models.colegioModel> result = asign;
            return result;
        }
    }
}