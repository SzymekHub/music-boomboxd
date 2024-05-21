using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure
{
    public class AlbumRepository : DbConnection
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
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SET IDENTITY_INSERT [Album] ON
                                    INSERT INTO [Album] (AlbumID, Title, Artist, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                    VALUES (@AlbumID, @Title, @Artist, @ReleaseDate, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                    SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [Album] (Title, Artist, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                    VALUES (@Title, @Artist, @ReleaseDate, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                    SELECT SCOPE_IDENTITY();";
                }

                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                cmd.Parameters.AddWithValue("@Artist", albumDTO.Artist);

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
                cmd.CommandText = "SELECT TOP (@Count) AlbumID, Title, Artist, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType" +
                                  "FROM [Album] WHERE Active = 1 ORDER BY AlbumID DESC";


                cmd.Parameters.AddWithValue("@Count", count);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int albumID = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string artist = reader.GetString(2);
                        DateTime releaseDate = reader.GetDateTime(3);
                        string genre = reader.GetString(4);
                        string albumCoverName = reader.GetString(5);
                        byte[] albumCoverData = (byte[])reader.GetValue(6);
                        string albumCoverContentType = reader.GetString(7);

                        AlbumDTO album = new AlbumDTO(albumID, title, artist, releaseDate, genre, albumCoverName, albumCoverData, albumCoverContentType);
                        recentAlbums.Add(album);
                    }
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
                cmd.CommandText = @"UPDATE [Album] SET Title = @Title, Artist = @Artist, Date = @ReleaseDate, Genre = @Genre, AlbumCoverName = @AlbumCoverName, AlbumCoverData = @AlbumCoverData, AlbumCoverContentType = @AlbumCoverContentType
                                WHERE Title = @OldTitle AND Artist = @OldArtist AND Date = @OldReleaseDate AND Genre = @OldGenre AND AlbumCoverName = @OldAlbumCoverName AND AlbumCoverData = @OldAlbumCoverData AND AlbumCoverContentType = @OldAlbumCoverContentType ";

                cmd.Parameters.AddWithValue("@Title", newAlbumDTO.AlbumTitle);
                cmd.Parameters.AddWithValue("@Artist", newAlbumDTO.Artist);

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

                // Parameters for old album to find it in the database
                cmd.Parameters.AddWithValue("@OldTitle", oldAlbumDTO.AlbumTitle);
                cmd.Parameters.AddWithValue("@OldArtist", oldAlbumDTO.Artist);
                cmd.Parameters.AddWithValue("@OldReleaseDate", oldAlbumDTO.ReleaseDate);
                cmd.Parameters.AddWithValue("@OldGenre", oldAlbumDTO.Genre.ToString());
                cmd.Parameters.AddWithValue("@OldAlbumCoverName", oldAlbumDTO.AlbumCoverName);
                cmd.Parameters.AddWithValue("@OldAlbumCoverData", oldAlbumDTO.AlbumCoverData.ToArray());
                cmd.Parameters.AddWithValue("@OldAlbumCoverContentType", oldAlbumDTO.AlbumCoverContentType);

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
                                    WHERE AlbumID = @AlbumID AND Title = @Title AND Artist = @Artist AND Date = @ReleaseDate AND Genre = @Genre";

                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Artist", artist);
                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the database
                string releaseDateString = releaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

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
