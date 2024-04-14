using System.Data.SqlClient;
using Infrastructure.DTOs;
using System.Data;

namespace Infrastructure
{
    // This class is responisble for databse operations related to songs
    public class SongRepository
    {
        public bool InsertSong(SongDTO songDTO, string albumCoverPath)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Songs] (Title, Artist, Date, Genre, AlbumCoverPath) VALUES (@Title, @Artist, @ReleaseDate, @Genre, @AlbumCoverPath)";

                cmd.Parameters.AddWithValue("@Title", songDTO.SongTitle);

                cmd.Parameters.AddWithValue("@Artist", songDTO.Artist);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = songDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = songDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

                cmd.Parameters.AddWithValue("@AlbumCoverPath", albumCoverPath);

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
                cmd.CommandText = "SELECT TOP (@Count) Title, Artist, Date, Genre FROM Songs ORDER BY ID DESC";


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

                        // This creates a new instance of the SongDTO for each retrieved from the database.
                        // It' also later populated wiht the song's info retreived from the databse and added to the lsit of recent songs.
                        SongDTO song = new SongDTO(title, artist, releaseDate, genre);
                        recentSongs.Add(song);
                    }
                }
            }
            return recentSongs;
        }
    }
}
