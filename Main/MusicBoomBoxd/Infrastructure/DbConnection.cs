using Microsoft.Data.SqlClient;

namespace Infrastructure
{
    public abstract class DbConnection
    {
        private readonly string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi540927_musicboom;User Id=dbi540927_musicboom;Password=MusicBoom1234;TrustServerCertificate=True;";

        protected SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            return conn;
        }
    }
}

//try to add a paramater in the contstructor 