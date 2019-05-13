using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Services
{
    public class departamentoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryDepartamento()
        {
            return MySQL.Querys("SELECT ID, Departamento FROM Departamento");
        }

        public IEnumerable<Models.departamentoModel> listDepartment()
        {
            System.Data.DataTable listdepartment = MySQL.Querys("SELECT ID, Departamento, Pais FROM Departamento");
            List<Models.departamentoModel> department = new List<Models.departamentoModel>();
            foreach (System.Data.DataRow item in listdepartment.Rows)
            {
                department.Add(new Models.departamentoModel(int.Parse(item["ID"].ToString()), item["Departamento"].ToString(), int.Parse(item["Pais"].ToString())));
            }
            IEnumerable<Models.departamentoModel> result = department;
            return result;
        }
        public IEnumerable<SelectListItem> Paises()
        {
            System.Data.DataTable listpaises = MySQL.Querys("SELECT * FROM Pais");
            List<SelectListItem> Paises = new List<SelectListItem>();
            foreach (System.Data.DataRow item in listpaises.Rows)
            {
                Paises.Add(new SelectListItem {Text = item["Pais"].ToString(), Value = item["ID"].ToString() });
            }
            IEnumerable<SelectListItem> result = Paises;
            return result;
        }

        public System.Data.DataRow Department(int? id)
        {
            if(id !=null)
                return MySQL.Querys("SELECT * FROM Departamento WHERE ID = "+id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool CreateDepartment(Models.departamentoModel dpm)
        {
            return MySQL.Operations("CALL Insert_Departamento('" + dpm.Departamento + "'," + dpm.PaisFK + ")");
        }

        public bool UpdateDepartment(Models.departamentoModel dpm)
        {
            return MySQL.Operations("UPDATE Departamento SET Departamento ='" + dpm.Departamento + "', Pais =" + dpm.PaisFK+" WHERE ID = "+dpm.ID);
        }

        public string Pais(int id)
        {
           System.Data.DataRow dr =MySQL.Querys("SELECT Pais FROM Pais WHERE ID =" + id).Rows[0];
            return dr["Pais"].ToString();
        }
    }
}