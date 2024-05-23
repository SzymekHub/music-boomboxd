using Infrastructure;
using Infrastructure.DTOs;

namespace Logic
{
    public class ArtistManager
    {
        private readonly ArtistRepository artistRepository;

        public ArtistManager(ArtistRepository repository)
        {
            artistRepository = repository;
        }

        public Result AddArtist(Artist artist)
        {
            ArtistDTO artistDTO = ConvertToArtistDTO(artist);
            return artistRepository.InsertArtist(artistDTO);
        }

        public Result UpdateArtist(Artist newArtist, Artist oldArtist)
        {
            ArtistDTO newArtistDTO = ConvertToArtistDTO(newArtist);
            ArtistDTO oldArtistDTO = ConvertToArtistDTO(oldArtist);
            return artistRepository.UpdateArtist(newArtistDTO, oldArtistDTO);
        }

        public Result DeleteArtist(Artist artist)
        {
            ArtistDTO artistDTO = ConvertToArtistDTO(artist);
            return artistRepository.DeleteArtist(artistDTO);
        }

        public List<Artist> GetAllArtists()
        {
            List<ArtistDTO> artistDTOs = artistRepository.GetAllArtists();
            List<Artist> artists = new List<Artist>();

            foreach (var dto in artistDTOs)
            {
                Artist artist = ConvertToArtist(dto);
                artists.Add(artist);
            }

            return artists;
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
