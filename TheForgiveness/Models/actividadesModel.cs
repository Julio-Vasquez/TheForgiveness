using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class actividadesModel
    {
        public int ID { get; set; }
        public string Actividad { get; set; }

        public actividadesModel()
        {
        }

        public actividadesModel(string Actividad)
        {
            this.Actividad = Actividad;
        }

        public actividadesModel(int ID, string Actividad)
        {
            this.ID = ID;
            this.Actividad = Actividad;
        }
    }
}