using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheForgiveness.Models
{
    public class conceptoVictimaModel
    {

        public int Victimologia { get; set; }

        public string ConceptoInicial { get; set; }

        public string ConceptoFinal { get; set; }


        public conceptoVictimaModel()
        {

        }

        public conceptoVictimaModel(int Victimologia, string ConceptoInicial)
        {
            this.Victimologia = Victimologia;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = "";
        }

        public conceptoVictimaModel(int Victimologia, string ConceptoInicial, string ConceptoFinal)
        {
            this.Victimologia = Victimologia;
            this.ConceptoInicial = ConceptoInicial;
            this.ConceptoFinal = ConceptoFinal;
        }

    }
}