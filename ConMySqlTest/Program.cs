using MySqlConnector;
using System;

namespace ConMySqlTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Ausführliche Erstellung eines Connectionstrings
            //string Connectionstring = "server={Platzhalter};user id={Platzhalter};password={Platzhalter};port=3306;database={Platzhalter};SslMode={Platzhalter}"; //SslMode=Preferred
            //string Connectionstring = 
            //    "server=localhost;"+
            //    "user id=root;"+
            //    "password=;"+
            //    "port=3306;"+
            //    "database=test;";

            // Kurzform zur Bildung eines Connectionstrings
            string Connectionstring =
             "SERVER   = localhost;" +
             "DATABASE = test;" +
             "UID      = root;" +
             "PASSWORD = ;";

            MySqlConnection mySqlConnection = new MySqlConnection(Connectionstring);
            mySqlConnection.Open();

            MySqlCommand command = mySqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM person";

            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Lesen der bestehenden Daten ....");
            while (reader.Read())
            {
                for (int column = 0; column < reader.FieldCount; column++)
                {
                    Console.Write(reader[column].ToString().PadRight(12, ' ') + "\t");
                }
                Console.WriteLine();
            }
            reader.Close();

            // Beispiel für das Einfügen eines Datensatzes
            //command.CommandText = "INSERT INTO daten (nachname, vorname,ort,faktor) "
            //                     + " Values('Fischer','Frida','Wettringen',7)";
            //command.ExecuteNonQuery();

            // Beispieldaten anlegen
            Person[] personen = new Person[]
            {new Person("Albrecht","Alfons","Rheine"),
            new Person("Brinker","Bernhard","Rheine"),
            new Person("Cencic","Celine","Neuenkirchen"),
            new Person("Dürer","Dennis","Rheine"),
            new Person("Elbhagen","Erich","Wettringen"),
            new Person("Fischer","Frida","Elte"),
            };

            Console.WriteLine("Datensätze einfügen ....");
            for (int i = 0; i < personen.Length; i++)
            {
                command.CommandText = "INSERT INTO person (Name,Vorname,Ort,Faktor) Values(";command.CommandText += personen[i].DataStr + ")";
                command.ExecuteNonQuery();
                Console.Write(". ");
            }
            Console.WriteLine();

            command.Dispose();
            mySqlConnection.Close();

            // Alternative mit geaenderter Reihenfolge der Erstellung von Command und Connection

            //string myInsertCommand = "INSERT INTO daten (nachname, vorname,ort,faktor) "
            //                     + " Values('Hillmann','Herbert','Elte',7)";

            //MySqlCommand myCommand = new MySqlCommand(myInsertCommand);

            //myCommand.Connection = new MySqlConnection(Connectionstring);
            //myCommand.Connection.Open();
            //myCommand.ExecuteNonQuery();
            //myCommand.Connection.Close();

            Console.ReadKey();
        }
    }
}
