using Microsoft.Data.SqlClient;
using System.Data;
using Infrastructure.InterfacesForRepo;
using Infrastructure.DTOs;

namespace Infrastructure.Repositories
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
                                    INSERT INTO [Song] (SongID, Title, ArtistID, Date, RunTimeSec, Genre, SongCoverName, SongCoverData, SongCoverContentType) 
                                    VALUES (@SongID, @Title, @ArtistID, @ReleaseDate, @RunTimeSec, @Genre, @SongCoverName, @SongCoverData, @SongCoverContentType)
                                    SELECT SCOPE_IDENTITY();";

					cmd.Parameters.AddWithValue("@SongID", songDTO.SongID);
				}
				else
				{
					cmd.CommandText = @"INSERT INTO [Song] (Title, ArtistID, Date, RunTimeSec, Genre, SongCoverName, SongCoverData, SongCoverContentType) 
                                    VALUES (@Title, @ArtistID, @ReleaseDate, @RunTimeSec, @Genre, @SongCoverName, @SongCoverData, @SongCoverContentType)
                                    SELECT SCOPE_IDENTITY();";

				}
				cmd.Parameters.AddWithValue("@Title", songDTO.SongTitle);

				cmd.Parameters.AddWithValue("@ArtistID", songDTO.ArtistDTO.ArtistID);

				// This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
				string releaseDateString = songDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
				cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

				cmd.Parameters.AddWithValue("@RunTimeSec", songDTO.RunTime);


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

		public List<SongDTO> GetSongs(int count)
		{
			List<SongDTO> recentSongs = new List<SongDTO>();

			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				//The TOP is parameterized with @Count to dynamically limit the result set.

				cmd.CommandText = "SELECT TOP (@Count) " +
								  "S.SongID, S.Active AS SongActive, S.Title, S.ArtistID, S.Date, S.RunTimeSec, S.Genre, S.SongCoverName, S.SongCoverData, S.SongCoverContentType, " +
					              "AR.ArtistID AS ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType " +
								  "FROM Song S " +
								  "INNER JOIN Artist AR ON S.ArtistID = AR.ArtistID " +
								  "WHERE S.Active = 1 AND AR.Active = 1" +
								  "ORDER BY S.Date DESC";


				cmd.Parameters.AddWithValue("@Count", count);

				try
				{


					conn.Open();

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							//Created and populated the nested ArtistDTO within the AlbumDTO object.

							SongDTO songDTO = new SongDTO
							{
								SongID = reader.GetInt32(0),
								SongTitle = reader.GetString(2),
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
								RunTime = reader.GetInt32(5),
								Genre = reader.GetString(6),
								SongCoverName = reader.GetString(7),
								SongCoverData = (byte[])reader.GetValue(8),
								SongCoverContentType = reader.GetString(9)
							};

							recentSongs.Add(songDTO);
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
			return recentSongs;
		}

		public List<SongDTO> GetSongsForAlbum(int albumID)
		{
			List<SongDTO> songs = new List<SongDTO>();

			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"SELECT S.SongID, S.Title, S.ArtistID, S.Date, S.RunTimeSec, S.Genre, S.SongCoverName, S.SongCoverData, S.SongCoverContentType, 
                                   AR.ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
							FROM [Song] S 
                            INNER JOIN [AlbumSongs] ALB ON S.SongID = ALB.SongID 
                            INNER JOIN [Artist] AR ON S.ArtistID = AR.ArtistID
                            WHERE ALB.AlbumID = @AlbumID";

				cmd.Parameters.AddWithValue("@AlbumID", albumID);

				conn.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						SongDTO songDTO = new SongDTO
						{
							SongID = reader.GetInt32(0),
							SongTitle = reader.GetString(1),
							ArtistDTO = new ArtistDTO
							{
								ArtistID = reader.GetInt32(9),
								Name = reader.GetString(11),
								Active = reader.GetBoolean(10),
								ArtistPictureName = reader.GetString(12),
								ArtistPictureData = (byte[])reader.GetValue(13),
								ArtistPictureContentType = reader.GetString(14)
							},
							ReleaseDate = reader.GetDateTime(3),
							RunTime = reader.GetInt32(4),
							Genre = reader.GetString(5),
							SongCoverName = reader.GetString(6),
							SongCoverData = (byte[])reader.GetValue(7),
							SongCoverContentType = reader.GetString(8)
						};

						songs.Add(songDTO);
					}
				}
			}
			return songs;
		}

		public List<SongDTO> GetSongsForUser(int userID)
		{
			List<SongDTO> songs = new List<SongDTO>();

			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"SELECT S.SongID, S.Title, S.ArtistID, S.Date, S.RunTimeSec, S.Genre, S.SongCoverName, S.SongCoverData, S.SongCoverContentType, 
                                   AR.ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
							FROM [Song] S 
                            INNER JOIN [UserSongs] USR ON S.SongID = USR.SongID 
                            INNER JOIN [Artist] AR ON S.ArtistID = AR.ArtistID
                            WHERE USR.UserID = @UserID";

				cmd.Parameters.AddWithValue("@UserID", userID);

				conn.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						SongDTO songDTO = new SongDTO
						{
							SongID = reader.GetInt32(0),
							SongTitle = reader.GetString(1),
							ArtistDTO = new ArtistDTO
							{
								ArtistID = reader.GetInt32(9),
								Name = reader.GetString(11),
								Active = reader.GetBoolean(10),
								ArtistPictureName = reader.GetString(12),
								ArtistPictureData = (byte[])reader.GetValue(13),
								ArtistPictureContentType = reader.GetString(14)
							},
							ReleaseDate = reader.GetDateTime(3),
							RunTime = reader.GetInt32(4),
							Genre = reader.GetString(5),
							SongCoverName = reader.GetString(6),
							SongCoverData = (byte[])reader.GetValue(7),
							SongCoverContentType = reader.GetString(8)
						};

						songs.Add(songDTO);

					}
				}
			}
			return songs;
		}
		public SongDTO GetSongByTitleAndArtist(string title, int artistId)
		{
			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT S.SongID, S.Title, S.ArtistID, " +
								  "AR.ArtistID, AR.Active AS ArtistActive, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType" +
								  "FROM [Song] S" +
								  "INNER JOIN [Artist] AR ON S.ArtistID = AR.ArtistID" +
								  "WHERE S.Title = @Title AND AR.ArtistID = @ArtistID";

				cmd.Parameters.AddWithValue("@Title", title);
				cmd.Parameters.AddWithValue("@ArtistID", artistId);

				conn.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						SongDTO songDTO = new SongDTO
						{
							SongID = reader.GetInt32(0),
							SongTitle = reader.GetString(1),
							ArtistDTO = new ArtistDTO
							{
								ArtistID = reader.GetInt32(2),
								Name = reader.GetString(4),
								Active = reader.GetBoolean(3),
								ArtistPictureName = reader.GetString(5),
								ArtistPictureData = (byte[])reader.GetValue(6),
								ArtistPictureContentType = reader.GetString(7)
							}
						};

						return songDTO;
					}
				}
			}
			return null;
		}

		public int GetSongIDBySongTitle(string songTitle)
		{
			int songID = 0;
			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT SongID FROM [Song] WHERE Title = @Title";

				cmd.Parameters.AddWithValue("@Title", songTitle);

				conn.Open();

				object result = cmd.ExecuteScalar();
				if (result != null)
				{
					songID = Convert.ToInt32(result);
				}
			}

			return songID;
		}

		public Result UpdateSong(SongDTO songDTO)
		{
			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"UPDATE [Song] SET Title = @Title, ArtistID = @ArtistID, Date = @ReleaseDate, RunTimeSec = @RunTimeSec, Genre = @Genre, SongCoverName = @SongCoverName, SongCoverData = @SongCoverData, SongCoverContentType = @SongCoverContentType
                                WHERE SongID = @SongID";


				cmd.Parameters.AddWithValue("SongID", songDTO.SongID);
				cmd.Parameters.AddWithValue("@Title", songDTO.SongTitle);
				cmd.Parameters.AddWithValue("@ArtistID", songDTO.ArtistDTO.ArtistID);

				// This converts DateTime to string in the format "yyyy-MM-dd HH:mm:ss.fff" so that it works with the databse
				string releaseDateString = songDTO.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
				cmd.Parameters.AddWithValue("@ReleaseDate", releaseDateString);

				cmd.Parameters.AddWithValue("@RunTimeSec", songDTO.RunTime);

				// This converts the genre enum to a string to pass it to Database
				string genreString = songDTO.Genre.ToString();
				cmd.Parameters.AddWithValue("@Genre", genreString);
				cmd.Parameters.AddWithValue("@SongCoverName", songDTO.SongCoverName);

				//This converts the Songcover to a byte array to pass it to Database
				byte[] SongCoverData = songDTO.SongCoverData.ToArray();
				cmd.Parameters.AddWithValue("@SongCoverData", SongCoverData);
				cmd.Parameters.AddWithValue("@SongCoverContentType", songDTO.SongCoverContentType);

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
                                    WHERE SongID = @SongID ";

				cmd.Parameters.AddWithValue("@SongID", songDTO.SongID);

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
