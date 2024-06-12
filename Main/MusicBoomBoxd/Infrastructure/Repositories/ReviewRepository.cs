using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure
{
    public class ReviewRepository : DbConnection, IReviewRepository
    {
        public Result InsertReview(ReviewDTO reviewDTO)
        {
            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [UserAlbumRating] (UserID, AlbumID, Rate) 
                                    VALUES (@UserID, @AlbumID, @Rate)";

                cmd.Parameters.AddWithValue("@UserID", reviewDTO.UserDTO.UserID);
                cmd.Parameters.AddWithValue("@AlbumID", reviewDTO.AlbumDTO.AlbumID);
                cmd.Parameters.AddWithValue("@Rate", reviewDTO.Rate);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return new Result { Success = true, Message = "Rating inserted successfully" };
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

        public Result UpdateReview(ReviewDTO reviewDTO)
        {
            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [UserRating] SET Rate = @Rate 
                                    WHERE UserID = @UserID AND AlbumID = @AlbumID";

                cmd.Parameters.AddWithValue("@UserID", reviewDTO.UserDTO.UserID);
                cmd.Parameters.AddWithValue("@AlbumID", reviewDTO.AlbumDTO.AlbumID);
                cmd.Parameters.AddWithValue("@Rate", reviewDTO.Rate);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return new Result { Success = true, Message = "Rating updated successfully" };
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

        public ReviewDTO GetReviewByUserAndAlbumID(ReviewDTO reviewDTO)
        {
            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT UR.UserRatingID, UR.UserID, UR.AlbumID, UR.Rate, 
                            U.Active, U.Username, U.Password, U.Email, U.UserType, U.Birthday, U.FavGenre, U.ProfilePictureName, U.ProfilePictureData, U.ProfilePictureContentType, 
                            A.ArtistID, A.Active, A.Title, A.Date, A.RunTimeSec, A.Genre, A.AverageRate, A.AlbumCoverName, A.AlbumCoverData, A.AlbumCoverContentType,
                            AR.ArtistID, AR.Active, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
                            FROM [UserAlbumRating] UR
                            INNER JOIN [User] U ON UR.UserID = U.UserID
                            INNER JOIN [Album] A ON UR.AlbumID = A.AlbumID
                            INNER JOIN [Artist] AR ON A.ArtistID = AR.ArtistID
                            WHERE UR.UserID = @UserID AND UR.AlbumID = @AlbumID";

                cmd.Parameters.AddWithValue("@UserID", reviewDTO.UserDTO.UserID);
                cmd.Parameters.AddWithValue("@AlbumID", reviewDTO.AlbumDTO.AlbumID);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ReviewDTO review = new ReviewDTO
                        {
                            UserRatingID = reader.GetInt32(0),
                            Rate = reader.GetInt32(3),
                            UserDTO = new UserDTO
                            {
                                UserID = reader.GetInt32(1),
                                Username = reader.GetString(5),
                                Password = reader.GetString(6),
                                Email = reader.GetString(7),
                                UserType = reader.GetString(8),
                                Birthday = reader.GetDateTime(9),
                                FavGenre = reader.GetString(10),
                                ProfilePictureName = reader.GetString(11),
                                ProfilePictureData = (byte[])reader[12],
                                ProfilePictureContentType = reader.GetString(13),
                                Active = reader.GetBoolean(4)
                            },
                            AlbumDTO = new AlbumDTO
                            {
                                AlbumID = reader.GetInt32(2),
                                AlbumTitle = reader.GetString(15),
                                ReleaseDate = reader.GetDateTime(16),
                                RunTime = reader.GetInt32(17),
                                Genre = reader.GetString(18),
                                AlbumCoverName = reader.GetString(20),
                                AlbumCoverData = (byte[])reader[21],
                                AlbumCoverContentType = reader.GetString(22),
                                ArtistDTO = new ArtistDTO
                                {
                                    ArtistID = reader.GetInt32(23),
                                    Active = reader.GetBoolean(24),
                                    Name = reader.GetString(25),
                                    ArtistPictureName = reader.GetString(26),
                                    ArtistPictureData = (byte[])reader[27],
                                    ArtistPictureContentType = reader.GetString(28)
                                }
                            }
                        };

                        return review;
                    }
                }
            }
            return null;
        }


        public List<ReviewDTO> GetReviewsByAlbumID(AlbumDTO albumDTO)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();

            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT UserRatingID, UserID, AlbumID, Rate 
                            FROM [UserAlbumRating] 
                            WHERE AlbumID = @AlbumID";

                cmd.Parameters.AddWithValue("@AlbumID", albumDTO.AlbumID);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReviewDTO reviewDTO = new ReviewDTO
                        {
                            UserRatingID = reader.GetInt32(0),
                            UserDTO = new UserDTO
                            {
                                UserID = reader.GetInt32(1)
                            },
                            AlbumDTO = new AlbumDTO
                            {
                                AlbumID = reader.GetInt32(2)
                            },
                            Rate = reader.GetInt32(3)
                        };

                        reviews.Add(reviewDTO);
                    }
                }
            }
            return reviews;
        }


        public List<ReviewDTO> GetAllReviews()
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();

            using (SqlConnection connection = GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT UR.UserRatingID, UR.UserID, UR.AlbumID, UR.Rate, 
                            U.Active, U.Username, U.Password, U.Email, U.UserType, U.Birthday, U.FavGenre, U.ProfilePictureName, U.ProfilePictureData, U.ProfilePictureContentType, 
                            A.ArtistID, A.Active, A.Title, A.Date, A.RunTimeSec, A.Genre, A.AverageRate, A.AlbumCoverName, A.AlbumCoverData, A.AlbumCoverContentType,
                            AR.ArtistID, AR.Active, AR.Name, AR.AritstPictureName, AR.ArtistPictureData, AR.ArtistPictureContentType
                            FROM [UserAlbumRating] UR
                            INNER JOIN [User] U ON UR.UserID = U.UserID
                            INNER JOIN [Album] A ON UR.AlbumID = A.AlbumID
                            INNER JOIN [Artist] AR ON A.ArtistID = AR.ArtistID";

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReviewDTO reviewDTO = new ReviewDTO
                        {
                            UserRatingID = reader.GetInt32(0),
                            Rate = reader.GetInt32(3),
                            UserDTO = new UserDTO
                            {
                                UserID = reader.GetInt32(1),
                                Active = reader.GetBoolean(4),
                                Username = reader.GetString(5),
                                Password = reader.GetString(6),
                                Email = reader.GetString(7),
                                UserType = reader.GetString(8),
                                Birthday = reader.GetDateTime(9),
                                FavGenre = reader.GetString(10),
                                ProfilePictureName = reader.GetString(11),
                                ProfilePictureData = (byte[])reader[12],
                                ProfilePictureContentType = reader.GetString(13)
                            },
                            AlbumDTO = new AlbumDTO
                            {
                                AlbumID = reader.GetInt32(2),
                                ArtistDTO = new ArtistDTO
                                {
                                    ArtistID = reader.GetInt32(14),
                                    Active = reader.GetBoolean(15),
                                    Name = reader.GetString(16),
                                    ArtistPictureName = reader.GetString(17),
                                    ArtistPictureData = (byte[])reader[18],
                                    ArtistPictureContentType = reader.GetString(19)
                                },
                                AlbumTitle = reader.GetString(20),
                                ReleaseDate = reader.GetDateTime(21),
                                RunTime = reader.GetInt32(22),
                                Genre = reader.GetString(23),
                                AlbumCoverName = reader.GetString(25),
                                AlbumCoverData = (byte[])reader[26],
                                AlbumCoverContentType = reader.GetString(27)
                            }
                        };

                        reviews.Add(reviewDTO);
                    }
                }
            }
            return reviews;
        }

    }
}
