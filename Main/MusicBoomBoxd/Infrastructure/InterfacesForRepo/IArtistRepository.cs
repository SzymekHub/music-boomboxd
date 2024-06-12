
namespace Infrastructure
{
    public interface IArtistRepository
    {
        Result InsertArtist(ArtistDTO artistDTO);

        List<ArtistDTO> GetAllArtists(int count);

        List<ArtistDTO> GetArtistForUser(int userID);

        ArtistDTO GetArtistByArtistID(int artistID);

        Result UpdateArtist(ArtistDTO artistDTO);

        Result DeleteArtist(ArtistDTO artistDTO);
    }
}