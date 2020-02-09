using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class TypeDocService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryTipoDocumento()
        {
            return MySQL.Querys("SELECT ID,TipoDocumento FROM TipoDocumento WHERE State = 'Activo'");
        }

        public System.Data.DataRow Documents(int? id)
        {
            if(id != null)
                return MySQL.Querys("SELECT ID,TipoDocumento FROM TipoDocumento WHERE State = 'Activo' and ID = "+id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public IEnumerable<Models.TypeDocModel> listDocument()
        {
            System.Data.DataTable listdocument = MySQL.Querys("SELECT ID, TipoDocumento FROM TipoDocumento WHERE State = 'Activo'");
            List<Models.TypeDocModel> document = new List<Models.TypeDocModel>();
            foreach (System.Data.DataRow item in listdocument.Rows)
            {
                document.Add(new Models.TypeDocModel(int.Parse(item["ID"].ToString()), item["TipoDocumento"].ToString()));
            }
            IEnumerable<Models.TypeDocModel> result = document;
            return result;
        }

        public bool CreateDocument(Models.TypeDocModel tdm)
        {
            return MySQL.Operations("CALL Insert_TipoDocumento('"+tdm.TipoDocumento+"')");
        }

        public bool UpdateDocument(Models.TypeDocModel tdm)
        {
            return MySQL.Operations("UPDATE TipoDocumento SET TipoDocumento ='" + tdm.TipoDocumento + "' WHERE ID = " + tdm.ID);
        }

        public bool DeleteDocument(int id) 
        {
            return MySQL.Operations("UPDATE TipoDocumento SET State = 'Inactivo' WHERE ID = "+id);
        }
    }
}