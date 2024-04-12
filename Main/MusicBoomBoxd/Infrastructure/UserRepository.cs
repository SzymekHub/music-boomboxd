using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTOs;


namespace Infrastructure
{
    public class UserRepository
    {
        private readonly DbConnection _dbConnection;

        public UserRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertUser(UserDTO user)
        {
            try
            {
                _dbConnection.OpenConnection();

                using (SqlConnection connection = _dbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO [User] (Username, Password, Email, Role) VALUES (@Username, @Password, @Email, @Role)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.UserName);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting user into database: {ex.Message}");
            }
        }
    }
}