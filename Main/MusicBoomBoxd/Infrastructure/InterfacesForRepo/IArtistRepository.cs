using Infrastructure.DTOs;

namespace Infrastructure
{
    public interface IArtistRepository
    {
        List<ArtistDTO> GetAllArtists();
        Result InsertArtist(ArtistDTO artistDTO);
    }
}