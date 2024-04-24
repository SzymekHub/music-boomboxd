using System.Data.SqlClient;
using Infrastructure.DTOs;
using System.Data;

namespace Infrastructure
{
    // This class is responisble for databse operations related to songs
    public class SongRepository
    {
        public bool InsertSong(SongDTO songDTO)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Songs] (Title, Artist, Date, Genre, SongCoverName, SongCoverData, SongCoverContentType) 
                                    VALUES (@Title, @Artist, @ReleaseDate, @Genre, @SongCoverName, @SongCoverData, @SongCoverContentType)
                                    SELECT SCOPE_IDENTITY();";

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

        public List<SongDTO> GetRecentSong(int count)
        {
            List<SongDTO> recentSongs = new List<SongDTO>();

            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP (@Count) Title, Artist, Date, Genre, SongCoverName, SongCoverData, SongCoverContentType FROM Songs ORDER BY ID DESC";


                cmd.Parameters.AddWithValue("@Count", count);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString(0);
                        string artist = reader.GetString(1);
                        DateTime releaseDate = reader.GetDateTime(2);
                        string genre = reader.GetString(3);
                        string songCoverName = reader.GetString(4);
                        byte[] songCoverData = (byte[])reader.GetValue(5);
                        string songCoverContentType = reader.GetString(6);

                        SongDTO song = new SongDTO(title, artist, releaseDate, genre, songCoverName, songCoverData, songCoverContentType);
                        recentSongs.Add(song);
                    }
                }
            }
            return recentSongs;
        }

        public bool UpdateSong(SongDTO newSongDTO, SongDTO oldSongDTO)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Songs] SET Title = @Title, Artist = @Artist, Date = @ReleaseDate, Genre = @Genre, SongCoverName = @SongCoverName, SongCoverData = @SongCoverData, SongCoverContentType = @SongCoverContentType
                                WHERE Title = @OldTitle AND Artist = @OldArtist AND Date = @OldReleaseDate AND Genre = @OldGenre";

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

        public bool DeleteSong(string title, string artist, DateTime releaseDate, string genre)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [Songs] WHERE Title = @Title AND Artist = @Artist AND Date = @ReleaseDate AND Genre = @Genre";

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
