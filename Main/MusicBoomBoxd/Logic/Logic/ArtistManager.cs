using Infrastructure;
using Logic;

namespace Logic
{
    public class ArtistManager
    {
        public List<Artist> Artists;
        private readonly IArtistRepository _artistsRepository;
        private readonly User user;

        public ArtistManager(IArtistRepository iArtRep)
        {
            Artists = new List<Artist>();
            _artistsRepository = iArtRep;
        }

        public List<Artist> LoadArtistFromDB()
        {
            List<Artist> artists = new();

            List<ArtistDTO> artistDTOs = _artistsRepository.GetAllArtists(1000);

            foreach (var artistDTO in artistDTOs)
            {
                Artist artist = ArtistMapper.ConvertToArtist(artistDTO);
                artists.Add(artist);
            }
            return artists;
        }

        public Artist GetArtistByArtistID(int artistID) 
        {
            ArtistDTO artistDTO = _artistsRepository.GetArtistByArtistID(artistID);
            Artist artist = ArtistMapper.ConvertToArtist(artistDTO);
            return artist;
        }

        public List<Artist> GetArtistForUser(int userId)
        {
            List<Artist> artists = new List<Artist>();

            List<ArtistDTO> artistDTOs = _artistsRepository.GetArtistForUser(userId);

            foreach (var artistDTO in artistDTOs)
            {
                Artist artist = ArtistMapper.ConvertToArtist(artistDTO);
                artists.Add(artist);
            }
            return artists;
        }

        public Result Add(Artist artist)
        {
            ArtistDTO artistDTO = ArtistMapper.ConvertToArtistDTO(artist);

            Result resultArtist = _artistsRepository.InsertArtist(artistDTO);

            return resultArtist;
        }
        public Result Delete(Artist artist)
        {
            return _artistsRepository.DeleteArtist(ArtistMapper.ConvertToArtistDTO(artist));
        }

        public Result Update(Artist newArtist)
        {
            ArtistDTO artistDTO = ArtistMapper.ConvertToArtistDTO(newArtist);
            if (newArtist.ArtistID == 0)
            {
                return Add(newArtist);
            }

            Result resultUpdate = _artistsRepository.UpdateArtist(artistDTO);

            return resultUpdate;
        }
    }
}

