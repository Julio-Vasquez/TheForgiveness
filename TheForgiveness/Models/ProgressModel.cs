using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class ProgressModel
    {
        public int SubCategoria { get; set; }
        public int Persona { get; set; }
        public double Progreso { get; set; }

        public ProgressModel()
        {   
        }

        public ProgressModel(double Progreso)
        {
            this.Progreso = Progreso;
        }

        public ProgressModel(int SubCategoria, int Persona,double Progreso)
        {
            this.SubCategoria = SubCategoria;
            this.Persona = Persona;
            this.Progreso = Progreso;
        }
    }
}