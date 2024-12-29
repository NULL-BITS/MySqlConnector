using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace ConMySqlTest
{
    public class Dbase
    {
        private readonly string connectionstring;
        MySqlConnection connection;
        
        public Dbase(string Server, string Database, string Username, string Password)
        {
            connectionstring = $"Server={Server};DATABASE={Database};UID={Username};PASSWORD={Password}";
            connection = new MySqlConnection(connectionstring);
        }

        
        public DataTable ConnectionRead(string query)
        {
            var Table = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand readsql = new MySqlCommand(query, connection);
                MySqlDataReader reader = readsql.ExecuteReader();
                Table.Load(reader);
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Table;
        }
        public void Insert(string query)
        {
            try
            {
                connection.Open();
                var insert = new MySqlCommand(query, connection);
                insert.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }

    }




}