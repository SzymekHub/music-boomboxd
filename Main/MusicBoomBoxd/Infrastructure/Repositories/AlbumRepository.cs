using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure
{
    public class AlbumRepository : DbConnection, IAlbumRepository
    {
        // This class is responisble for databse operations related to Albums
        public Result InsertAlbum(AlbumDTO albumDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if (albumDTO.AlbumID != 0)
                {
                    cmd.CommandText = @"SET IDENTITY_INSERT [Album] ON
                                        INSERT INTO [Album] (AlbumID, ArtistID, Title, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                        VALUES (@AlbumID, @ArtistID, @Title, @ReleaseDate, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                        SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [Album] (ArtistID, Title, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                        VALUES (@ArtistID, @Title, @ReleaseDate, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                        SELECT SCOPE_IDENTITY();";
                }

                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = albumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = albumDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

                cmd.Parameters.AddWithValue("@AlbumCoverName", albumDTO.AlbumCoverName);

                //This converts the albumcover to a byte array to pass it to Database
                byte[] albumCoverData = albumDTO.AlbumCoverData.ToArray();
                cmd.Parameters.AddWithValue("@AlbumCoverData", albumCoverData);

                cmd.Parameters.AddWithValue("@AlbumCoverContentType", albumDTO.AlbumCoverContentType);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int newAlbumID;
                    if (int.TryParse(result?.ToString(), out newAlbumID))
                    {
                        albumDTO.AlbumID = newAlbumID;
                        return new Result { Success = true, Message = "Album inserted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to retrieve new album ID." };
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

        public List<AlbumDTO> GetRecentAlbum(int count)
        {
            List<AlbumDTO> recentAlbums = new List<AlbumDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT TOP (@Count) AlbumID, ArtistID, Title, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType 
                                    FROM [Album] WHERE Active = 1 ORDER BY AlbumID DESC";


                cmd.Parameters.AddWithValue("@Count", count);
                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int albumID = reader.GetInt32(0);
                            int artistID = reader.GetInt32(1);
                            string title = reader.GetString(2);
                            DateTime releaseDate = reader.GetDateTime(3);
                            string genre = reader.GetString(4);
                            string albumCoverName = reader.GetString(5);
                            byte[] albumCoverData = (byte[])reader.GetValue(6);
                            string albumCoverContentType = reader.GetString(7);

                            AlbumDTO album = new AlbumDTO(albumID, artistID, title, releaseDate, genre, albumCoverName, albumCoverData, albumCoverContentType);
                            recentAlbums.Add(album);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"SQL Exception: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception: {ex.Message}", ex);
                }
            }

            return recentAlbums;
        }

        public Result UpdateAlbum(AlbumDTO newAlbumDTO, AlbumDTO oldAlbumDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Album] SET ArtistID = @ArtistID, Title = @Title, Date = @ReleaseDate, Genre = @Genre, AlbumCoverName = @AlbumCoverName, AlbumCoverData = @AlbumCoverData, AlbumCoverContentType = @AlbumCoverContentType
                                  WHERE AlbumID = @AlbumID";

                cmd.Parameters.AddWithValue("@ArtistID", newAlbumDTO.ArtistID);

                cmd.Parameters.AddWithValue("@Title", newAlbumDTO.AlbumTitle);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = newAlbumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = newAlbumDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);
                cmd.Parameters.AddWithValue("@AlbumCoverName", newAlbumDTO.AlbumCoverName);

                //This converts the albumcover to a byte array to pass it to Database
                byte[] albumCoverData = newAlbumDTO.AlbumCoverData.ToArray();
                cmd.Parameters.AddWithValue("@AlbumCoverData", albumCoverData);
                cmd.Parameters.AddWithValue("@AlbumCoverContentType", newAlbumDTO.AlbumCoverContentType);
                cmd.Parameters.AddWithValue("@AlbumID", newAlbumDTO.AlbumID);

                //// Parameters for old album to find it in the database
                //cmd.Parameters.AddWithValue("@OldTitle", oldAlbumDTO.AlbumTitle);
                //cmd.Parameters.AddWithValue("@OldReleaseDate", oldAlbumDTO.ReleaseDate);
                //cmd.Parameters.AddWithValue("@OldGenre", oldAlbumDTO.Genre.ToString());
                //cmd.Parameters.AddWithValue("@OldAlbumCoverName", oldAlbumDTO.AlbumCoverName);
                //cmd.Parameters.AddWithValue("@OldAlbumCoverData", oldAlbumDTO.AlbumCoverData.ToArray());
                //cmd.Parameters.AddWithValue("@OldAlbumCoverContentType", oldAlbumDTO.AlbumCoverContentType);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Album updated successfully." };
                    }

                    return new Result { Success = false, Message = "Failed to retrieve album ID." };
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

        public Result DeleteAlbum(AlbumDTO albumDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Album] SET Active = 0 
                                    WHERE AlbumID = @AlbumID";

                cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);
                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Album deleted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to delete album." };
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
