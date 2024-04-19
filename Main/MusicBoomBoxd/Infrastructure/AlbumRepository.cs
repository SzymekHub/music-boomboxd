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
                cmd.CommandText = @"INSERT INTO [Albums] (Title, Artist, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                    VALUES (@Title, @Artist, @ReleaseDate, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                    SELECT SCOPE_IDENTITY();";


                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                cmd.Parameters.AddWithValue("@Artist", albumDTO.Artist);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = albumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

                // This converts the genre enum to a string to pass it to Database
                string genreString = albumDTO.Genre.ToString();
                cmd.Parameters.AddWithValue("@Genre", genreString);

                cmd.Parameters.AddWithValue("@AlbumCoverName", albumDTO.AlbumCoverName);
                cmd.Parameters.AddWithValue("@AlbumCoverData", albumDTO.AlbumCoverData);
                cmd.Parameters.AddWithValue("@AlbumCoverContentType", albumDTO.AlbumCoverContentType);

                ////This converts the albumcover to a byte array to pass it to Database
                //byte[] albumCoverData = albumDTO.AlbumCoverData.ToArray();
                //cmd.Parameters.AddWithValue("@AlbumCoverData", albumCoverData);
                
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
                cmd.CommandText = "SELECT TOP (@Count) Title, Artist, Date, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType FROM Albums ORDER BY ID DESC";


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
                        string albumCoverName = reader.GetString(4);
                        byte[] albumCoverData = (byte[])reader.GetValue(5);
                        string albumCoverContentType = reader.GetString(6);

                        AlbumDTO album = new AlbumDTO(title, artist, releaseDate, genre, albumCoverName, albumCoverData, albumCoverContentType);
                        recentAlbums.Add(album);
                    }
                }
            }
            return recentAlbums;
        }
    }
}
