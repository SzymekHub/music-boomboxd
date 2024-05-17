using System.Data.SqlClient;
using Infrastructure.DTOs;
using System.Data;


namespace Infrastructure
{
    // This class is responisble for databse operations related to users
    public class UserRepository : DbConnection
    {
        public bool InsertUser(UserDTO userDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Users] (Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType) 
                                    VALUES (@Username, @Password, @Email, @UserType, @Birthday, @FavGenre, @ProfilePictureName, @ProfilePictureData, @ProfilePictureContentType)
                                    SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@Username", userDTO.UserName);

                cmd.Parameters.AddWithValue("@Password", userDTO.Password);

                cmd.Parameters.AddWithValue("@Email", userDTO.Email);

                //This converts the user enum to a string to pass it to the databse
                string userString = userDTO.UserType.ToString();
                cmd.Parameters.AddWithValue("@UserType", userString);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the database
                string BirthdayString = userDTO.Birthday.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@Birthday", BirthdayString);

                //This converts the FavGenre chklist to a string to pass it to the databse
                string favGenreString = userDTO.FavGenre.ToString();
                cmd.Parameters.AddWithValue("@FavGenre", favGenreString);

                cmd.Parameters.AddWithValue("@ProfilePictureName", userDTO.ProfilePictureName);

                //This converts the Profile Picture to a byte array to pass it to Database
                byte[] profilePicData = userDTO.ProfilePictureData.ToArray();
                cmd.Parameters.AddWithValue("@ProfilePictureData", profilePicData);

                cmd.Parameters.AddWithValue("@ProfilePictureContentType", userDTO.ProfilePictureContentType);


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

        public List<UserDTO> GetRecentUsers(int count)
        {
            List<UserDTO> recentUsers = new List<UserDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP (@Count) Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType FROM Users ORDER BY ID DESC";


                cmd.Parameters.AddWithValue("@Count", count);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string userName = reader.GetString(0);
                        string password = reader.GetString(1);
                        string email = reader.GetString(2);
                        string userType = reader.GetString(3);
                        DateTime birthday = reader.GetDateTime(4);
                        string favGenre = reader.GetString(5);
                        string profilePictureName = reader.GetString(6);
                        byte[] profilePictureData = (byte[])reader.GetValue(7);
                        string profilePictureContentType = reader.GetString(8);

                        UserDTO user = new UserDTO(userName, password, email, userType, birthday, favGenre, profilePictureName, profilePictureData, profilePictureContentType);
                        recentUsers.Add(user);
                    }
                }
            }
            return recentUsers;
        }

        public bool UpdateUser(UserDTO newUserDTO, UserDTO oldUserDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Users] SET Username = @Username, Password = @Password, Email = @Email, UserType = @UserType, Birthday = @Birthday, FavGenre = @FavGenre, ProfilePictureName = @ProfilePictureName, ProfilePictureData = @ProfilePictureData, ProfilePictureContentType = @ProfilePictureContentType
                                WHERE Username = @OldUsername AND Password = @OldPassword AND Email = @OldEmail AND UserType = @OldUserType AND Birthday = @OldBirthday AND FavGenre = @OldFavGenre";

                cmd.Parameters.AddWithValue("@Username", newUserDTO.UserName);
                cmd.Parameters.AddWithValue("@Password", newUserDTO.Password);
                cmd.Parameters.AddWithValue("@Email", newUserDTO.Email);

                //This converts the user enum to a string to pass it to the databse
                string userString = newUserDTO.UserType.ToString();
                cmd.Parameters.AddWithValue("@UserType", userString);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string BirthdayString = newUserDTO.Birthday.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@Birthday", BirthdayString);

                //This converts the FavGenre chklist to a string to pass it to the databse
                string favGenreString = newUserDTO.FavGenre.ToString();
                cmd.Parameters.AddWithValue("@FavGenre", favGenreString);

                cmd.Parameters.AddWithValue("@ProfilePictureName", newUserDTO.ProfilePictureName);

                //This converts the Profile Picture to a byte array to pass it to Database
                byte[] profilePicData = newUserDTO.ProfilePictureData.ToArray();
                cmd.Parameters.AddWithValue("@ProfilePictureData", profilePicData);

                cmd.Parameters.AddWithValue("@ProfilePictureContentType", newUserDTO.ProfilePictureContentType);

                // Parameters for old Song to find it in the database
                cmd.Parameters.AddWithValue("@OldUsername", oldUserDTO.UserName);
                cmd.Parameters.AddWithValue("@OldPassword", oldUserDTO.Password);
                cmd.Parameters.AddWithValue("@OldEmail", oldUserDTO.Email);
                cmd.Parameters.AddWithValue("@OldUserType", oldUserDTO.UserType.ToString());
                cmd.Parameters.AddWithValue("@OldBirthday", oldUserDTO.Birthday.ToString());
                cmd.Parameters.AddWithValue("@OldFavGenre", oldUserDTO.FavGenre.ToString());

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

        public bool DeleteUser(string userName, string password, string email, string userType, DateTime birthday, string favGenre)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [Users] WHERE Username = @Username AND Password = @Password AND Email = @Email AND UserType = @UserType AND Birthday = @Birthday AND FavGenre = @FavGenre";

                cmd.Parameters.AddWithValue("@Username", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Email", email);

                //This converts the user enum to a string to pass it to the databse
                string userString = userType.ToString();
                cmd.Parameters.AddWithValue("@UserType", userString);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string BirthdayString = birthday.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@Birthday", BirthdayString);

                //This converts the FavGenre chklist to a string to pass it to the databse
                string favGenreString = favGenre.ToString();
                cmd.Parameters.AddWithValue("@FavGenre", favGenreString);

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