using Infrastructure.DTOs;

namespace Infrastructure
{
    public interface IArtistRepository
    {
        Result InsertArtist(ArtistDTO artistDTO);

        List<ArtistDTO> GetAllArtists(int count);

        Result UpdateArtist(ArtistDTO artistDTO);

        Result DeleteArtist(ArtistDTO artistDTO);
    }
}