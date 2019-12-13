﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class colegioService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool createSchool(Models.colegioModel school)
        {
            return MySQL.Operations("CALL Insert_Colegio('" + school.Nombre + "'," + school.Municipio + ")");
        }

        public System.Data.DataRow queryshools(int? school)
        {
            return MySQL.Querys("SELECT * FROM theforgiveness.colegio where State = 'Activo' AND colegio.ID="+school).Rows[0];
        }

        public System.Data.DataRow queryshoolsView(int? school)
        {
            return MySQL.Querys("select c.ID AS ID, c.Nombre AS Nombre, m.Municipio AS Municipio FROM colegio AS c INNER JOIN municipio AS m ON c.Municipio = m.ID WHERE c.State = 'Activo' AND c.ID=" + school).Rows[0];
        }

        public IEnumerable<Models.colegioViewModel> listSchools()
        { 
            System.Data.DataTable listasig = MySQL.Querys("select c.ID AS ID, c.Nombre AS Nombre, m.Municipio AS Municipio FROM colegio AS c INNER JOIN municipio AS m ON c.Municipio = m.ID WHERE c.State = 'Activo'");
            List<Models.colegioViewModel> asign = new List<Models.colegioViewModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.colegioViewModel(int.Parse(item["ID"].ToString()), item["Nombre"].ToString(), item["Municipio"].ToString()));
            }
            IEnumerable<Models.colegioViewModel> result = asign;
            return result;
        }

        public bool UpdateSchool(Models.colegioModel cm) 
        {
            return MySQL.Operations("UPDATE Colegio SET Nombre = '"+cm.Nombre +"', Municipio = "+cm.Municipio + " WHERE ID ="+cm.ID);
        }

        public bool DeleteSchool(int id) 
        {
            return MySQL.Operations("UPDATE Colegio SET State = 'Inactivo' WHERE ID = " + id);
        }
    }
}