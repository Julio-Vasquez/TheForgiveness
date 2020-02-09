using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class ForgivenessService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.ForgivenessModel convicmo, int persona)
        {
            return MySQL.Operations("CALL Insert_ConceptoVictima((SELECT Persona FROM Usuario WHERE ID = " + persona + "),'" + convicmo.ConceptoInicial + "','" + convicmo.ConceptoFinal + "')");
        }

        public IEnumerable<Models.ForgivenessModel> listConcVic()
        {
            System.Data.DataTable listconcepvict = MySQL.Querys("SELECT ID,Persona,ConceptoInicial,ConceptoFinal FROM conceptovictima");
            List<Models.ForgivenessModel> concepvict = new List<Models.ForgivenessModel>();
            foreach (System.Data.DataRow item in listconcepvict.Rows)
            {
                concepvict.Add(new Models.ForgivenessModel(int.Parse(item["ID"].ToString()), int.Parse(item["Persona"].ToString()), item["ConceptoInicial"].ToString(), item["ConceptoFinal"].ToString()));
            }
            IEnumerable<Models.ForgivenessModel> result = concepvict;
            return result;
        }

        public System.Data.DataRow ConVict(int? persona)
        {
            if (persona != null)
            {
                return MySQL.Querys("SELECT * FROM conceptovictima WHERE Persona = " + persona).Rows[0];
            }
            else
            {
                return MySQL.Querys("SELECT NO DATA").Rows[0];
            }
        }

        public bool UpdateConVict(Models.ForgivenessModel dpm)
        {
            return MySQL.Operations("UPDATE conceptovictima SET ConceptoInicial ='" + dpm.ConceptoInicial + "',ConceptoFinal ='" + dpm.ConceptoFinal + "'  WHERE ID = " + dpm.ID );
        }
    }
}