using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class forgivenessServicios
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateConcept(Models.conceptoModel conmo)
        {
            return MySQL.Operations("CALL Insert_Concepto(" + conmo.Titulo + ",'" + conmo.Descripcion + "')");
        }

        public IEnumerable<Models.conceptoModel> listConc()
        {
            System.Data.DataTable listconcept = MySQL.Querys("SELECT Titulo,Descripcion FROM Concepto");
            List<Models.conceptoModel> concep = new List<Models.conceptoModel>();
            foreach (System.Data.DataRow item in listconcept.Rows)
            {
                concep.Add(new Models.conceptoModel(item["Titulo"].ToString(), item["Descripcion"].ToString()));
            }
            IEnumerable<Models.conceptoModel> result = concep;
            return result;
        }

        public System.Data.DataRow Concept(int? ID)
        {
            return MySQL.Querys("SELECT * FROM Concepto WHERE ID = " + ID).Rows[0];
        }

        public bool UpdateConcept(Models.conceptoModel dpm)
        {
            return MySQL.Operations("UPDATE Concepto SET Titulo ='" + dpm.Titulo + "',Descripcion ='" + dpm.Descripcion + "'  WHERE ID = " + dpm.ID);
        }
    }
}