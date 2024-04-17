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
    public class AlbumRepository
    {
        // This class is responisble for databse operations related to Albums
        public bool InsertAlbum(AlbumDTO albumDTO, string albumCoverPath)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Album] (Title, Artist, Date, Genre, AlbumCover, NumberOfSongs) VALUES (@Title, @Artist, @ReleaseDate, @Genre, @AlbumCover, @NumberOfSongs)";

                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                cmd.Parameters.AddWithValue("@Artist", albumDTO.Artist);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = albumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = albumDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

                cmd.Parameters.AddWithValue("@AlbumCover", albumCoverPath);

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

        public List<AlbumDTO> GetRecentAlbum(int count)
        {
            List<AlbumDTO> recentAlbums = new List<AlbumDTO>();

            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP (@Count) Title, Artist, Date, Genre FROM Albums ORDER BY ID DESC";


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
                        string numberOfSongs = reader.GetString(4);

                        // This creates a new instance of the SongDTO for each retrieved from the database.
                        // It' also later populated wiht the song's info retreived from the databse and added to the lsit of recent songs.
                        AlbumDTO album = new AlbumDTO(title, artist, releaseDate, genre, numberOfSongs);
                        recentAlbums.Add(album);
                    }
                }
            }
            return recentAlbums;
        }
    }
}
