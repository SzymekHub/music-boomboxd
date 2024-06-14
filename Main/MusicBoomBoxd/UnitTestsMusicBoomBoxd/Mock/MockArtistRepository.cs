using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
    public class MockArtistRepository : IArtistRepository
	{
		private readonly List<ArtistDTO> _mockArtist;
        private readonly List<KeyValuePair<int, int>> _UserToArtist;

        public MockArtistRepository(List<ArtistDTO> mockArtist, List<KeyValuePair<int, int>> UserFavArtists)
        {
			_mockArtist = mockArtist;
            _UserToArtist = UserFavArtists;
        }

        public Result InsertArtist(ArtistDTO artistDTO)
		{
            _mockArtist.Add(artistDTO);
			return new Result { Success = true, Message = "Artist inserted successfully." };
		}

		public List<ArtistDTO> GetAllArtists(int count)
		{
            return _mockArtist.Take(count).ToList();
        }

        public List<ArtistDTO> GetArtistForUser(int userID)
        {
            List<KeyValuePair<int, int>> artistIDs = _UserToArtist.Where(pair => pair.Key == userID).ToList();
            List<ArtistDTO> artists = new List<ArtistDTO>();
            foreach(KeyValuePair <int,int> artistID in artistIDs)
            {
                artists.Add(GetArtistByArtistID(artistID.Value));
            }

            return artists;
        }

        public ArtistDTO GetArtistByArtistID(int artistID)
		{
            return _mockArtist.FirstOrDefault(a => a.ArtistID == artistID);
        }

        public Result UpdateArtist(ArtistDTO artistDTO)
		{
            var existingArtist = _mockArtist.FirstOrDefault(a => a.ArtistID == artistDTO.ArtistID);
            if (existingArtist != null)
            {
                existingArtist.Name = artistDTO.Name;
                existingArtist.ArtistPictureName = artistDTO.ArtistPictureName;
                existingArtist.ArtistPictureData = artistDTO.ArtistPictureData;
                existingArtist.ArtistPictureContentType = artistDTO.ArtistPictureContentType;
                return new Result { Success = true, Message = "Artist updated successfully." };
            }
            return new Result { Success = false, Message = "Artist not found." };
        }

		public Result DeleteArtist(ArtistDTO artistDTO)
		{
            var artistToRemove = _mockArtist.FirstOrDefault(a => a.ArtistID == artistDTO.ArtistID && a.Name == artistDTO.Name);
            if (artistToRemove != null)
            {
                _mockArtist.Remove(artistToRemove);
                return new Result { Success = true, Message = "Artist removed successfully." };
            }
            return new Result { Success = false, Message = "Artist not found." };
        }
	}
}
