using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
    public class MockArtistRepository : IArtistRepository
	{
		private Dictionary<int, ArtistDTO> artists = new();
		private readonly List<ArtistDTO> _mockArtist;

        public MockArtistRepository(List<ArtistDTO> mockArtist)
        {
			_mockArtist = mockArtist;
        }

        public Result InsertArtist(ArtistDTO artistDTO)
		{
			artists.Add(artistDTO.ArtistID, artistDTO);
			return new Result { Success = true, Message = "Artist inserted successfully." };
		}

		public List<ArtistDTO> GetAllArtists(int count)
		{
			return _mockArtist;
		}

		public List<ArtistDTO> GetArtistForUser(int userID)
		{
			throw new NotImplementedException();

		}

		public ArtistDTO GetArtistByArtistID(int artistID)
		{
			throw new NotImplementedException();

		}

		public Result UpdateArtist(ArtistDTO artistDTO)
		{
			if (artists.ContainsKey(artistDTO.ArtistID))
			{
				artists[artistDTO.ArtistID] = artistDTO;
				return new Result { Success = true, Message = "Artist updated successfully." };
			}
			return new Result { Success = false, Message = "Artist not found." };
		}

		public Result DeleteArtist(ArtistDTO artistDTO)
		{
			artists.Remove(artistDTO.ArtistID);
			return new Result { Success = true, Message = "Artist removed successfully." };
		}
	}
}
