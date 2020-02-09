using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class PerceptionService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateSubject(Models.PerceptionModel convicmo, int usuario)
        {
            return MySQL.Operations("CALL Insert_PercepcionPosconflicto('" + convicmo.Descripcion+"',"+ usuario+")");
        }
        //administrador && docente
        public IEnumerable<Models.PerceptionModel> listConcVic(string rol, int user)
        {
            System.Data.DataTable listconcepvict;
            if (rol == "Estudiante")
            {
                listconcepvict = MySQL.Querys("SELECT p.ID AS ID, p.Descripcion AS Descripcion, p.Usuario AS Usuario FROM PercepcionPosconflicto  AS p INNER JOIN Usuario AS u ON u.ID = p.Usuario WHERE p.State = 'Activo' AND  p.Usuario =" + user );
            }
            else 
            {
                listconcepvict = MySQL.Querys("SELECT ID,Descripcion,Fecha,Usuario FROM PercepcionPosconflicto WHERE State = 'Activo'");
            }
            
            List<Models.PerceptionModel> concepvict = new List<Models.PerceptionModel>();
            foreach (System.Data.DataRow item in listconcepvict.Rows)
            {
                concepvict.Add(new Models.PerceptionModel(int.Parse(item["ID"].ToString()), item["Descripcion"].ToString(), int.Parse(item["Usuario"].ToString())));
            }
            IEnumerable<Models.PerceptionModel> result = concepvict;
            return result;
        }

        public System.Data.DataRow ConVict(int ? id)
        {
            var res = MySQL.Querys("SELECT * FROM PercepcionPosconflicto WHERE State = 'Activo' AND ID =" + id).Rows[0];
            return res["ID"].ToString().Length > 0 ? res : MySQL.Querys("SELECT NO DATA").Rows[0];
        }

        public bool UpdateConVict(Models.PerceptionModel dpm)
        {
            return MySQL.Operations("UPDATE PercepcionPosconflicto SET Descripcion ='" + dpm.Descripcion + "'  WHERE ID = " + dpm.ID);
        }

        public bool DeleteConcept(int id) 
        {
            return MySQL.Operations("UPDATE PercepcionPosconflicto SET State = 'Inactivo' WHERE ID = "+id);
        }
    }
}