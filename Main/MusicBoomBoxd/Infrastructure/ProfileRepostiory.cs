using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProfileRepostiory
    {
        public bool InsertProfile(ProfileDTO profileDTO)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Profile] (UserId, Username, Email, Bio) VALUES (@UserId, @Username, @Email, @Bio)";

                cmd.Parameters.AddWithValue("@UserId", profileDTO.UserId);
                cmd.Parameters.AddWithValue("@Username", profileDTO.Username);
                cmd.Parameters.AddWithValue("@Email", profileDTO.Email);
                cmd.Parameters.AddWithValue("@Bio", profileDTO.Bio);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public ProfileDTO GetProfileByEmail(string email)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 UserId, Username, Email, Bio FROM [Profile] WHERE Email = @Email";

                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string bio = reader.GetString(3);

                        return new ProfileDTO(userId, username, email, bio);
                    }
                }
            }
            return null; // Profile not found
        }

        public bool UpdateProfile(ProfileDTO updatedProfileDTO)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Profile] SET Username = @Username, Email = @Email, Bio = @Bio WHERE UserId = @UserId";

                cmd.Parameters.AddWithValue("@UserId", updatedProfileDTO.UserId);
                cmd.Parameters.AddWithValue("@Username", updatedProfileDTO.Username);
                cmd.Parameters.AddWithValue("@Email", updatedProfileDTO.Email);
                cmd.Parameters.AddWithValue("@Bio", updatedProfileDTO.Bio);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
