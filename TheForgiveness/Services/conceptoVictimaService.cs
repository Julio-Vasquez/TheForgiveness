using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class conceptoVictimaService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.conceptoVictimaModel convicmo, int persona)
        {
            return MySQL.Operations("CALL Insert_ConceptoVictima(" + convicmo.Victimologia + ",(SELECT Persona FROM usuario WHERE ID = " + persona + "),'" + convicmo.ConceptoInicial + "','" + convicmo.ConceptoFinal + "')");
        }

        public IEnumerable<Models.conceptoVictimaModel> listConcVic()
        {
            System.Data.DataTable listconcepvict = MySQL.Querys("SELECT Victimologia,Persona,ConceptoInicial,ConceptoFinal FROM conceptovictima");
            List<Models.conceptoVictimaModel> concepvict = new List<Models.conceptoVictimaModel>();
            foreach (System.Data.DataRow item in listconcepvict.Rows)
            {
                concepvict.Add(new Models.conceptoVictimaModel(int.Parse(item["Victimologia"].ToString()), int.Parse(item["Persona"].ToString()), item["ConceptoInicial"].ToString(), item["ConceptoFinal"].ToString()));
            }
            IEnumerable<Models.conceptoVictimaModel> result = concepvict;
            return result;
        }

        public System.Data.DataRow ConVict(int? victimiologia, int? persona)
        {
            if (victimiologia == null)
            {
                return MySQL.Querys("SELECT * FROM conceptovictima WHERE Persona = " + persona).Rows[0];
            }
            else
            {
                if (persona == null)
                {
                    return MySQL.Querys("SELECT * FROM conceptovictima WHERE Victimologia = " + victimiologia).Rows[0];
                }
                else
                {
                    return MySQL.Querys("SELECT * FROM conceptovictima WHERE Victimologia = " + victimiologia + " AND Persona =" + persona).Rows[0];
                }
            }
        }

        public bool UpdateConVict(Models.conceptoVictimaModel dpm)
        {
            return MySQL.Operations("UPDATE conceptovictima SET ConceptoInicial ='" + dpm.ConceptoInicial + "',ConceptoFinal ='" + dpm.ConceptoFinal + "'  WHERE Victimologia = " + dpm.Victimologia+ "AND  Persona="+dpm.Persona);
        }
    }
}