using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class emailService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.emailModel emailmo,int persona)
        {
            return MySQL.Operations("CALL Insert_Email(" + emailmo.Email + ",'" + persona + "')");
        }
    }
}