using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure
{
    // This class is responisble for databse operations related to songs
    public class SongRepository : DbConnection, ISongRepository
    {
        public Result InsertSong(SongDTO songDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if (songDTO.SongID != 0)
                {
                    cmd.CommandText = @"SET IDENTITY_INSERT [Song] ON
                                    INSERT INTO [Song] (SongID, Title, Artist, Date, Genre, SongCoverName, SongCoverData, SongCoverContentType) 
                                    VALUES (@SongID, @Title, @Artist, @ReleaseDate, @Genre, @SongCoverName, @SongCoverData, @SongCoverContentType)
                                    SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@SongID", songDTO.SongID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [Song] (Title, Artist, Date, Genre, SongCoverName, SongCoverData, SongCoverContentType) 
                                    VALUES (@Title, @Artist, @ReleaseDate, @Genre, @SongCoverName, @SongCoverData, @SongCoverContentType)
                                    SELECT SCOPE_IDENTITY();";

                }
                cmd.Parameters.AddWithValue("@Title", songDTO.SongTitle);

                cmd.Parameters.AddWithValue("@Artist", songDTO.Artist);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = songDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = songDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

                cmd.Parameters.AddWithValue("@SongCoverName", songDTO.SongCoverName);

                //This converts the songcover to a byte array to pass it to Database
                byte[] songCoverData = songDTO.SongCoverData.ToArray();
                cmd.Parameters.AddWithValue("@SongCoverData", songCoverData);

                cmd.Parameters.AddWithValue("@SongCoverContentType", songDTO.SongCoverContentType);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int newSongID;
                    if (int.TryParse(result?.ToString(), out newSongID))
                    {
                        songDTO.SongID = newSongID;
                        return new Result { Success = true, Message = "Song inserted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to retrieve new song ID." };
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

        public List<SongDTO> GetRecentSong(int count)
        {
            List<SongDTO> recentSongs = new List<SongDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP (@Count) SongID, Title, Artist, Date, Genre, SongCoverName, SongCoverData, SongCoverContentType " +
                                  "FROM [Song] WHERE Active = 1 ORDER BY SongID DESC";


                cmd.Parameters.AddWithValue("@Count", count);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int songID = reader.GetInt32(0);
                        string songtitle = reader.GetString(1);
                        string artist = reader.GetString(2);
                        DateTime releaseDate = reader.GetDateTime(3);
                        string genre = reader.GetString(4);
                        string songCoverName = reader.GetString(5);
                        byte[] songCoverData = (byte[])reader.GetValue(6);
                        string songCoverContentType = reader.GetString(7);

                        SongDTO song = new SongDTO(songID, songtitle, artist, releaseDate, genre, songCoverName, songCoverData, songCoverContentType);
                        recentSongs.Add(song);
                    }
                }
            }
            return recentSongs;
        }

        public Result UpdateSong(SongDTO newSongDTO, SongDTO oldSongDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Song] SET Title = @Title, Artist = @Artist, Date = @ReleaseDate, Genre = @Genre, SongCoverName = @SongCoverName, SongCoverData = @SongCoverData, SongCoverContentType = @SongCoverContentType
                                WHERE Title = @OldTitle AND Artist = @OldArtist AND Date = @OldReleaseDate AND Genre = @OldGenre AND SongCoverName = @OldSongCoverName AND SongCoverData = @OldSongCoverData AND SongCoverContentType = @OldSongCoverContentType";

                cmd.Parameters.AddWithValue("@Title", newSongDTO.SongTitle);
                cmd.Parameters.AddWithValue("@Artist", newSongDTO.Artist);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = newSongDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = newSongDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);
                cmd.Parameters.AddWithValue("@SongCoverName", newSongDTO.SongCoverName);

                //This converts the Songcover to a byte array to pass it to Database
                byte[] SongCoverData = newSongDTO.SongCoverData.ToArray();
                cmd.Parameters.AddWithValue("@SongCoverData", SongCoverData);
                cmd.Parameters.AddWithValue("@SongCoverContentType", newSongDTO.SongCoverContentType);

                // Parameters for old Song to find it in the database
                cmd.Parameters.AddWithValue("@OldTitle", oldSongDTO.SongTitle);
                cmd.Parameters.AddWithValue("@OldArtist", oldSongDTO.Artist);
                cmd.Parameters.AddWithValue("@OldReleaseDate", oldSongDTO.ReleaseDate);
                cmd.Parameters.AddWithValue("@OldGenre", oldSongDTO.Genre.ToString());
                cmd.Parameters.AddWithValue("OldSongCoverName", oldSongDTO.SongCoverName);
                cmd.Parameters.AddWithValue("OldSongCoverData", oldSongDTO.SongCoverData.ToArray());
                cmd.Parameters.AddWithValue("OldSongCoverContentType", oldSongDTO.SongCoverContentType);

                try
                {
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Song updated successfully." };
                    }

                    return new Result { Success = false, Message = "Failed to retrieve song ID." };
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

        public Result DeleteSong(SongDTO songDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Song] SET Active = 0 
                                    WHERE SongID = @SongID AND Title = @Title AND Artist = @Artist AND Date = @ReleaseDate AND Genre = @Genre ";

                cmd.Parameters.AddWithValue("@SongID", songDTO.SongID);
                cmd.Parameters.AddWithValue("@Title", songDTO.SongTitle);
                cmd.Parameters.AddWithValue("@Artist", songDTO.Artist);
                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the database
                string releaseDateString = songDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = songDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);


                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int newSongID;
                    if (int.TryParse(result?.ToString(), out newSongID))
                    {
                        return new Result { Success = true, Message = "Song deleted successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to retrieve song ID." };
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
