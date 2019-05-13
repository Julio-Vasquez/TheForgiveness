using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class tipoDocumentoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryTipoDocumento()
        {
            return MySQL.Querys("SELECT ID,TipoDocumento FROM TipoDocumento");
        }

        public System.Data.DataRow Documents(int? id)
        {
            if(id != null)
                return MySQL.Querys("SELECT ID,TipoDocumento FROM TipoDocumento WHERE ID = "+id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public IEnumerable<Models.tipodocumentoModel> listDocument()
        {
            System.Data.DataTable listdocument = MySQL.Querys("SELECT ID, TipoDocumento FROM TipoDocumento");
            List<Models.tipodocumentoModel> document = new List<Models.tipodocumentoModel>();
            foreach (System.Data.DataRow item in listdocument.Rows)
            {
                document.Add(new Models.tipodocumentoModel(int.Parse(item["ID"].ToString()), item["TipoDocumento"].ToString()));
            }
            IEnumerable<Models.tipodocumentoModel> result = document;
            return result;
        }

        public bool CreateDocument(Models.tipodocumentoModel tdm)
        {
            return MySQL.Operations("CALL Insert_TipoDocumento('"+tdm.TipoDocumento+"')");
        }

        public bool UpdateDepartment(Models.tipodocumentoModel tdm)
        {
            return MySQL.Operations("UPDATE TipoDocumento SET TipoDocumento ='" + tdm.TipoDocumento + "' WHERE ID = " + tdm.ID);
        }
    }
}