namespace Infrastructure
{
    public interface IAlbumRepository
    {
        Result InsertAlbum(AlbumDTO albumDTO);

        List<AlbumDTO> GetRecentAlbum(int count);

        Result AddSongToAlbum(int albumID, int songID);

        Result RemoveSongFromAlbum(int albumID, int songID);
        List<AlbumDTO> GetAlbumsForUser(int userID);

        AlbumDTO GetAlbumByTitleAndArtist(string title, int artistId);
        int GetAlbumIDByAlbumTitle(string albumTitle);

		Result UpdateAlbum(AlbumDTO newAlbumDTO, AlbumDTO oldAlbumDTO);

        Result DeleteAlbum(AlbumDTO albumDTO);
    }
}