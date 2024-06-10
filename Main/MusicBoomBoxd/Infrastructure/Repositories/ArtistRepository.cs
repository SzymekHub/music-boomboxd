using Infrastructure.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure
{
    public class ArtistRepository : DbConnection, IArtistRepository
    {
        public Result InsertArtist(ArtistDTO artistDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if (artistDTO.ArtistID != 0)
                {
                    cmd.CommandText = @"SET IDENTITY_INSERT [Artist] ON
                                    INSERT INTO [Artist] (ArtistID, Name, AritstPictureName, ArtistPictureData, ArtistPictureContentType) 
                                    VALUES (@ArtistID, @Name, @AritstPictureName, @ArtistPictureData, @ArtistPictureContentType); 
                                    SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@ArtistID", artistDTO.ArtistID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [Artist] (Name, AritstPictureName, ArtistPictureData, ArtistPictureContentType) 
                                    VALUES (@Name, @AritstPictureName, @ArtistPictureData, @ArtistPictureContentType); 
                                    SELECT SCOPE_IDENTITY();";
                }

                cmd.Parameters.AddWithValue("@Name", artistDTO.Name);
                cmd.Parameters.AddWithValue("@AritstPictureName", artistDTO.ArtistPictureName);
                //This converts the albumcover to a byte array to pass it to Database
                byte[] artistPicData = artistDTO.ArtistPictureData.ToArray();
                cmd.Parameters.AddWithValue("@ArtistPictureData", artistPicData);
                cmd.Parameters.AddWithValue("@ArtistPictureContentType", artistDTO.ArtistPictureContentType);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int newArtistID;
                    if (int.TryParse(result?.ToString(), out newArtistID))
                    {
                        artistDTO.ArtistID = newArtistID;
                        return new Result { Success = true, Message = "Artist inserted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to retrieve new Artist ID." };
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

        public List<ArtistDTO> GetAllArtists(int count)
        {
            List<ArtistDTO> recentArtists = new List<ArtistDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP (@Count) ArtistID, Name, AritstPictureName, ArtistPictureData, ArtistPictureContentType " +
                                  "FROM [Artist] WHERE Active = 1 ORDER BY ArtistID DESC";

                cmd.Parameters.AddWithValue("@Count", count);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int artistID = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string AritstPictureName = reader.GetString(2);
                            byte[] ArtistPictureData = (byte[])reader.GetValue(3);
                            string ArtistPictureContentType = reader.GetString(4);

                            ArtistDTO artist = new ArtistDTO(artistID, name, AritstPictureName, ArtistPictureData, ArtistPictureContentType);
                            recentArtists.Add(artist);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            return recentArtists;
        }
        public List<ArtistDTO> GetArtistForUser(int userID)
        {
            List<ArtistDTO> artists = new List<ArtistDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT A.ArtistID, A.Name, A.AritstPictureName, A.ArtistPictureData, A.ArtistPictureContentType 
                            FROM [Artist] A 
                            INNER JOIN [UserArtists] UAR ON A.ArtistID = UAR.ArtistID 
                            WHERE UAR.UserID = @UserID";

                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int artistID = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string aritstPictureName = reader.GetString(2);
                        byte[] artistPictureData = (byte[])reader.GetValue(3);
                        string artistPictureContentType = reader.GetString(4);

                        ArtistDTO artist = new ArtistDTO(artistID, name, aritstPictureName, artistPictureData, artistPictureContentType);
                        artists.Add(artist);
                    }
                }
            }
            return artists;
        }

        public ArtistDTO GetArtistByArtistID(int artistID)
        {
            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ArtistID, Name, AritstPictureName, ArtistPictureData, ArtistPictureContentType FROM [Artist] WHERE ArtistID = @ArtistID AND Active = 1";

                cmd.Parameters.AddWithValue("@ArtistID", artistID);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int ArtistID = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string aritstPictureName = reader.GetString(2);
                        byte[] artistPictureData = (byte[])reader.GetValue(3);
                        string artistPictureContentType = reader.GetString(4);

                        ArtistDTO artist = new ArtistDTO(ArtistID, name, aritstPictureName, artistPictureData, artistPictureContentType);

                        return artist;
                    }
                }
            }
            return null;
        }

        public Result UpdateArtist(ArtistDTO artistDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Artist] SET Name = @Name, AritstPictureName = @AritstPictureName, ArtistPictureData = @ArtistPictureData, ArtistPictureContentType = @ArtistPictureContentType
                                WHERE ArtistID = @ArtistID";


                cmd.Parameters.AddWithValue("@ArtistID", artistDTO.ArtistID);

                cmd.Parameters.AddWithValue("@Name", artistDTO.Name);
                cmd.Parameters.AddWithValue("@AritstPictureName", artistDTO.ArtistPictureName);
                
                //This converts the albumcover to a byte array to pass it to Database
                byte[] artistPicData = artistDTO.ArtistPictureData.ToArray();
                cmd.Parameters.AddWithValue("@ArtistPictureData", artistPicData);
                cmd.Parameters.AddWithValue("@ArtistPictureContentType", artistDTO.ArtistPictureContentType);


                try
                {
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Artist updated successfully." };
                    }

                    return new Result { Success = false, Message = "Failed to retrieve Artist ID." };
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

        public Result DeleteArtist(ArtistDTO artistDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Artist] SET Active = 0 
                                    WHERE ArtistID = @ArtistID AND Name = @Name ";

                cmd.Parameters.AddWithValue("@ArtistID", artistDTO.ArtistID);
                cmd.Parameters.AddWithValue("@Name", artistDTO.Name);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int newAnimalID;
                    if (int.TryParse(result?.ToString(), out newAnimalID))
                    {
                        return new Result { Success = true, Message = "Artist deleted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to retrieve Artist ID." };
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
