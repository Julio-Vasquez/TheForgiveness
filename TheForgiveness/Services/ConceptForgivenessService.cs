using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Services
{
    public class ConceptForgivenessService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public bool CreateSubject(Models.SubjectModel asig)
        {
            return MySQL.Operations("CALL Insert_Asignatura('" + asig.Nombre + "')");
        }

        public IEnumerable<Models.ConceptForgivenessModel> listConceptAut()
        {
            System.Data.DataTable listasig = MySQL.Querys("select concepto.ID AS ID,conceptoautores.AñoPublicacion AS AnoPublicacion, concepto.Titulo AS Titulo,concepto.Descripcion as Descripcion,conceptoautores.Autor as Autor from conceptoautores inner join concepto on conceptoautores.Concepto = concepto.ID WHERE concepto.State = 'Activo' AND conceptoautores.STate = 'Activo'");
            List<Models.ConceptForgivenessModel> asign = new List<Models.ConceptForgivenessModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.ConceptForgivenessModel(int.Parse(item["ID"].ToString()), item["AnoPublicacion"].ToString(), item["Titulo"].ToString(), item["Descripcion"].ToString(), int.Parse(item["Autor"].ToString())));
            }
            IEnumerable<Models.ConceptForgivenessModel> result = asign;
            return result;
        }

        public System.Data.DataRow SpecifyData(int? id)
        {
            if (id != null)
                return MySQL.Querys("SELECT c.Titulo as Titulo, c.Descripcion AS Descripcion, ca.`AñoPublicacion` AS Publicacion, CONCAT(a.PriNombre, ' ', a.PriApellido) AS Autor FROM Concepto as c INNER JOIN ConceptoAutores as ca ON ca.concepto = c.ID INNER JOIN Autores as a ON ca.Autor = a.ID WHERE c.State = 'Activo' AND c.ID ="+id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool DeleteConcepto(int id) 
        {
            try
            {
                MySQL.Operations("UPDATE Concepto SET State = 'Inactivo' WHERE ID = " + id);
                MySQL.Operations("UPDATE ConceptoAutores SET State = 'Inactivo' WHERE Concepto = " + id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public System.Data.DataTable Authors()
        {
            return MySQL.Querys("SELECT * FROM Autores WHERE State = 'Activo'");
        }

        public bool UpdateConcept(Models.ConceptForgivenessModel cfm)  
        {
            try
            {
                MySQL.Operations("UPDATE Concepto SET Titulo ='" + cfm.Titulo + "', Descripcion ='" + cfm.Descripcion + "' WHERE ID = " + cfm.ID);
                MySQL.Operations("UPDATE ConceptoAutores SET AñoPublicacion ="+ cfm.AñoPublicacion+ ", Autor = " + cfm.Autor + " WHERE Concepto =" + cfm.ID);
                return true;
            }                   
            catch (Exception)
            {
                return false;
            } 
        }        
    }
}