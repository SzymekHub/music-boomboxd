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
        
        //still haven't figure out how load users form the database

        //public bool AuthenticateUser(string username, string password)
        //{
        //    bool isAuthenticated = false;

        //    try
        //    {
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@Username", username);
        //            command.Parameters.AddWithValue("@Password", password);
        //            int count = (int)command.ExecuteScalar();
        //            isAuthenticated = count > 0;
        //            _logger.LogInformation("Authentication successful!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error authenticating user: {ex.Message}");
        //    }
        //    return isAuthenticated;
        //}
       
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