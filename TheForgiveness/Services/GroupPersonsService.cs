using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class GroupPersonsService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateGrupPerson(Models.GroupPersonsModel grupperson)
        {
            return MySQL.Operations("CALL Insert_GrupoPersona(" + grupperson.Grupo + "," + grupperson.Estudiante + ",'" + grupperson.CodigoEstudiante + "')");
        }

        public System.Data.DataTable querygrupopersona(int grupo)
        {
            return MySQL.Querys("SELECT grupopersona.Grupo,grupopersona.Estudiante,concat(PriNombre,' ',SegNombre,' ',PriApellido,' ',SegApellido) as Nombre,NumIdentificacion FROM grupopersona inner join persona on persona.ID = grupopersona.Estudiante where grupopersona.Grupo = " + grupo + "; ");
        }

        public IEnumerable<Models.GroupPersonsModel> listGrupPersons(int group)
        {
            System.Data.DataTable listGrupPerson = MySQL.Querys("SELECT Grupo,Estudiante,CodigoEstudiante FROM GrupoPersona WHERE Grupo="+group);
            List<Models.GroupPersonsModel> GrupPerson = new List<Models.GroupPersonsModel>();
            foreach (System.Data.DataRow item in listGrupPerson.Rows)
            {
                GrupPerson.Add(new Models.GroupPersonsModel(int.Parse(item["Grupo"].ToString()), int.Parse(item["Estudiante"].ToString()), item["CodigoEstudiante"].ToString()));
            }
            IEnumerable<Models.GroupPersonsModel> result = GrupPerson;
            return result;
        }

        public System.Data.DataRow GrupPersons(int? Grupo, int? Estudiante)
        {
            if (Grupo == null)
            {
                return MySQL.Querys("SELECT * FROM GrupoPersona WHERE Estudiante = " + Estudiante).Rows[0];
            }
            else
            {
                if (Estudiante == null)
                {
                    return MySQL.Querys("SELECT * FROM GrupoPersona WHERE Grupo = " + Grupo).Rows[0];
                }
                else
                {
                    return MySQL.Querys("SELECT * FROM GrupoPersona WHERE Estudiante = " + Estudiante + " AND Grupo =" + Grupo).Rows[0];
                }
            }
        }

        public bool UpdateGrupPerson(Models.GroupPersonsModel dpm)
        {
            return MySQL.Operations("UPDATE actividades SET CodigoEstudiante ='" + dpm.CodigoEstudiante + "' WHERE Estudiante = " + dpm.Estudiante  + " AND Grupo =" + dpm.Grupo);
        }
    }
}