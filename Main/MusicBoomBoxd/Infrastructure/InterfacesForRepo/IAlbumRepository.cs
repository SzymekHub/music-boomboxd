namespace Infrastructure
{
    public interface IAlbumRepository
    {
        Result DeleteAlbum(AlbumDTO albumDTO);
        List<AlbumDTO> GetRecentAlbum(int count);
        Result InsertAlbum(AlbumDTO albumDTO);
        Result UpdateAlbum(AlbumDTO newAlbumDTO, AlbumDTO oldAlbumDTO);
    }
}