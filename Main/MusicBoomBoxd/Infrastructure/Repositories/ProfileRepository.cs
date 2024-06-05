using System.Data;
using Microsoft.Data.SqlClient;

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

                cmd.Parameters.AddWithValue("@UserID", profileDTO.UserID);
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
