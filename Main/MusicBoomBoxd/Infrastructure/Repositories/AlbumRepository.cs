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

				cmd.Parameters.AddWithValue("@ArtistID", albumDTO.ArtistDTO.ArtistID);

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

		public List<AlbumDTO> GetAlbums(int count)
		{
			List<AlbumDTO> recentAlbums = new List<AlbumDTO>();

			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				//The TOP is parameterized with @Count to dynamically limit the result set.

				cmd.CommandText = @"SELECT TOP (@Count) 
                                    A.AlbumID, A.ArtistID, A.Active AS AlbumActive, A.Title, A.Date, A.RunTimeSec, A.Genre, A.AverageRate, A.AlbumCoverName, A.AlbumCoverData, A.AlbumCoverContentType,
                                    AR.ArtistID AS ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
                                    FROM 
                                        Album A
                                    INNER JOIN 
                                        Artist AR ON A.ArtistID = AR.ArtistID
                                    WHERE 
                                        A.Active = 1 AND AR.Active = 1
                                    ORDER BY 
                                        A.Date DESC";


				cmd.Parameters.AddWithValue("@Count", count);

				try
				{
					conn.Open();

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							//Created and populated the nested ArtistDTO within the AlbumDTO object.

							AlbumDTO albumDTO = new AlbumDTO
							{
								AlbumID = reader.GetInt32(0),
								ArtistDTO = new ArtistDTO
								{
									ArtistID = reader.GetInt32(11),
									Name = reader.GetString(13),
									Active = reader.GetBoolean(12),
									ArtistPictureName = reader.GetString(14),
									ArtistPictureData = (byte[])reader.GetValue(15),
									ArtistPictureContentType = reader.GetString(16)
								},
								AlbumTitle = reader.GetString(3),
								ReleaseDate = reader.GetDateTime(4),
								RunTime = reader.GetInt32(5),
								Genre = reader.GetString(6),
								AlbumCoverName = reader.GetString(8),
								AlbumCoverData = (byte[])reader.GetValue(9),
								AlbumCoverContentType = reader.GetString(10)
							};

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
				// I use inner join becasue I want to retrieve albums only if there is a corresponding artist.
				// And this returns rows where there is a match in both the Album and Artist tables.
				// which makes sure that I always have complete album and artist information.

				cmd.CommandText = @"SELECT AL.AlbumID, AL.ArtistID, AL.Title, AL.Date, AL.RunTimeSec, AL.Genre, AL.AlbumCoverName, AL.AlbumCoverData, AL.AlbumCoverContentType,
                                   AR.ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
                            FROM [Album] AL
                            INNER JOIN [UserAlbums] ULB ON AL.AlbumID = ULB.AlbumID
                            INNER JOIN [Artist] AR ON AL.ArtistID = AR.ArtistID
                            WHERE ULB.UserID = @UserID";

				cmd.Parameters.AddWithValue("@UserID", userID);


				try
				{
					conn.Open();

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							AlbumDTO albumDTO = new AlbumDTO
							{
								AlbumID = reader.GetInt32(0),
								ArtistDTO = new ArtistDTO
								{
									ArtistID = reader.GetInt32(9),
									Name = reader.GetString(11),
									Active = reader.GetBoolean(10),
									ArtistPictureName = reader.GetString(12),
									ArtistPictureData = (byte[])reader.GetValue(13),
									ArtistPictureContentType = reader.GetString(14)
								},
								AlbumTitle = reader.GetString(2),
								ReleaseDate = reader.GetDateTime(3),
								RunTime = reader.GetInt32(4),
								Genre = reader.GetString(5),
								AlbumCoverName = reader.GetString(6),
								AlbumCoverData = (byte[])reader.GetValue(7),
								AlbumCoverContentType = reader.GetString(8)
							};

							albums.Add(albumDTO);
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

			return albums;
		}


		public AlbumDTO GetAlbumByTitleAndArtist(string title, int artistId)
		{
			// I initialize albumDTO as null to handle case where no results are found
			AlbumDTO albumDTO = null;

			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"SELECT AL.AlbumID, AL.Title, AL.ArtistID, AL.Date, AL.Genre, AL.RunTimeSec, AL.AlbumCoverName, AL.AlbumCoverData, AL.AlbumCoverContentType,
                                   AR.ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
									FROM [Album] AL
									INNER JOIN [Artist] AR ON AL.ArtistID = AR.ArtistID
									WHERE AL.Title = @Title AND AL.ArtistID = @ArtistID";

				cmd.Parameters.AddWithValue("@Title", title);
				cmd.Parameters.AddWithValue("@ArtistID", artistId);

				conn.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						albumDTO = new AlbumDTO
						{
							AlbumID = reader.GetInt32(0),
							AlbumTitle = reader.GetString(1),
							ArtistDTO = new ArtistDTO
							{
								ArtistID = reader.GetInt32(10),
								Name = reader.GetString(12),
								Active = reader.GetBoolean(11),
								ArtistPictureName = reader.GetString(13),
								ArtistPictureData = (byte[])reader.GetValue(14),
								ArtistPictureContentType = reader.GetString(15)
							},
							ReleaseDate = reader.GetDateTime(4),
							Genre = reader.GetString(5),
							RunTime = reader.GetInt32(6),
							AlbumCoverName = reader.GetString(7),
							AlbumCoverData = (byte[])reader.GetValue(8),
							AlbumCoverContentType = reader.GetString(9)
						};
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

		public AlbumDTO GetAlbumByAlbumID(int albumID)
		{
			AlbumDTO albumDTO = new AlbumDTO();

			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"SELECT AL.AlbumID, AL.ArtistID, AL.Active, AL.Title, AL.Date, AL.RunTimeSec, AL.Genre, AL.AlbumCoverName, AL.AlbumCoverData, AL.AlbumCoverContentType,
								   AR.ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
								   FROM [Album] AL  
								   INNER JOIN [Artist] AR ON AL.ArtistID = AR.ArtistID
								   WHERE AL.AlbumID = @AlbumID";

				cmd.Parameters.AddWithValue("@AlbumID", albumID);


				connection.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						albumDTO = new AlbumDTO
						{
							AlbumID = reader.GetInt32(0),
							Active = reader.GetBoolean(2),
							AlbumTitle = reader.GetString(3),
							ArtistDTO = new ArtistDTO
							{
								ArtistID = reader.GetInt32(1),
								Name = reader.GetString(12),
								Active = reader.GetBoolean(11),
								ArtistPictureName = reader.GetString(13),
								ArtistPictureData = (byte[])reader.GetValue(14),
								ArtistPictureContentType = reader.GetString(15)
							},
							ReleaseDate = reader.GetDateTime(4),
							Genre = reader.GetString(6),
							RunTime = reader.GetInt32(5),
							AlbumCoverName = reader.GetString(7),
							AlbumCoverData = (byte[])reader.GetValue(8),
							AlbumCoverContentType = reader.GetString(9)
						};
					}
				}
			}
			return albumDTO;
		}

		public Result AddAverageRating(AlbumDTO albumDTO, double averageRating)
		{
			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"UPDATE [Album] SET AverageRate = @AverageRate WHERE AlbumID = @AlbumID";

				cmd.Parameters.AddWithValue("@AverageRate", averageRating);
				cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);

				try
				{
					connection.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						return new Result { Success = true, Message = "Average rating updated successfully." };
					}
					return new Result { Success = false, Message = "Failed to update average rating. No rows affected." };
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
				cmd.Parameters.AddWithValue("@ArtistID", albumDTO.ArtistDTO.ArtistID);

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

					return new Result { Success = false, Message = "Album update failed." };
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
