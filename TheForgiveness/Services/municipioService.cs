using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

   
    }
}