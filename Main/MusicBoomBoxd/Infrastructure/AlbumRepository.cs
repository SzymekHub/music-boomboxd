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
        public bool InsertAlbum(AlbumDTO albumDTO)
        {
            using (SqlConnection conn = DbConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [Albums] (Title, Artist, Date, Genre, AlbumCover) VALUES (@Title, @Artist, @ReleaseDate, @Genre, @AlbumCover)";


                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                cmd.Parameters.AddWithValue("@Artist", albumDTO.Artist);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = albumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = albumDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

                ////This converts the albumcover to a byte array to pass it to Database
                byte[] albumCover = albumDTO.AlbumCover.ToArray();
                cmd.Parameters.AddWithValue("@AlbumCover", albumCover);

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
                cmd.CommandText = "SELECT TOP (@Count) Title, Artist, Date, Genre, AlbumCover FROM Albums ORDER BY ID DESC";


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
                        byte[] albumCover = (byte[])reader.GetValue(4);

                        AlbumDTO album = new AlbumDTO(title, artist, releaseDate, genre, albumCover);
                        recentAlbums.Add(album);
                    }
                }
            }
            return recentAlbums;
        }
    }
}
