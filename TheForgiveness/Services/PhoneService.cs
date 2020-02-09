using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class PhoneService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreatePhones(Models.PhoneModel telefo)
        {
            return MySQL.Operations("CALL Insert_Telefono(" + telefo.Telefono + "," + telefo.Persona + ")");
        }

        public IEnumerable<Models.PhoneModel> listphones()
        {
            System.Data.DataTable listphon = MySQL.Querys("SELECT ID,Telefono,Persona FROM Telefono");
            List<Models.PhoneModel> phon = new List<Models.PhoneModel>();
            foreach (System.Data.DataRow item in listphon.Rows)
            {
                phon.Add(new Models.PhoneModel(int.Parse(item["ID"].ToString()), int.Parse(item["Telefono"].ToString()), int.Parse(item["Persona"].ToString())));
            }
            IEnumerable<Models.PhoneModel> result = phon;
            return result;
        }

        public System.Data.DataRow phone(int? id)
        {
            return MySQL.Querys("SELECT * FROM Telefono WHERE ID = " + id).Rows[0];
        }

        public bool UpdateActivi(Models.PhoneModel dpm)
        {
            return MySQL.Operations("UPDATE Telefono SET Telefono =" + dpm.Telefono + " WHERE ID = " + dpm.ID);
        }
    }
}