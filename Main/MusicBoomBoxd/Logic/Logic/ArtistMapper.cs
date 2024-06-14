using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class ArtistMapper
	{
		public static Artist ConvertToArtist(ArtistDTO artistDTO)
		{
			 Artist artist = new(
				artistDTO.ArtistID,
				artistDTO.Name,
				artistDTO.ArtistPictureName,
				artistDTO.ArtistPictureData,
				artistDTO.ArtistPictureContentType
			);
			return artist;
		}
		public static ArtistDTO ConvertToArtistDTO(Artist artist)
		{
			ArtistDTO artistDTO = new();

			artistDTO.ArtistID = artist.ArtistID;
			artistDTO.Name = artist.Name;
			artistDTO.ArtistPictureName = artist.ArtistPictureName;
			artistDTO.ArtistPictureData = artist.ArtistPictureData;
			artistDTO.ArtistPictureContentType = artist.ArtistPictureContentType;

			return artistDTO;

		}
	}
}
