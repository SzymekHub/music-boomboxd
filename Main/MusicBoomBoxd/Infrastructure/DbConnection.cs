using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class DbConnection
    {
        private const string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi540927_musicboom;User Id=dbi540927_musicboom;Password=MusicBoom1234;";

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error connecting to database: {ex.Message}");
            }
        }
    }
}