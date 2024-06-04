using Infrastructure;
using Infrastructure.DTOs;

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
                Artist artist = ConvertToArtist(artistDTO);
                artists.Add(artist);
            }
            return artists;
        }

        public List<Artist> GetArtistForUser(int userId)
        {
            List<Artist> artists = new List<Artist>();

            List<ArtistDTO> artistDTOs = _artistsRepository.GetArtistForUser(userId);

            foreach (var artistDTO in artistDTOs)
            {
                Artist artist = ConvertToArtist(artistDTO);
                artists.Add(artist);
            }
            return artists;
        }

        public Result Add(Artist artist)
        {
            ArtistDTO artistDTO = ConvertToArtistDTO(artist);

            Result resultArtist = _artistsRepository.InsertArtist(artistDTO);

            return resultArtist;
        }
        public Result Delete(Artist artist)
        {
            return _artistsRepository.DeleteArtist(ConvertToArtistDTO(artist));
        }

        public Result Update(Artist newArtist)
        {
            ArtistDTO artistDTO = ConvertToArtistDTO(newArtist);
            if (newArtist.ArtistID == 0)
            {
                return Add(newArtist);
            }

            Result resultUpdate = _artistsRepository.UpdateArtist(artistDTO);

            return resultUpdate;
        }

        private ArtistDTO ConvertToArtistDTO(Artist artist)
        {
            return new ArtistDTO(
                artist.ArtistID,
                artist.Name,
                artist.ArtistPictureName,
                artist.ArtistPictureData,
                artist.ArtistPictureContentType
            );
        }

        private Artist ConvertToArtist(ArtistDTO dto)
        {
            return new Artist(
                dto.ArtistID,
                dto.Name,
                dto.ArtistPictureName,
                dto.ArtistPictureData,
                dto.ArtistPictureContentType
            );
        }
    }
}
