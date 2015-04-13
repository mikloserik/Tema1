using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace WindowsFormsApplication2
{
    class UserDAL
    {
        private String connectionString;
        private MySqlConnection conn;

        public UserDAL()
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
                //reader.Read();
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

        public List<User> getAll()
        {
            User u;
            List<User> l = new List<User>();
            String sql = "SELECT * FROM utilizator";
            MySqlDataReader reader = executeSQL(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString());
                    l.Add(u);
                }
            }
            else
            {
                u = null;
            }
            return l;
        }

        public User get(String user, String pass)
        {
            User u;
            String sql = "SELECT * FROM utilizator WHERE username = " + user  + " and password = " + pass + ";";
            MySqlDataReader reader = executeSQL(sql);
            reader.Read();
            if (reader.HasRows)
            {
                u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString());
            }
            else
            {
                u = null;
            }
            return u;
        }

        public String getRole(String user, String pass)
        {
            String u = null;
            String sql = "SELECT role FROM utilizator WHERE username = '" + user + "' and password = '" + pass + "';";
            MySqlDataReader reader = executeSQL(sql);
            if (reader != null)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    u = reader["role"].ToString();
                }
                else
                {
                    u =  null;
                }
            }
            conn.Close();
            return u;
        }

        public int getId(String user, String pass)
        {
            int u = 0;
            String sql = "SELECT id FROM utilizator WHERE username = '" + user + "' and password = '" + pass + "';";
            MySqlDataReader reader = executeSQL(sql);
            if (reader != null)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    u = int.Parse(reader["id"].ToString());
                }
            }
            conn.Close();
            return u;
        }

        public void add(String user, String pass, String role)
        {
            String sql = "INSERT INTO utilizator (username, password, role) VALUES (" + user + ", " + pass + ", " + role + ");";
            executeSQL(sql);
        }

        public void editRole(User u)
        {

        }
        public void editPass(User u)
        {

        }
        public void editName(User u)
        {

        }

    }
}
