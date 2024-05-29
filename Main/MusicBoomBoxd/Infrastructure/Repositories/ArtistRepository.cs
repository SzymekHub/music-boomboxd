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
                                    INSERT INTO [Artist] (ArtistID, Name, ArtistPictureName, ArtistPictureData, ArtistPictureContentType) 
                                    VALUES (@ArtistID, @Name, @ArtistPictureName, @ArtistPictureData, @ArtistPictureContentType); 
                                    SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@ArtistID", artistDTO.ArtistID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [Artist] (Name, ArtistPictureName, ArtistPictureData, ArtistPictureContentType) 
                                    VALUES (@Name, @ArtistPictureName, @ArtistPictureData, @ArtistPictureContentType); 
                                    SELECT SCOPE_IDENTITY();";
                }

                cmd.Parameters.AddWithValue("@Name", artistDTO.Name);
                cmd.Parameters.AddWithValue("@ArtistPictureName", artistDTO.ArtistPictureName);
                cmd.Parameters.AddWithValue("@ArtistPictureData", artistDTO.ArtistPictureData);
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
                cmd.CommandText = "SELECT TOP (@count) ArtistID, Name, ArtistPictureName, ArtistPictureData, ArtistPictureContentType " +
                                  "FROM [Artist]" +
                                  "ORDER BY ArtistID DESC";

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
                            string artistPictureName = reader.GetString(2);
                            byte[] artistPictureData = (byte[])reader.GetValue(3);
                            string artistPictureContentType = reader.GetString(4);

                            ArtistDTO artist = new ArtistDTO(artistID, name, artistPictureName, artistPictureData, artistPictureContentType);
                            artists.Add(artist);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Log or handle exception
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            return artists;
        }

        public Result UpdateArtist(ArtistDTO newArtistDTO, ArtistDTO oldArtistDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                // Your update logic here
            }
        }

        public Result DeleteArtist(ArtistDTO artistDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                // Your delete logic here
            }
        }
    }
}
