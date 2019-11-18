using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class subcategoriaService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubCategories(Models.subcategoiaModel activi)
        {
            return MySQL.Operations("CALL Insert_SubCategoria('" + activi.Nombre + "','" + activi.Explicacion + "'," + activi.Victimologia + ")");
        }

        public IEnumerable<Models.subcategoiaModel> listSubCategories()
        {
            System.Data.DataTable listacti = MySQL.Querys("SELECT ID,Nombre,Explicacion,Victimologia FROM Subcategoria");
            List<Models.subcategoiaModel> activ = new List<Models.subcategoiaModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.subcategoiaModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString(), item["Explicacion"].ToString(), int.Parse(item["Victimologia"].ToString())));
            }
            IEnumerable<Models.subcategoiaModel> result = activ;
            return result;
        }

        public System.Data.DataRow SubCate(int? id)
        {
            return MySQL.Querys("SELECT * FROM Subcategoria WHERE ID = " + id).Rows[0];
        }

        public bool UpdateSucCategor(Models.subcategoiaModel dpm)
        {
            return MySQL.Operations("UPDATE Subcategoria SET Nombre ='" + dpm.Nombre + "',Explicacion ='" + dpm.Explicacion + "',Victimologia =" + dpm.Victimologia + " WHERE ID = " + dpm.ID);
        }
    }
}