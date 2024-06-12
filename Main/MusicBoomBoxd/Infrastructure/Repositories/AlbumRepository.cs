using Infrastructure.DTOs;
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
                                        INSERT INTO [Album] (AlbumID, ArtistID, Title, Date, RunTimeSec, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                        VALUES (@AlbumID, @ArtistID, @Title, @Date, @RunTimeSec, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                        SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO [Album] (ArtistID, Title, Date,RunTimeSec, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType) 
                                        VALUES (@ArtistID, @Title, @Date, @RunTimeSec, @Genre, @AlbumCoverName, @AlbumCoverData, @AlbumCoverContentType); 
                                        SELECT SCOPE_IDENTITY();";
                }

                cmd.Parameters.AddWithValue("@ArtistID", albumDTO.ArtistID);

                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = albumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@Date", releaseDateString);

                cmd.Parameters.AddWithValue("@RunTimeSec", albumDTO.RunTime);

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
                cmd.CommandText = @"SELECT TOP (@Count) AlbumID, ArtistID, Title, Date,RunTimeSec, Genre, AlbumCoverName, AlbumCoverData, AlbumCoverContentType " +
                                   "FROM [Album] WHERE Active = 1 ORDER BY AlbumID DESC";


                cmd.Parameters.AddWithValue("@Count", count);
                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
							AlbumDTO albumDTO = new AlbumDTO();
                            albumDTO.AlbumID = reader.GetInt32(0);
                            albumDTO.ArtistID = reader.GetInt32(1);
							albumDTO.AlbumTitle = reader.GetString(2);
							albumDTO.ReleaseDate = reader.GetDateTime(3);
							albumDTO.RunTime = reader.GetInt32(4);
							albumDTO.Genre = reader.GetString(5);
							albumDTO.AlbumCoverName = reader.GetString(6);
							albumDTO.AlbumCoverData = (byte[])reader.GetValue(7);
							albumDTO.AlbumCoverContentType = reader.GetString(8);

                            recentAlbums.Add(albumDTO);
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
        public Result AddSongToAlbum(int albumID, int songID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [AlbumSongs] (AlbumID, SongID) VALUES (@AlbumID, @SongID);";

                cmd.Parameters.AddWithValue("@AlbumID", albumID);
                cmd.Parameters.AddWithValue("@SongID", songID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Song added to album successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to add song to album." };
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
        public Result RemoveSongFromAlbum(int albumID, int songID)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [AlbumSongs] WHERE AlbumID = @AlbumID AND SongID = @SongID;";

                cmd.Parameters.AddWithValue("@AlbumID", albumID);
                cmd.Parameters.AddWithValue("@SongID", songID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return new Result { Success = true, Message = "Song removed from album successfully." };
                    }
                    return new Result { Success = false, Message = "Failed to remove song from album." };
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

        public List<AlbumDTO> GetAlbumsForUser(int userID)
        {
            List<AlbumDTO> albums = new List<AlbumDTO>();

            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT AL.AlbumID, AL.ArtistID, AL.Title, AL.Date, AL.RunTimeSec, AL.Genre, AL.AlbumCoverName, AL.AlbumCoverData, AL.AlbumCoverContentType 
                            FROM [Album] AL 
                            INNER JOIN [UserAlbums] ULB ON AL.AlbumID = ULB.AlbumID 
                            WHERE ULB.UserID = @UserID";

                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
						AlbumDTO albumDTO = new AlbumDTO();
						albumDTO.AlbumID = reader.GetInt32(0);
						albumDTO.ArtistID = reader.GetInt32(1);
						albumDTO.AlbumTitle = reader.GetString(2);
						albumDTO.ReleaseDate = reader.GetDateTime(3);
						albumDTO.RunTime = reader.GetInt32(4);
						albumDTO.Genre = reader.GetString(5);
						albumDTO.AlbumCoverName = reader.GetString(6);
						albumDTO.AlbumCoverData = (byte[])reader.GetValue(7);
						albumDTO.AlbumCoverContentType = reader.GetString(8);

                        albums.Add(albumDTO);
                    }
                }
            }
            return albums;
        }

		public AlbumDTO GetAlbumByTitleAndArtist(string title, int artistId)
		{
			AlbumDTO albumDTO = new AlbumDTO();

			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT AlbumID, Title, ArtistID, Date, Genre " +
								  "FROM [Album] WHERE Title = @Title AND ArtistID = @ArtistID";

				cmd.Parameters.AddWithValue("@Title", title);
				cmd.Parameters.AddWithValue("@ArtistID", artistId);

				conn.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						albumDTO.AlbumID = reader.GetInt32(0);
						albumDTO.AlbumTitle = reader.GetString(1);
						albumDTO.ArtistID = reader.GetInt32(2);
						albumDTO.ReleaseDate = reader.GetDateTime(3);
						albumDTO.Genre = reader.GetString(4);
					}
				}
			}
			return albumDTO;
		}

        public int GetAlbumIDByAlbumTitle(string albumTitle)
        {
            int albumID = 0;
			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
            {
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT AlbumID FROM [Album] WHERE Title = @Title";

				cmd.Parameters.AddWithValue("@Title", albumTitle);

				conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    albumID = Convert.ToInt32(result);
                }
			}

            return albumID;
		}

		public Result UpdateAlbum(AlbumDTO albumDTO)
        {
            using (SqlConnection conn = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [Album] SET ArtistID = @ArtistID, Title = @Title, Date = @Date, RunTimeSec = @RunTimeSec, Genre = @Genre, AlbumCoverName = @AlbumCoverName, AlbumCoverData = @AlbumCoverData, AlbumCoverContentType = @AlbumCoverContentType
                                  WHERE AlbumID = @AlbumID";


                cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);
                cmd.Parameters.AddWithValue("@ArtistID", albumDTO.ArtistID);

                cmd.Parameters.AddWithValue("@Title", albumDTO.AlbumTitle);

                // This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
                string releaseDateString = albumDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@Date", releaseDateString);

                cmd.Parameters.AddWithValue("@RunTimeSec", albumDTO.RunTime);

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
