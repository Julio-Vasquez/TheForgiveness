﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class StudentService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateStudent(Models.StudentModel sm) 
        {
            return MySQL.Operations("CALL Create_Cuenta_Estudiante(" + sm.NumIdentificacion + ",'"+sm.PriNombre+"','"+sm.SegNombre+"','"+sm.PriApellido+"','"+sm.SegApellido+"','"+sm.FechaNacimiento+"',"+sm.Genero+","+sm.Municipio+","+sm.Telefono+",'"+sm.Email+"',"+sm.Grupo+")");
        }

        public bool UpdateStudent(Models.StudentModel sm) 
        {
            return MySQL.Operations("UPDATE persona SET PriNombre='"+sm.PriNombre+"',SegNombre='"+sm.SegNombre+"',PriApellido='"+sm.PriApellido+"',SegApellido='"+sm.SegApellido+"',FechaNacimiento='"+sm.FechaNacimiento+"',Genero="+sm.Genero+",Municipio="+sm.Municipio+" WHERE NumIdentificacion="+sm.NumIdentificacion+"");
        }

        public IEnumerable<Models.StudentModel> listStudent(string rol,int persona)
        {//faltan las querys
            System.Data.DataTable listacti;
            if (rol.Equals("Administrador"))
            {
                listacti = MySQL.Querys("SELECT * from datosgrupopersonas");
            }
            else
            {
                if (rol.Equals("Docente"))
                {
                    listacti = MySQL.Querys("SELECT * FROM datosgrupopersonas inner join grupo on grupo.ID = datosgrupopersonas.Grupo WHERE grupo.Docente = (select usuario.Persona from usuario where usuario.ID=" + persona + ");");
                }
                else
                {
                    listacti = MySQL.Querys("");
                }
            }
            List<Models.StudentModel> activ = new List<Models.StudentModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.StudentModel(int.Parse(item["numeroidentificacion"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString(), item["FechaNacimiento"].ToString(), item["Email"].ToString()));
            }
            IEnumerable<Models.StudentModel> result = activ;
            return result;
        }

        public Models.StudentModel SpecifyStudent(int? id) 
        {
            System.Data.DataRow item = MySQL.Querys("SELECT numeroidentificacion,PriNombre,SegNombre,PriApellido,SegApellido,concat(FechaNacimiento,'') as FechaN ,Email,gen,mun FROM datosgrupopersonas inner join grupo on grupo.ID = datosgrupopersonas.Grupo WHERE numeroidentificacion = " + id + ";").Rows[0];
            return new Models.StudentModel(int.Parse(item["numeroidentificacion"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString(),item["FechaN"].ToString(), item["Email"].ToString(), int.Parse(item["gen"].ToString()), int.Parse(item["mun"].ToString()));
        }

        //id = persona
        public bool DeleteStudent(int id) 
        {
            return MySQL.Operations("CALL Delete_Cuenta(" + id + ")");
        }
    }
}