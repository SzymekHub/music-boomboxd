using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
namespace Infrastructure
{
    public class DbConnection
    {
        private const string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi540927_musicboom;User Id=dbi540927_musicboom;Password=MusicBoom1234;";
        private readonly ILogger<DbConnection> _logger;

        public DbConnection(ILogger<DbConnection> logger)
        {
            _logger = logger;
        }

        public void OpenConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    _logger.LogInformation("Connection successful!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error connecting to database: {ex.Message}");
            }
        }
    }
}