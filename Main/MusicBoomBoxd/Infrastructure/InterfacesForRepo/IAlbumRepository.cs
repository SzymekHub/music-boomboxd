namespace Infrastructure
{
    public interface IAlbumRepository
    {
        Result InsertAlbum(AlbumDTO albumDTO);

        List<AlbumDTO> GetAlbums(int count);

        Result AddSongToAlbum(int albumID, int songID);

        Result RemoveSongFromAlbum(int albumID, int songID);

        List<AlbumDTO> GetAlbumsForUser(int userID);

        AlbumDTO GetAlbumByTitleAndArtist(string title, int artistId);

        int GetAlbumIDByAlbumTitle(string albumTitle);

        Result AddAverageRating(AlbumDTO albumDTO, double averageRating);

        Result UpdateAlbum(AlbumDTO albumDTO);

		Result DeleteAlbum(AlbumDTO albumDTO);
    }
}