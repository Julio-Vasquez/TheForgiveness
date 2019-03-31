using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class progresoModel
    {
        public int SubCategoria { get; set; }
        public int Persona { get; set; }
        public double Progreso { get; set; }

        public progresoModel()
        {   
        }

        public progresoModel(double Progreso)
        {
            this.Progreso = Progreso;
        }

        public progresoModel(int SubCategoria, int Persona,double Progreso)
        {
            this.SubCategoria = SubCategoria;
            this.Persona = Persona;
            this.Progreso = Progreso;
        }
    }
}