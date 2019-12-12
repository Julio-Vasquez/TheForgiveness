using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class estudianteService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateStudent(Models.studentModel sm) 
        {
            return true;
        }

        public bool UpdateStudent(Models.studentModel sm) 
        {
            return true;
        }

        public IEnumerable<Models.studentModel> listStudent()
        {//faltan las querys
            System.Data.DataTable listacti = MySQL.Querys("");
            List<Models.studentModel> activ = new List<Models.studentModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.studentModel());
            }
            IEnumerable<Models.studentModel> result = activ;
            return result;
        }

        public Models.studentModel SpecifyStudent(int? id) 
        {
            return new Models.studentModel();
        }

        //id = persona
        public bool DeleteStudent(int id) 
        {
            return MySQL.Operations("CALL Delete_Cuenta(" + id + ")");
        }
    }
}