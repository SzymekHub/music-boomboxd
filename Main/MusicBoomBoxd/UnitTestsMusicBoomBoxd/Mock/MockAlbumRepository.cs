using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
    public class MockAlbumRepository : IAlbumRepository
	{
		private readonly List<AlbumDTO> _mockAlbum;

        public MockAlbumRepository(List<AlbumDTO> mockAlbum)
        {
			_mockAlbum = mockAlbum;
        }

        public Result InsertAlbum(AlbumDTO albumDTO)
		{
            if (_mockAlbum.Any(a => a.AlbumTitle == albumDTO.AlbumTitle))
            {
                return new Result { Success = false, Message = "Album already exists." };
            }

            int newAlbumId = _mockAlbum.Count + 1;
            albumDTO.AlbumID = newAlbumId;

            _mockAlbum.Add(albumDTO);

            return new Result { Success = true, };
        }


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
            return _mockAlbum.FirstOrDefault(u => u.AlbumTitle == title && u.ArtistDTO != null && u.ArtistDTO.ArtistID == artistId);
        }



        public int GetAlbumIDByAlbumTitle(string albumTitle)
		{
			var album = _mockAlbum.FirstOrDefault(u => u.AlbumTitle == albumTitle);
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
            var existingAlbum = _mockAlbum.FirstOrDefault(a => a.AlbumID == albumDTO.AlbumID);
            if (existingAlbum != null)
            {
                existingAlbum.AlbumTitle = albumDTO.AlbumTitle;
                existingAlbum.ReleaseDate = albumDTO.ReleaseDate;
                existingAlbum.Genre = albumDTO.Genre;
                existingAlbum.AlbumCoverName = albumDTO.AlbumCoverName;
                existingAlbum.AlbumCoverData = albumDTO.AlbumCoverData;
                existingAlbum.AlbumCoverContentType = albumDTO.AlbumCoverContentType;
                existingAlbum.Active = albumDTO.Active;
                return new Result { Success = true, Message = "Album updated successfully." };
            }
            return new Result { Success = false, Message = "Album not found." };
        }

		public Result DeleteAlbum(AlbumDTO albumDTO)
		{
			_mockAlbum.Remove(albumDTO);
			return new Result { Success = true, Message = "Album removed successfully." };
		}
	}
}
