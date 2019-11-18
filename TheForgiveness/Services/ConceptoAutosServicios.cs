using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class ConceptoAutosServicios
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public bool CreateSubject(Models.asignaturaModel asig)
        {
            return MySQL.Operations("CALL Insert_Asignatura('" + asig.Nombre + "')");
        }

        public IEnumerable<Models.conceptoautoresModel> listConceptAut()
        {
            System.Data.DataTable listasig = MySQL.Querys("select conceptoautores.ID AS ID,conceptoautores.AñoPublicacion AS AnoPublicacion, concepto.Titulo AS Titulo,concepto.Descripcion as Descripcion,conceptoautores.Autor as Autor from conceptoautores inner join concepto on conceptoautores.Concepto = concepto.ID");
            List<Models.conceptoautoresModel> asign = new List<Models.conceptoautoresModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.conceptoautoresModel(int.Parse(item["ID"].ToString()), item["AnoPublicacion"].ToString(), item["Titulo"].ToString(), item["Descripcion"].ToString(), int.Parse(item["Autor"].ToString())));
            }
            IEnumerable<Models.conceptoautoresModel> result = asign;
            return result;
        }
    }
}