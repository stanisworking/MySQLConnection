using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            Database db = new Database();
            db.Connect("accountdb", "root", "Dm2341");

            int choice = 0;
            do
            {
                Console.WriteLine("1. Select All Records");
                Console.WriteLine("2. Insert A New Record");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option above: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        db.SelectRecord("user", new string[] { "username", "password", "date_created" });
                        break;

                    case 2:
                        Console.WriteLine("Adding New Record");
                        Console.Write("username: ");
                        string username = Console.ReadLine();
                        Console.Write("password: ");
                        string password = Console.ReadLine();

                        db.InsertRecord("user", new string[] { "username", "password" }, new string[] { $"'{username}'", $"'{password}'" });
                        break;
                }

                Console.WriteLine("");

            } while (choice != 0);

            Console.WriteLine("Done.");
            db.Disconnect();
        }
    }
}
