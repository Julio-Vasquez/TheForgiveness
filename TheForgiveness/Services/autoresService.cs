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
            System.Data.DataTable listasig = MySQL.Querys("SELECT ID,PriNombre,SegNombre,PriApellido,SegApellido FROM autores");
            List<Models.autoresModel> asign = new List<Models.autoresModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.autoresModel(int.Parse(item["ID"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString()));
            }
            IEnumerable<Models.autoresModel> result = asign;
            return result;
        }

        public System.Data.DataRow Auth(int? id)
        {
            return MySQL.Querys("SELECT * FROM autores WHERE ID = " + id).Rows[0];
        }

        public bool UpdateAuth(Models.autoresModel dpm)
        {
            return MySQL.Operations("UPDATE autores SET PriNombre ='" + dpm.PriNombre + "',SegNombre ='" + dpm.SegNombre + "',PriApellido ='" + dpm.PriApellido + "',SegApellido ='" + dpm.SegApellido + "' WHERE ID = " + dpm.ID);
        }
    }
}