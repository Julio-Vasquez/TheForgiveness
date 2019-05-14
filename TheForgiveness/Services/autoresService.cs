using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class autoresService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool createAuthores(Models.autoresModel Authors)
        {
            return MySQL.Operations("CALL Insert_Autores('" + Authors.PriNombre + "','" + Authors.SegNombre + "','" + Authors.PriApellido + "','" + Authors.SegApellido + "')");
        }
        public IEnumerable<Models.autoresModel> listAuthors()
        {
            System.Data.DataTable listasig = MySQL.Querys("select ID,PriNombre,SegNombre,PriApellido,SegApellido from autores");
            List<Models.autoresModel> asign = new List<Models.autoresModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.autoresModel(int.Parse(item["ID"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString()));
            }
            IEnumerable<Models.autoresModel> result = asign;
            return result;
        }
    }
}