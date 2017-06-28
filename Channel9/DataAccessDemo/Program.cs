using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlDataReader();
            LINQtoObjectsDemo();

            Console.WriteLine("Press ENTER to continue ...");
            Console.ReadLine();
        }

        private static void LINQtoObjectsDemo()
        {
            string[] names = { "Adam", "Michael", "Jeremy", "Bruno", "Jerry", "Bret" };

            var results = from name in names
                          orderby name
                          select name;

            foreach (var name in results)
            {
                Console.WriteLine(name);
            }
        }

        private static void SqlDataReader()
        {
            string connectionString = "Server=tcp:jp70487.database.windows.net,1433;Initial Catalog=PositionsDemo;Persist Security Info=False;User ID=juanpablo;Password=Fr3eDebt$2028;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT TOP 10 PositionID, ReportedAt, Latitude, Longitude FROM dbo.Positions", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2:N9}\t{3:N9}", reader[0], reader[1], reader[2], reader[3]);
                        }
                    }
                }
            }
        }
    }
}
