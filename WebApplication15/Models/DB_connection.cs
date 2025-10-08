using Microsoft.Data.Sqlite;




namespace WebApplication15.Models
{
    public class DB_Connection
    {
        public static SqliteConnection GetConnection()
        {
         

            string connectionString = "Data Source= C:\\Users\\15073\\OneDrive\\Desktop\\340\\Northwind.db";



            return new SqliteConnection(connectionString);
        }
    }

}

