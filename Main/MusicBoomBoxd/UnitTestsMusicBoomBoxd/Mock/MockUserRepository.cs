using Infrastructure;

namespace UnitTestsMusicBoomBoxd
{
	public class MockUserRepository :IUserRepository
	{
		private Dictionary<int, UserDTO> users = new();
		private readonly List<UserDTO> _mockUser;

		public MockUserRepository(List<UserDTO> mockUser)
		{
			_mockUser = mockUser;
		}

		public Result InsertUser(UserDTO userDTO)
		{
			users.Add(userDTO.UserID, userDTO);
			return new Result { Success = true, Message = "User inserted successfully." };
		}

		//This method returns the most recent users based on their UserID in descending order,
		//It is limited by the count parameter.
		public List<UserDTO> GetRecentUser(int count)
		{
			return _mockUser;
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
			return users.Values.FirstOrDefault(u => u.Username == username);
		}
		public UserDTO GetUserByEmail(string email)
		{
            return users.Values.FirstOrDefault(u => u.Email == email);
		}

		public Result UpdateUser(UserDTO userDTO)
		{
			if (users.ContainsKey(userDTO.UserID))
			{
				users[userDTO.UserID] = userDTO;
				return new Result { Success = true, Message = "User updated successfully." };
			}
			return new Result { Success = false, Message = "User not found." };
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
			users.Remove(userDTO.UserID);
			return new Result { Success = true, Message = "User removed successfully." };
		}
	}
}
