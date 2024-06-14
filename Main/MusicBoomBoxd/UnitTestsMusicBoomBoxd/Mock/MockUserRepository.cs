using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
    public class MockUserRepository :IUserRepository
	{
		private readonly List<UserDTO> _mockUsers;

		public MockUserRepository(List<UserDTO> mockUser)
		{
			_mockUsers = mockUser;
		}

		public Result InsertUser(UserDTO userDTO)
		{
			if (_mockUsers.Any(u => u.Username == userDTO.Username))
			{
                return new Result { Success = false, Message = "User already exists." };
            }

			int newUserId = _mockUsers.Count +1;
			userDTO.UserID = newUserId;

			_mockUsers.Add(userDTO);

			return new Result { Success = true, };

        }

		public List<UserDTO> GetRecentUser(int count)
		{
			return _mockUsers;
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
			return _mockUsers.FirstOrDefault(u => u.Username == username);
		}
		public UserDTO GetUserByEmail(string email)
		{
            return _mockUsers.FirstOrDefault(u => u.Email == email);
		}

		public Result UpdateUser(UserDTO userDTO)
		{
            var existingUser = _mockUsers.FirstOrDefault(u => u.UserID == userDTO.UserID);
            if (existingUser != null)
            {
                existingUser.Username = userDTO.Username;
                existingUser.Email = userDTO.Email;
                existingUser.UserType = userDTO.UserType;
                existingUser.Birthday = userDTO.Birthday;
                existingUser.FavGenre = userDTO.FavGenre;
                existingUser.ProfilePictureName = userDTO.ProfilePictureName;
                existingUser.ProfilePictureData = userDTO.ProfilePictureData;
                existingUser.ProfilePictureContentType = userDTO.ProfilePictureContentType;
                existingUser.ProfileDTO = userDTO.ProfileDTO;
                existingUser.Active = userDTO.Active;
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
			_mockUsers.Remove(userDTO);
			return new Result { Success = true, Message = "User removed successfully." };
		}
	}
}
