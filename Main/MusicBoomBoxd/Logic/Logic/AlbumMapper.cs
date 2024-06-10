using Infrastructure;
using Logic;

public static class AlbumMapper
{
    public static Album ToAlbum(AlbumDTO albumDTO, Artist artist)
    {
        return new Album(
            albumDTO.AlbumID,
            artist,
            albumDTO.AlbumTitle,
            albumDTO.ReleaseDate,
            albumDTO.RunTime,
            (genreType)Enum.Parse(typeof(genreType), albumDTO.Genre),
            albumDTO.AlbumCoverName,
            albumDTO.AlbumCoverData,
            albumDTO.AlbumCoverContentType);
    }

    public static AlbumDTO ToAlbumDTO(Album album)
    {
        return new AlbumDTO(
            album.AlbumID,
            album.Artist.ArtistID,
            album.Title,
            album.Date,
            album.RunTime,
            album.Genre.ToString(),
            album.AlbumCoverName,
            album.AlbumCoverData,
            album.AlbumCoverContentType);
    }
}
