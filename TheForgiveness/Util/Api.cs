using System;

namespace TheForgiveness.Util
{
    public class Api
    {
        private string url = "";

        public string sendGetRequest(string q)
        {
            try
            {
                string url = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/0a86d67e-ef81-4cd4-8a8d-f4018ca008d4?staging=true&";
                string postData = "verbose=true&timezoneOffset=-360&subscription-key=fa9ee5040fc94e2aae85c89599d3128e&q=";
                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url + postData+q);
                wr.Method = "GET";
                wr.ContentType = "application/x-www-form-urlencoded";
                System.Net.WebResponse response = wr.GetResponse(); // Obtiene la respuesta
                System.IO.Stream sb = response.GetResponseStream(); // Stream con el contenido recibido del servidor
                System.IO.StreamReader reader = new System.IO.StreamReader(sb);
                // Cerramos los streams
                string resp = reader.ReadToEnd();
                Console.Write(resp);
                reader.Close();
                sb.Close();
                response.Close();
                return resp;
            }
            catch (Exception ex)
            {
                return "{'query':null, 'intents': [], 'entities' : [], 'err':'" + ex + "'}";
            }
        }
    }
}