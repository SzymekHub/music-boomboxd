namespace Infrastructure
{
    public interface IAlbumRepository
    {
        Result InsertAlbum(AlbumDTO albumDTO);

        List<AlbumDTO> GetRecentAlbum(int count);

        Result UpdateAlbum(AlbumDTO newAlbumDTO, AlbumDTO oldAlbumDTO);

        Result DeleteAlbum(AlbumDTO albumDTO);
    }
}