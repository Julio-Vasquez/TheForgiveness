using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class telefonoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreatePhones(Models.telefonoModel telefo)
        {
            return MySQL.Operations("CALL Insert_Telefono(" + telefo.Telefono + "," + telefo.Persona + ")");
        }

        public IEnumerable<Models.telefonoModel> listphones()
        {
            System.Data.DataTable listphon = MySQL.Querys("SELECT ID,Telefono,Persona FROM Telefono");
            List<Models.telefonoModel> phon = new List<Models.telefonoModel>();
            foreach (System.Data.DataRow item in listphon.Rows)
            {
                phon.Add(new Models.telefonoModel(int.Parse(item["ID"].ToString()), int.Parse(item["Telefono"].ToString()), int.Parse(item["Persona"].ToString())));
            }
            IEnumerable<Models.telefonoModel> result = phon;
            return result;
        }

        public System.Data.DataRow phone(int? id)
        {
            return MySQL.Querys("SELECT * FROM Telefono WHERE ID = " + id).Rows[0];
        }

        public bool UpdateActivi(Models.telefonoModel dpm)
        {
            return MySQL.Operations("UPDATE Telefono SET Telefono =" + dpm.Telefono + " WHERE ID = " + dpm.ID);
        }
    }
}