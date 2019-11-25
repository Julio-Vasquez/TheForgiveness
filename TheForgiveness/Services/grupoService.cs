using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class grupoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateGrups(Models.grupoModel grups)
        {
            return MySQL.Operations("CALL Insert_Grupos(" + grups.Codigo + ",'" + grups.Nombre + "'," + grups.AñoEscolar + "," + grups.Docente + "," + grups.Asignatura + "," + grups.Colegio + ")");
        }

        public IEnumerable<Models.grupoModel> listGrups()
        {
            System.Data.DataTable listgrup = MySQL.Querys("SELECT ID,Codigo,Nombre,AñoEscolar,Docente,Asignatura,Colegio FROM Grupo");
            List<Models.grupoModel> grup = new List<Models.grupoModel>();
            foreach (System.Data.DataRow item in listgrup.Rows)
            {
                grup.Add(new Models.grupoModel(int.Parse(item["ID"].ToString()), int.Parse(item["Codigo"].ToString()),item["Nombre"].ToString(),int.Parse(item["AñoEscolar"].ToString()),int.Parse(item["Docente"].ToString()),int.Parse(item["Asignatura"].ToString()),int.Parse(item["Colegio"].ToString())));
            }
            IEnumerable<Models.grupoModel> result = grup;
            return result;
        }

        public System.Data.DataRow Groups(int? id)
        {
            return MySQL.Querys("SELECT * FROM Grupo WHERE ID = " + id).Rows[0];
        }

        public System.Data.DataRow specifygrups(int? id)
        {
            if (id != null)
                return MySQL.Querys("SELECT * FROM theforgiveness.grupo inner join theforgiveness.asignatura on grupo.Asignatura = asignatura.ID inner join theforgiveness.persona on grupo.Docente = persona.ID inner join theforgiveness.colegio on grupo.Colegio = colegio.ID WHERE grupo.ID = " + id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool UpdateGroup(Models.grupoModel dpm)
        {
            return MySQL.Operations("UPDATE Grupo SET Codigo=" + dpm.Codigo + ",Nombre='" + dpm.Nombre + "',AñoEscolar=" + dpm.AñoEscolar + ",Docente=" + dpm.Docente + ",Asignatura=" + dpm.Asignatura + ",Colegio =" + dpm.Colegio + " WHERE ID = " + dpm.ID);
        }
    }
}