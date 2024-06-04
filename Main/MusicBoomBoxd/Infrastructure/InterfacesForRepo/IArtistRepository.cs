using Infrastructure.DTOs;

namespace Infrastructure
{
    public interface IArtistRepository
    {
        Result InsertArtist(ArtistDTO artistDTO);

        List<ArtistDTO> GetAllArtists(int count);

        List<ArtistDTO> GetArtistForUser(int userID);

        Result UpdateArtist(ArtistDTO artistDTO);

        Result DeleteArtist(ArtistDTO artistDTO);
    }
}