using Infrastructure;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;
using Infrastructure.DTOs;

public static class AlbumMapper
{
	public static Album ToAlbum(AlbumDTO albumDTO)
	{
		if (albumDTO == null)
		{
			return null;
		}
		return new Album(
			albumDTO.AlbumID,
			ArtistMapper.ConvertToArtist(albumDTO.ArtistDTO),
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
        if (album == null)
        {
            return null;
        }
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
