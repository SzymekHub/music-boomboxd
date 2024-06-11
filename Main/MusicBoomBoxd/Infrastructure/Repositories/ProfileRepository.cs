using System.Data;
using Infrastructure.DTOs;
using System.Reflection.PortableExecutable;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure
{
	public class ProfileRepository : DbConnection, IProfileRepository
	{
		public Result InsertProfile(ProfileDTO profileDTO)
		{
			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = @"INSERT INTO Profile (UserID, User_Balance) 
                                    VALUES (@UserID, @User_Balance)";

				cmd.Parameters.AddWithValue("@UserID", profileDTO.UserDTO);
				cmd.Parameters.AddWithValue("@User_Balance", profileDTO.User_Balance);

				try
				{
					connection.Open();
					cmd.ExecuteNonQuery();
					return new Result { Success = true, Message = "Profile created successfully" };
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

		public Result AddProfileCritic(ProfileDTO profileDTO)
		{
			int upgradeToCriticFee = 50;

			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				SqlTransaction transaction = null;

				try
				{
					connection.Open();
					transaction = connection.BeginTransaction();

					double totalUpgradeAmount = upgradeToCriticFee;

					cmd.Parameters.Clear();
					cmd.CommandText = "UPDATE Profile SET User_Balance = User_Balance - @TotalUpgradeAmount WHERE ProfileID = @ProfileID";
					cmd.Parameters.AddWithValue("@TotalUpgradeAmount", totalUpgradeAmount);
					cmd.Parameters.AddWithValue("@ProfileID", profileDTO.ProfileID);
					cmd.ExecuteNonQuery();

					transaction.Commit();
					return new Result { Success = true, Message = "Account upgraded to critic and balance updated successfully" };
				}
				catch (SqlException ex)
				{
					if (transaction != null) transaction.Rollback();
					return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
				}
				catch (Exception ex)
				{
					if (transaction != null) transaction.Rollback();
					return new Result { Success = false, Message = $"Exception: {ex.Message}" };
				}
			}
		}

		public Result AddProfileMusician(ProfileDTO profileDTO)
		{
			int upgradeToMusicianFee = 30;

			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				SqlTransaction transaction = null;

				try
				{
					connection.Open();
					transaction = connection.BeginTransaction();

					double totalUpgradeAmount = upgradeToMusicianFee;

					cmd.Parameters.Clear();
					cmd.CommandText = "UPDATE Profile SET User_Balance = User_Balance - @TotalUpgradeAmount WHERE ProfileID = @ProfileID";
					cmd.Parameters.AddWithValue("@TotalUpgradeAmount", totalUpgradeAmount);
					cmd.Parameters.AddWithValue("@ProfileID", profileDTO.ProfileID);
					cmd.ExecuteNonQuery();

					transaction.Commit();
					return new Result { Success = true, Message = "Account upgraded to musician and balance updated successfully" };
				}
				catch (SqlException ex)
				{
					if (transaction != null) transaction.Rollback();
					return new Result { Success = false, Message = $"SQL Exception: {ex.Message}" };
				}
				catch (Exception ex)
				{
					if (transaction != null) transaction.Rollback();
					return new Result { Success = false, Message = $"Exception: {ex.Message}" };
				}
			}
		}

		public ProfileDTO GetProfileDTOForUser(int userID)
		{
			using (SqlConnection conn = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT [Profile].[ProfileID], [User].UserID, [Profile].User_Balance, [User].Active, [User].Username, [User].Password, [User].Email, [User].UserType,[User].Birthday, [User].FavGenre, [User].ProfilePictureName, [User].ProfilePictureData, [User].ProfilePictureContentType FROM [Profile] "
								+ "Left JOIN[User] on Profile.UserID = [User].UserID WHERE [User].UserID = @UserID";

				cmd.Parameters.AddWithValue("@UserID", userID);

				try
				{
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						UserDTO user = new UserDTO(
							reader.GetInt32(1),
							reader.GetString(4),
							reader.GetString(5),
							reader.GetString(6),
							reader.GetString(7),
							reader.GetDateTime(8),
							reader.GetString(9),
							reader.GetString(10),
							(byte[])reader.GetValue(11),
							reader.GetString(12)
							);
					
						ProfileDTO profile = new ProfileDTO();
						profile.ProfileID = reader.GetInt32(0);
						profile.UserDTO = user;
						profile.User_Balance = reader.GetInt32(2);

						return profile;

					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL Exception: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception: {ex.Message}");
				}
			}
			return null;
		}

		public double GetBalance(string userName)
		{
			double balance = 50;

			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT User_Balance FROM Profile WHERE UserID = (SELECT UserID FROM [User] WHERE Username = @Username)";
				cmd.Parameters.AddWithValue("@Username", userName);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						balance = reader.GetDouble(0);
					}
				}
			}
			return balance;
		}

		public Result AddToUserBalance(int profileID, double amount)
		{
			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "UPDATE Profile SET User_Balance = User_Balance + @Amount WHERE ProfileID = @ProfileID";
				cmd.Parameters.AddWithValue("@Amount", amount);
				cmd.Parameters.AddWithValue("@ProfileID", profileID);

				try
				{
					connection.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						return new Result { Success = true, Message = "User Balance updated successfully" };
					}
					else
					{
						return new Result { Success = false, Message = "User not found" };
					}
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

		public int GetProfileIDByUsername(string userName)
		{
			int profileID = 0;

			using (SqlConnection connection = GetSqlConnection())
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT ProfileID FROM Profile WHERE UserID = (SELECT UserID FROM [User] WHERE Username = @Username)";
				cmd.Parameters.AddWithValue("@Username", userName);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						profileID = reader.GetInt32(0);
					}
				}
			}
			return profileID;
		}


	}
}
