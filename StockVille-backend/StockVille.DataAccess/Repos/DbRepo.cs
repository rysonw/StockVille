using System.Data.SqlClient;

namespace MyProject.DataAccess.Repositories
{
    public class DbRepository
    {
        string connectionString = "Server=tcp:stockville-db01.database.windows.net,1433;Initial Catalog=db01;Persist Security Info=False;User ID=stockville;Password=Ryson031100;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        using (SqlConnection connection = new SqlConnection(connectionString))

        public DbRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ConnectToDb()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // Perform database operations here
                connection.Close();
            }
        }
    }
}