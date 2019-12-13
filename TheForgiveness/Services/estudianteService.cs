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
            return MySQL.Operations("CALL Create_Cuenta_Estudiante(" + sm.NumIdentificacion + ",'"+sm.PriNombre+"','"+sm.SegNombre+"','"+sm.PriApellido+"','"+sm.SegApellido+"','"+sm.FechaNacimiento+"',"+sm.Genero+","+sm.Municipio+","+sm.Telefono+",'"+sm.Email+"',"+sm.Grupo+")");
        }

        public bool UpdateStudent(Models.studentModel sm) 
        {
            return true;
        }

        public IEnumerable<Models.studentModel> listStudent(string rol,int persona)
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
            List<Models.studentModel> activ = new List<Models.studentModel>();
            foreach (System.Data.DataRow item in listacti.Rows)
            {
                activ.Add(new Models.studentModel(int.Parse(item["numeroidentificacion"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString(), item["FechaNacimiento"].ToString(), item["Email"].ToString()));
            }
            IEnumerable<Models.studentModel> result = activ;
            return result;
        }

        public Models.studentModel SpecifyStudent(int? id) 
        {
            System.Data.DataRow item = MySQL.Querys("SELECT * FROM datosgrupopersonas inner join grupo on grupo.ID = datosgrupopersonas.Grupo WHERE numeroidentificacion = " + id + ";").Rows[0];
            return new Models.studentModel(int.Parse(item["numeroidentificacion"].ToString()), item["PriNombre"].ToString(), item["SegNombre"].ToString(), item["PriApellido"].ToString(), item["SegApellido"].ToString(), item["FechaNacimiento"].ToString(), item["Email"].ToString(), int.Parse(item["gen"].ToString()), int.Parse(item["mun"].ToString()));
        }

        //id = persona
        public bool DeleteStudent(int id) 
        {
            return MySQL.Operations("CALL Delete_Cuenta(" + id + ")");
        }
    }
}