using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository
    {
        private readonly string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi540927_musicboom;User Id=dbi540927_musicboom;Password=MusicBoom1234;";
        private readonly ILogger<UserRepository> _logger; // Add ILogger

        public UserRepository(string connectionString, ILogger<UserRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger; // Assign logger to the private field
        }

        public void InsertUser(string username, string password, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO [Users] (Username, Password, Email) VALUES (@Username, @Password, @Email)";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Email", email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting user into database: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

    }
}