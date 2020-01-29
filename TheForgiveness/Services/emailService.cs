using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class EmailService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.EmailModel emailmo,int persona)
        {
            return MySQL.Operations("CALL Insert_Email(" + emailmo.Email + ",'" + persona + "')");
        }

        public IEnumerable<Models.EmailModel> listemails(int persona)
        {
            System.Data.DataTable listemail = MySQL.Querys("SELECT ID,Email FROM email WHERE Persona ="+persona);
            List<Models.EmailModel > email = new List<Models.EmailModel>();
            foreach (System.Data.DataRow item in listemail.Rows)
            {
                email.Add(new Models.EmailModel(int.Parse(item["ID"].ToString()), item["Email"].ToString()));
            }
            IEnumerable<Models.EmailModel> result = email;
            return result;
        }

        public System.Data.DataRow Emails(int? id)
        {
            return MySQL.Querys("SELECT * FROM email WHERE ID = " + id).Rows[0];
        }

        public bool UpdateEmail(Models.EmailModel dpm)
        {
            return MySQL.Operations("UPDATE email SET email ='" + dpm.Email + "' WHERE ID = " + dpm.ID);
        }
    }
}