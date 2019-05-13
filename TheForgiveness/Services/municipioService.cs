using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TheForgiveness.Services
{
    public class municipioService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public System.Data.DataTable queryMunicipio()
        {
            return MySQL.Querys("SELECT ID,Municipio,Departamento FROM Municipio");
        }

        public string[] Municipios()
        {
            System.Data.DataTable dt = MySQL.Querys("SELECT ID,Municipio,Departamento FROM Municipio");
            string[] res = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!((i + 1) == dt.Rows.Count))
                {
                    res[i] = "{id: " + int.Parse(dt.Rows[i]["ID"].ToString()) + ",Municipio:'" + dt.Rows[i]["Municipio"].ToString() + "',Departamento:" + int.Parse(dt.Rows[i]["Departamento"].ToString()) + "},";
                }
                else
                {
                    res[i] = "{id:" + int.Parse(dt.Rows[i]["ID"].ToString()) + ",Municipio:'" + dt.Rows[i]["Municipio"].ToString() + "',Departamento:" + dt.Rows[i]["Departamento"].ToString() + "}";
                }
            }
            return res;
        }

        public IEnumerable<Models.municipioModel> listMunicipality()
        {
            System.Data.DataTable listMunicipality = MySQL.Querys("SELECT ID, Municipio, Departamento FROM Municipio");
            List<Models.municipioModel> municipio = new List<Models.municipioModel>();
            foreach (System.Data.DataRow item in listMunicipality.Rows)
            {
                municipio.Add(new Models.municipioModel(int.Parse(item["ID"].ToString()), item["Municipio"].ToString(), int.Parse(item["Departamento"].ToString())));
            }
            IEnumerable<Models.municipioModel> result = municipio;
            return result;
        }
        public IEnumerable<SelectListItem> Deparmentos()
        {
            System.Data.DataTable listdepartamento = MySQL.Querys("SELECT * FROM Departamento");
            List<SelectListItem> departamento = new List<SelectListItem>();
            foreach (System.Data.DataRow item in listdepartamento.Rows)
            {
                departamento.Add(new SelectListItem { Text = item["Departamento"].ToString(), Value = item["ID"].ToString() });
            }
            IEnumerable<SelectListItem> result = departamento;
            return result;
        }

        public System.Data.DataRow Municipality(int? id)
        {
            if (id != null)
                return MySQL.Querys("SELECT * FROM Municipio WHERE ID = " + id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool CreateMunicipality(Models.municipioModel dpm)
        {
            return MySQL.Operations("CALL Insert_Municipio('" + dpm.Municipio + "'," + dpm.DepartamentoFK + ")");
        }

        public bool UpdateDepartment(Models.municipioModel dpm)
        {
            return MySQL.Operations("UPDATE Municipio SET Municipio ='" + dpm.Municipio + "', Departamento =" + dpm.DepartamentoFK + " WHERE ID = " + dpm.ID);
        }

        public string Departamento(int id)
        {
            System.Data.DataRow dr = MySQL.Querys("SELECT Departamento FROM Departamento WHERE ID =" + id).Rows[0];
            return dr["Departamento"].ToString();
        }


    }
}