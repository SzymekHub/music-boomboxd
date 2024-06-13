using Infrastructure;

namespace UnitTestsMusicBoomBoxd
{
	public class MockUserRepository :IUserRepository
	{
		private Dictionary<int, UserDTO> users = new();


		public Result InsertUser(UserDTO userDTO)
		{
			users.Add(userDTO.UserID, userDTO);
			return new Result { Success = true, Message = "User inserted successfully." };
		}

		public List<UserDTO> GetRecentUser(int count)
		{
			throw new NotImplementedException();

		}

		//for artists
		#region Artist
		public Result AddArtistToUser(int userID, int artistID)
		{
			throw new NotImplementedException();
		}

		public Result RemoveArtistFromUser(int userID, int artistID)
		{
			throw new NotImplementedException();
		}
		#endregion

		//For songs
		#region Songs
		public Result AddSongToUser(int userID, int songID)
		{
			throw new NotImplementedException();
		}

		public Result RemoveSongFromUser(int userID, int songID)
		{
			throw new NotImplementedException();
		}
		#endregion

		//For albums
		#region Albums
		public Result AddAlbumToUser(int userID, int albumID)
		{
			throw new NotImplementedException();
		}

		public Result RemoveAlbumFromUser(int userID, int albumID)
		{
			throw new NotImplementedException();
		}
		#endregion

		public UserDTO GetUserByUsername(string username)
		{
			throw new NotImplementedException();
		}
		public UserDTO GetUserByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public Result UpdateUser(UserDTO userDTO)
		{
			throw new NotImplementedException();
		}

		public Result UpdateUserRoleToCritic(UserDTO userDTO)
		{
			throw new NotImplementedException();
		}

		public Result UpdateUserRoleToMusician(UserDTO userDTO)
		{
			throw new NotImplementedException();
		}

		public Result DeleteUser(UserDTO userDTO)
		{
			throw new NotImplementedException();
		}
	}
}
