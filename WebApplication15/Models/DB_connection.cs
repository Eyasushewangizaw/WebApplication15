using Microsoft.Data.Sqlite;




namespace WebApplication15.Models
{
    public class DB_Connection
    {
        public static SqliteConnection GetConnection()
        {
            //Nebil's Path
            //string connectionString = "Data Source= C:\\Users\\17065\\Documents\\SQLLite\\Northwind.db";

            //Ubaid's Path
            //string connectionString = "Data Source= C:\\Users\\Ubaid\\Documents\\483\\Sql Database\\Northwind.db";

            string connectionString = "Data Source= C:\\Users\\15073\\OneDrive\\Desktop\\340\\Northwind.db";



            return new SqliteConnection(connectionString);
        }
    }

}

