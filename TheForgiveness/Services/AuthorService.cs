﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class AuthorService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool createAuthores(Models.AuthorModel Authors)
        {
            return MySQL.Operations("CALL Insert_Autores('" + Authors.PriNombre + "','" + Authors.SegNombre + "','" + Authors.PriApellido + "','" + Authors.SegApellido + "')");
        }
        public IEnumerable<Models.AuthorModel> listAuthors()
        {
            System.Data.DataTable listasig = MySQL.Querys("SELECT ID, PriNombre, SegNombre, PriApellido, SegApellido FROM autores Where State = 'Activo'");
            List<Models.AuthorModel> asign = new List<Models.AuthorModel>();
            foreach (System.Data.DataRow item in listasig.Rows)
            {
                asign.Add(new Models.AuthorModel(int.Parse(item["ID"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString()));
            }
            IEnumerable<Models.AuthorModel> result = asign;
            return result;
        }

        public System.Data.DataRow Auth(int? id)
        {
            if (id != null)
                return MySQL.Querys("SELECT * FROM autores WHERE ID = " + id + " AND  State = 'Activo'").Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool UpdateAuth(Models.AuthorModel dpm)
        {
            return MySQL.Operations("UPDATE autores SET PriNombre ='" + dpm.PriNombre + "',SegNombre ='" + dpm.SegNombre + "',PriApellido ='" + dpm.PriApellido + "',SegApellido ='" + dpm.SegApellido + "' WHERE ID = " + dpm.ID);
        }

        public bool DeleteAuthor(int? id) 
        {
            return MySQL.Operations("UPDATE autores SET State = 'Inactivo' WHERE ID = "+ id);
        }
    }
}