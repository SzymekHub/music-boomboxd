using Microsoft.Data.SqlClient;
using System.Data;


namespace Infrastructure
{
    // This class is responisble for databse operations related to users
    public class UserRepository : DbConnection, IUserRepository
    {
        public Result InsertUser(UserDTO userDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if (userDTO.UserID != 0)
                {
                    cmd.CommandText = @"SET IDENTITY_INSERT [User] ON
                                    INSERT INTO [User] (UserID, Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType) 
                                    VALUES (@UserID, @Username, @Password, @Email, @UserType, @Birthday, @FavGenre, @ProfilePictureName, @ProfilePictureData, @ProfilePictureContentType)
                                    SELECT SCOPE_IDENTITY()";

                    cmd.Parameters.AddWithValue("@UserID", userDTO.UserID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [User] (Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType) 
                                    VALUES (@Username, @Password, @Email, @UserType, @Birthday, @FavGenre, @ProfilePictureName, @ProfilePictureData, @ProfilePictureContentType)
                                    SELECT SCOPE_IDENTITY()";
                }

                cmd.Parameters.AddWithValue("@Username", userDTO.Username);

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
                    var result = cmd.ExecuteScalar();
                    int newUserID;
                    if (int.TryParse(result?.ToString(), out newUserID))
                    {
                        userDTO.UserID = newUserID;
                        return new Result { Success = true, Message = "User inserted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to retrieve new user ID." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }

            }
        }

        public List<UserDTO> GetRecentUser(int count)
        {
            List<UserDTO> recentUsers = new List<UserDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP (@Count) UserID, Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType " +
                                  "FROM [User] WHERE Active = 1 ORDER BY UserID DESC";


                cmd.Parameters.AddWithValue("@Count", count);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        string userName = reader.GetString(1);
                        string password = reader.GetString(2);
                        string email = reader.GetString(3);
                        string userType = reader.GetString(4);
                        DateTime birthday = reader.GetDateTime(5);
                        string favGenre = reader.GetString(6);
                        string profilePictureName = reader.GetString(7);
                        byte[] profilePictureData = (byte[])reader.GetValue(8);
                        string profilePictureContentType = reader.GetString(9);

                        UserDTO user = new UserDTO(userID, userName, password, email, userType, birthday, favGenre, profilePictureName, profilePictureData, profilePictureContentType);
                        recentUsers.Add(user);
                    }
                }
            }
            return recentUsers;
        }

        //Artist
        #region Artist
        public Result AddArtistToUser(int userID, int artistID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [UserArtists] (UserID, ArtistID) VALUES (@UserID, @ArtistID);";

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@ArtistID", artistID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Artist added to user successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to add artist to user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        public Result RemoveArtistFromUser(int userID, int artistID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [UserArtists] WHERE UserID = @UserID AND ArtistID = @ArtistID;";

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@ArtistID", artistID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Artist removed from user successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to remove Artist from user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }
        #endregion


        //Songs
        #region Songs
        public Result AddSongToUser(int userID, int songID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [UserSongs] (UserID, SongID) VALUES (@UserID, @SongID);";

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@SongID", songID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Song added to user successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to add Song to user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        public Result RemoveSongFromUser(int userID, int songID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [UserSongs] WHERE UserID = @UserID AND SongID = @SongID;";

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@SongID", songID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Song removed from user successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to remove Song from user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }


        #endregion


        //Albums
        #region Albums
        public Result AddAlbumToUser(int userID, int albumID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [UserAlbums] (UserID, AlbumID) VALUES (@UserID, @AlbumID);";

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@AlbumID", albumID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Album added to user successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to add Album to user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        public Result RemoveAlbumFromUser(int userID, int albumID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [UserAlbums] WHERE UserID = @UserID AND AlbumID = @AlbumID;";

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@AlbumID", albumID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Album removed from user successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to remove Album from user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        #endregion

        public UserDTO GetUserByUsername(string username)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT UserID, Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType " +
                                  "FROM [User] WHERE Username = @Username AND Active = 1";


                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        string userName = reader.GetString(1);
                        string password = reader.GetString(2);
                        string email = reader.GetString(3);
                        string userType = reader.GetString(4);
                        DateTime birthday = reader.GetDateTime(5);
                        string favGenre = reader.GetString(6);
                        string profilePictureName = reader.GetString(7);
                        byte[] profilePictureData = (byte[])reader.GetValue(8);
                        string profilePictureContentType = reader.GetString(9);

                        return new UserDTO(userID, userName, password, email, userType, birthday, favGenre, profilePictureName, profilePictureData, profilePictureContentType);
                    }
                }
            }
            return null;
        }
        public UserDTO GetUserByEmail(string email)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT UserID, Username, Password, Email, UserType, Birthday, FavGenre, ProfilePictureName, ProfilePictureData, ProfilePictureContentType " +
                                  "FROM [User] WHERE Email = @Email AND Active = 1";


                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        string userName = reader.GetString(1);
                        string password = reader.GetString(2);
                        string useremail = reader.GetString(3);
                        string userType = reader.GetString(4);
                        DateTime birthday = reader.GetDateTime(5);
                        string favGenre = reader.GetString(6);
                        string profilePictureName = reader.GetString(7);
                        byte[] profilePictureData = (byte[])reader.GetValue(8);
                        string profilePictureContentType = reader.GetString(9);

                        return new UserDTO(userID, userName, password, useremail, userType, birthday, favGenre, profilePictureName, profilePictureData, profilePictureContentType);
                    }
                }
            }
            return null;
        }

        public Result UpdateUser(UserDTO newUserDTO, UserDTO oldUserDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [User] SET Username = @Username, Password = @Password, Email = @Email, UserType = @UserType, Birthday = @Birthday, FavGenre = @FavGenre, ProfilePictureName = @ProfilePictureName, ProfilePictureData = @ProfilePictureData, ProfilePictureContentType = @ProfilePictureContentType
                                WHERE UserID = @UserID";

                cmd.Parameters.AddWithValue("@UserID", newUserDTO.UserID);
                cmd.Parameters.AddWithValue("@Username", newUserDTO.Username);
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

                #region OLD
                //// Parameters for old Song to find it in the database
                //cmd.Parameters.AddWithValue("@OldUsername", oldUserDTO.Username);
                //cmd.Parameters.AddWithValue("@OldPassword", oldUserDTO.Password);
                //cmd.Parameters.AddWithValue("@OldEmail", oldUserDTO.Email);
                //cmd.Parameters.AddWithValue("@OldUserType", oldUserDTO.UserType.ToString());
                //cmd.Parameters.AddWithValue("@OldBirthday", oldUserDTO.Birthday.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //cmd.Parameters.AddWithValue("@OldFavGenre", oldUserDTO.FavGenre.ToString());
                //cmd.Parameters.AddWithValue("@OldProfilePictureName", oldUserDTO.ProfilePictureName);
                //cmd.Parameters.AddWithValue("@OldProfilePictureData", oldUserDTO.ProfilePictureData.ToArray());
                //cmd.Parameters.AddWithValue("@OldProfilePictureContentType", oldUserDTO.ProfilePictureContentType);
                #endregion

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "User updated successfully." };
                    }

                    return new Result { Success = false, Message = "Failed to retrieve user ID." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        public Result UpdateUserRoleToCritic(UserDTO userDTO)
        {
            int Critic = 40;

            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [User] SET UserType = 'Critic'
                            WHERE Username = @Username AND Email = @Email";

                cmd.Parameters.AddWithValue("@Username", userDTO.Username);
                cmd.Parameters.AddWithValue("@Email", userDTO.Email);

                try
                {
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        cmd.CommandText = $"UPDATE Profile SET User_Balance = User_Balance - {Critic} WHERE UserID = (SELECT UserID FROM [User] WHERE Username = @Username)";
                        cmd.ExecuteNonQuery();

                        return new Result { Success = true, Message = " Balance updated successfully." };
                    }

                    return new Result { Success = true, Message = "User role updated to Critic." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        public Result UpdateUserRoleToMusician(UserDTO userDTO)
        {
            int Musician = 10;

            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [User] SET UserType = 'Musician'
                            WHERE Username = @Username AND Email = @Email";

                cmd.Parameters.AddWithValue("@Username", userDTO.Username);
                cmd.Parameters.AddWithValue("@Email", userDTO.Email);

                try
                {
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        cmd.CommandText = $"UPDATE Profile SET User_Balance = User_Balance - {Musician} WHERE UserID = (SELECT UserID FROM [User] WHERE Username = @Username)";
                        cmd.ExecuteNonQuery();

                        return new Result { Success = true, Message = "Balance updated successfully." };
                    }

                    return new Result { Success = true, Message = "User role updated to musician." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

        public Result DeleteUser(UserDTO userDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [User] SET Active = 0 
                                    WHERE UserID = @UserID AND Username = @Username AND Email = @Email ";

                cmd.Parameters.AddWithValue("@UserID", userDTO.UserID);
                cmd.Parameters.AddWithValue("@Username", userDTO.Username);
                cmd.Parameters.AddWithValue("@Email", userDTO.Email);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return new Result { Success = true, Message = "User deleted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to delete user." };
                }
                catch (SqlException ex)
                {
                    return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
                }
                catch (Exception ex)
                {
                    return new Result { Success = false, Message = $"Exception: {ex.Message}" };
                }
            }
        }

    }
}