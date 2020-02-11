using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class grupoService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateGrups(Models.GroupModel grups)
        {
            return MySQL.Operations("CALL Insert_Grupo(" + grups.Codigo + ",'" + grups.Nombre + "'," + grups.AñoEscolar + "," + grups.Docente + "," + grups.Asignatura + "," + grups.Colegio + ")");
        }

        public IEnumerable<gupoextendido> listGrups(int doce)
        {
            System.Data.DataTable listgrup = MySQL.Querys("SELECT * FROM DatosGrupos where Docente2 =(SELECT usuario.Persona FROM usuario where usuario.ID=" + doce+")");
            List<gupoextendido> grup = new List<gupoextendido>();
            foreach (System.Data.DataRow item in listgrup.Rows)
            {
                grup.Add(new gupoextendido(int.Parse(item["ID"].ToString()), int.Parse(item["Codigo"].ToString()),item["Nombre"].ToString(),int.Parse(item["AñoEscolar"].ToString()),item["Docente"].ToString(),item["Asignatura"].ToString(),item["Colegio"].ToString()));
            }
            IEnumerable<gupoextendido> result = grup;
            return result;
        }
        public IEnumerable<gupoextendido> listGrups()
        {
            System.Data.DataTable listgrup = MySQL.Querys("SELECT * FROM DatosGrupos");
            List<gupoextendido> grup = new List<gupoextendido>();
            foreach (System.Data.DataRow item in listgrup.Rows)
            {
                grup.Add(new gupoextendido(int.Parse(item["ID"].ToString()), int.Parse(item["Codigo"].ToString()), item["Nombre"].ToString(), int.Parse(item["AñoEscolar"].ToString()), item["Docente"].ToString(), item["Asignatura"].ToString(), item["Colegio"].ToString()));
            }
            IEnumerable<gupoextendido> result = grup;
            return result;
        }

        public System.Data.DataRow Groups(int? id)
        {
            return MySQL.Querys("SELECT * FROM Grupo WHERE ID = " + id).Rows[0];
        }
        public System.Data.DataTable Groupsdt(int? doce)
        {
            return MySQL.Querys("SELECT * FROM DatosGrupos where Docente2 = (SELECT usuario.Persona FROM usuario where usuario.ID = " + doce+")");
        }

        public System.Data.DataRow specifygrups(int? id)
        {
            if (id != null)
                return MySQL.Querys("SELECT * FROM DatosGrupos WHERE ID = " + id).Rows[0];
            return new System.Data.DataTable().Rows[0];
        }

        public bool UpdateGroup(Models.GroupModel dpm)
        {
            return MySQL.Operations("UPDATE Grupo SET Codigo=" + dpm.Codigo + ",Nombre='" + dpm.Nombre + "',AñoEscolar=" + dpm.AñoEscolar + ",Docente=" + dpm.Docente + ",Asignatura=" + dpm.Asignatura + ",Colegio =" + dpm.Colegio + " WHERE ID = " + dpm.ID);
        }
    }
}

public class gupoextendido
{
    public int ID { get; set; }
    public int Codigo { get; set; }

    public string Nombre { get; set; }

    public int AñoEscolar { get; set; }

    public string Docente { get; set; }

    public string Asignatura { get; set; }

    public string Colegio { get; set; }

    public gupoextendido(int ID, int Codigo, string Nombre, int AñoEscolar, string Docente, string Asignatura, string Colegio)
    {
        this.ID = ID;
        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.AñoEscolar = AñoEscolar;
        this.Docente = Docente;
        this.Asignatura = Asignatura;
        this.Colegio = Colegio;
    }
}
