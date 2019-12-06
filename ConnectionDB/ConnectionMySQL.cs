using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    public class ConnectionMySQL
    {
        private MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionMySQL"].ConnectionString);

        private MySql.Data.MySqlClient.MySqlConnection ConexionMySql()
        {
            try
            {
                conexion.Open();
            }
            catch (System.Exception e)
            {
                throw new System.Exception("No se puedo realizar la conexion con la Bases de Datos : " + e.Message);
            }
            return conexion;
        }

        private void desconectar()
        {
            conexion.Close();
        }
        private bool conectar()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
        public bool Operations(string sentence)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand my = new MySql.Data.MySqlClient.MySqlCommand();
                my.CommandText = sentence;
                my.Connection = ConexionMySql();
                if (my.ExecuteNonQuery() > 0)
                {
                    desconectar();
                    return true;
                }
                desconectar();
                return false;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("No se realizó ninguna operación de Registro en la Base de Datos." + e.ToString());
            }
        }

        public System.Data.DataTable Querys(string Query)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
            mySqlCommand.CommandText = Query;
            try
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(Query, ConexionMySql());
                da.Fill(dt);
                desconectar();
                return dt;
            }
            catch
            {
                desconectar();
                throw new System.Exception("Sentencia SQL de consulta invalida.");
            }
        }

        public bool RealizarTransaccion(string[] cadena)
        {
            bool state = false;
            if (conectar())
            {
                MySql.Data.MySqlClient.MySqlTransaction Transa = conexion.BeginTransaction();
                MySql.Data.MySqlClient.MySqlCommand cmd = null;
                try
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i].Length > 0)
                        {
                            cmd = new MySql.Data.MySqlClient.MySqlCommand(cadena[i], conexion);
                            cmd.Transaction = Transa;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Transa.Commit();
                    conexion.Close();
                    conexion.Dispose();
                    Transa.Dispose();
                    desconectar();
                    state = true;
                }
                catch
                {
                    Transa.Rollback();
                    conexion.Close();
                    conexion.Dispose();
                    desconectar();
                    state = false;
                }
                finally
                {
                    // Recolectamos objetos para liberar su memoria.
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return state;
        }
    }
}