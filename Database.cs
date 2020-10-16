using System;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace MySQLConnection
{
    class Database
    {
        MySqlConnection conn = new MySqlConnection();

        public void Connect(string db, string username, string password)
        {
            Console.WriteLine(String.Format("Connecting to MySQL {0}...",db));
            conn.ConnectionString = $"server=localhost;user={username};database={db};port=3306;password={password}";
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }

        public void SelectRecord(string tableName, string[] attributes)
        {
            try
            {

                string sql = $"SELECT {string.Join(",", attributes)} FROM {tableName}";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows == false)
                {
                    Console.WriteLine("No records found");
                    return;
                }

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " / " + rdr[1] + " / " + rdr[2]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void InsertRecord(string tableName, string[] attributes, string[] values)
        {
            try
            {
                string sql = $"INSERT INTO {tableName} ({string.Join(",", attributes)}) VALUES ({String.Format("{0}", string.Join(",", values))})";

                Console.WriteLine(sql);

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int inserted = cmd.ExecuteNonQuery();

                Console.WriteLine(String.Format("{0} record(s) successfully added", inserted));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
