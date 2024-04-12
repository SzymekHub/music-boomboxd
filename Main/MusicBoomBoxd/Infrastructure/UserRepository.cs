using System.Data.SqlClient;
using Infrastructure.DTOs;
using System.Data;


namespace Infrastructure
{
    public class UserRepository
    {
       public bool InsertUser(UserDTO userDTO)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand()) 
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Users] (Username, Password, Email) VALUES (@Username, @Password, @Email)";

                cmd.Parameters.AddWithValue("@Username", userDTO.UserName);
                cmd.Parameters.AddWithValue("@Password", userDTO.Password);
                cmd.Parameters.AddWithValue("@Email", userDTO.Email);
                
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

    }
}