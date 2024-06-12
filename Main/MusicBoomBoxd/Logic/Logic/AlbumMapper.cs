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
		AlbumDTO albumDTO = new();

		albumDTO.AlbumID = album.AlbumID;
		albumDTO.ArtistDTO = ArtistMapper.ConvertToArtistDTO(album.Artist);
		albumDTO.AlbumTitle = album.Title;
		albumDTO.ReleaseDate = album.Date;
		albumDTO.RunTime = album.RunTime;
		albumDTO.Genre = album.Genre.ToString();
		albumDTO.AlbumCoverName = album.AlbumCoverName;
		albumDTO.AlbumCoverData = album.AlbumCoverData;
		albumDTO.AlbumCoverContentType = album.AlbumCoverContentType;

		return albumDTO;
	}
}
