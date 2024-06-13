using Infrastructure;
using Logic;


namespace UnitTestsMusicBoomBoxd
{
	public class MockAlbumRepository : IAlbumRepository
	{
		private Dictionary<int, AlbumDTO> albums = new();
		private readonly List<AlbumDTO> _mockAlbum;

        public MockAlbumRepository(List<AlbumDTO> mockAlbum)
        {
			_mockAlbum = mockAlbum;
        }

        public Result InsertAlbum(AlbumDTO albumDTO)
		{
			albums.Add(albumDTO.AlbumID, albumDTO);
			return new Result { Success = true, Message = "Album inserted successfully." };
		}

		//This method returns the most recent users based on their UserID in descending order,
		//It is limited by the count parameter.
		public List<AlbumDTO> GetAlbums(int count)
		{
			return _mockAlbum;
		}

		public Result AddSongToAlbum(int albumID, int songID)
		{
			throw new NotImplementedException();

		}

		public Result RemoveSongFromAlbum(int albumID, int songID)
		{
			throw new NotImplementedException();

		}

		public List<AlbumDTO> GetAlbumsForUser(int userID)
		{
			throw new NotImplementedException();

		}

		public AlbumDTO GetAlbumByTitleAndArtist(string title, int artistId)
		{
			return albums.Values.FirstOrDefault(u => u.AlbumTitle == title && u.ArtistDTO.ArtistID == artistId);
		}


		public int GetAlbumIDByAlbumTitle(string albumTitle)
		{
			var album = albums.Values.FirstOrDefault(u => u.AlbumTitle == albumTitle);
			if (album != null)
			{
				return album.AlbumID;
			}
			throw new InvalidOperationException("Album not found.");
		}


		public AlbumDTO GetAlbumByAlbumID(int albumID)
		{
			throw new NotImplementedException();

		}

		public List<AlbumDTO> GetAlbumsByAlbumIDs(List<int> albumsIDs)
		{
			throw new NotImplementedException();

		}

		public Result AddAverageRating(AlbumDTO albumDTO, double averageRating)
		{
			throw new NotImplementedException();

		}

		public Result UpdateAlbum(AlbumDTO albumDTO)
		{
			if (albums.ContainsKey(albumDTO.AlbumID))
			{
				albums[albumDTO.AlbumID] = albumDTO;
				return new Result { Success = true, Message = "Album updated successfully." };
			}
			return new Result { Success = false, Message = "Album not found." };
		}

		public Result DeleteAlbum(AlbumDTO albumDTO)
		{
			albums.Remove(albumDTO.AlbumID);
			return new Result { Success = true, Message = "Album removed successfully." };
		}
	}
}
