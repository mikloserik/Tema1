using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
{
    class AnuntDAL
    {
        private String connectionString;
        private MySqlConnection conn;

        public AnuntDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "tema1");
            conn = new MySqlConnection(connectionString);
        }

        public MySqlDataReader executeSQL(String sql){
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //conn.Close();
                return reader;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
        }

        public List<Anunt> getAll()
        {
            Anunt a;
            List<Anunt> l = new List<Anunt>();
            String sql = "SELECT * FROM anunt";
            MySqlDataReader reader = executeSQL(sql);
            reader.Read();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    a = new Anunt(reader["titlu"].ToString(), reader["descriere"].ToString(), reader["type"].ToString(), (float)Double.Parse(reader["pret"].ToString()));
                    l.Add(a);
                }
            }
            else
            {
                a = null;
            }
            return l;
        }

        public Anunt get(String title)
        {
            Anunt a;
            String sql = "SELECT * FROM anunt WHERE titlu = '" + title + "';";
            MySqlDataReader reader = executeSQL(sql);
            if (reader.HasRows)
            {
                a = new Anunt(reader["titlu"].ToString(), reader["descriere"].ToString(), reader["type"].ToString(), (float)Double.Parse(reader["pret"].ToString()));
            }
            else
            {
                a = null;
            }
            return a;
        }

        public void add(String title, String description, String type, float price, int id)
        {
            String sql = "INSERT INTO anunt (titlu, descriere, type, pret, idangajat) VALUES ('" + title + "', '" + description + "', '" + type + "', '" + price + "', '" + id + "');";
            executeSQL(sql);
        }
    }
}
