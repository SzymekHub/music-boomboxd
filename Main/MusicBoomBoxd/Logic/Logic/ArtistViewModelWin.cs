using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
	public class ArtistViewModelWin
	{
		public int ArtistID { get; set; }
		public string Name { get; set; }
		public string ArtistPictureName { get; set; }
		public byte[] ArtistPictureData { get; set; }
		public string ArtistPictureContentType { get; set; }

		public ArtistViewModelWin(Artist artist)
		{
			ArtistID = artist.ArtistID;
			Name = artist.Name;
			ArtistPictureName = artist.ArtistPictureName;
			ArtistPictureData = artist.ArtistPictureData;
			ArtistPictureContentType = artist.ArtistPictureContentType;
		}

	}
}
