﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Services
{
    public class menuService
    {
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public menuService()
        {
        }


        public System.Data.DataTable getMenu(string un)
        {
            return MySQL.Querys("SELECT v.Titulo AS 'Titulo_Vista', v.Icon AS 'Icono_Vista', p.Titulo AS 'Titulo_SubVista', p.Icon AS 'Icono_SubVista', p.Url AS 'Url_Carpeta', p.Archivo AS 'Url_Vista' FROM Vista AS v INNER JOIN Permiso AS p ON p.Vista = v.ID AND p.State = 'Activo' AND v.State = 'Activo' LEFT JOIN RolPermiso AS rp ON rp.Permiso = p.ID AND rp.State = 'Activo'  WHERE rp.Rol = " + GetRole(un) + "; ");
        }
    }
}