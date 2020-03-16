using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class DiplomaService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public System.Data.DataRow GetDiploma(int idAccount) {
            return MySQL.Querys("SELECT CONCAT(p.PriNombre,' ', p.PriApellido) AS Nombre, p.NumIdentificacion AS Documento, t.TipoDocumento AS TD FROM Persona AS p INNER JOIN TipoDocumento as t ON p.TipoDocumento = t.ID INNER JOIN Usuario as u ON u.Persona = p.id   WHERE u.ID = " + idAccount).Rows[0];
        }
    }
}