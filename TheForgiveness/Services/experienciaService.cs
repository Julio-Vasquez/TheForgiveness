using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheForgiveness.Util;

namespace TheForgiveness.Services
{
    public class experienciaService
    {
        private Api api = new Api();
        private ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();

        public bool CreateExperiences(Models.experienciaModel experien)
        {
            float desp = 0;
            float exto = 0;
            float homi = 0;
            float secu = 0;
            float none = 0;
            foreach (var cadenas in experien.Experiencia.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList())
            {

                LUISOutput luisData = JsonConvert.DeserializeObject<LUISOutput>(api.sendGetRequest(cadenas));

                LUISIntent[] intin = luisData.intents;
                for (int i = 0; i < intin.Length - 1; i++)
                {
                    switch (intin[i].Intent)
                    {
                        case "None":
                            none += intin[i].Score;
                            break;
                        case "Desplazar":
                            desp += intin[i].Score;
                            break;
                        case "Extorsionar":
                            exto += intin[i].Score;
                            break;
                        case "homicidios":
                            homi += intin[i].Score;
                            break;
                        case "Secuestrar":
                            secu += intin[i].Score;
                            break;
                        default:
                            break;
                    }

                }
            }


            return MySQL.Operations("CALL Insert_Experiencia('" + experien.FechaExperiencia + "','" + experien.Experiencia + "'," + experien.Persona + "," + experien.Municipio + ")");
        }

        public IEnumerable<Models.experienciaModel> listExperiencess()
        {
            System.Data.DataTable listexp = MySQL.Querys("SELECT ID,FechaExperiencia,Experiencia,Persona,Municipio FROM Experiencia");
            List<Models.experienciaModel> exp = new List<Models.experienciaModel>();
            foreach (System.Data.DataRow item in listexp.Rows)
            {
                exp.Add(new Models.experienciaModel(int.Parse(item["ID"].ToString()), DateTime.Parse(item["FechaExperiencia"].ToString()), item["Experiencia"].ToString(), int.Parse(item["Persona"].ToString()), int.Parse(item["Municipio"].ToString())));
            }
            IEnumerable<Models.experienciaModel> result = exp;
            return result;
        }

        public System.Data.DataRow Exper(int? id)
        {
            return MySQL.Querys("SELECT * FROM Experiencia WHERE ID = " + id).Rows[0];
        }
    }
}



public class LUISOutput
{
    public string query { get; set; }
    public LUISIntent[] intents { get; set; }
    public LUISEntity[] entities { get; set; }
}
public class LUISEntity
{
    public string Entity { get; set; }
    public string Type { get; set; }
    public string StartIndex { get; set; }
    public string EndIndex { get; set; }
    public float Score { get; set; }
}
public class LUISIntent
{
    public string Intent { get; set; }
    public float Score { get; set; }
}