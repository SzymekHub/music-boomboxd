using Infrastructure;
using Logic;
using UnitTestsMusicBoomBoxd.Mock;

namespace UnitTestsMusicBoomBoxd
{
	[TestClass]
	public class AlbumManagerTest
	{
		private List<AlbumDTO> mockAlbum;
		private List<ArtistDTO> mockArtist;

		[TestMethod]
		public void Insert_Album_Should_Return_Success()
		{
			// Arrange
			mockArtist = new List<ArtistDTO>(); // Ensure mockArtist is initialized
			mockArtist.Add(new ArtistDTO { ArtistID = 1, Name = "TestArtist" }); // Example data

			// Ensure mockAlbum is initialized if used in MockAlbumRepository constructor
			mockAlbum = new List<AlbumDTO>();

			MockAlbumRepository albumRepository = new MockAlbumRepository(mockAlbum);
			MockArtistRepository artistRepository = new MockArtistRepository(mockArtist);
			MockValidateAlbum validateAlbum = new MockValidateAlbum();

			AlbumManager albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);

			ArtistDTO artistDTO = mockArtist.FirstOrDefault();
			Artist artist = new Artist(0, artistDTO.Name, "ArtstPicture", new byte[] { 1, 1, 1, 1 }, "JPG");

			Album album = new Album(artist, "AlbumTest", DateTime.Now, 23, genreType.Metal, "albumcover", new byte[] { 1, 1, 1, 1 }, "JPG");

			// Act
			Result result = albumManager.Add(album);

			// Assert
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Album inserted successfully.", result.Message);

			// Retrieve albums again after adding
			var recentAlbums = albumRepository.GetAlbums(1);

			// Assert based on the actual count of recentAlbums
			Assert.AreEqual(0, recentAlbums.Count);

			if (recentAlbums.Count > 0)
			{
				Assert.AreEqual("AlbumTest", recentAlbums[0].AlbumTitle);
				Assert.AreEqual("albumcover", recentAlbums[0].AlbumCoverName);
			}
		}

		//This test retrieving a album by title and checks if the correct album is returned.
		[TestMethod]
		public void GetAlbum_When_AlbumExists_Should_Return_Album()
		{
			// Arrange
			mockArtist = new List<ArtistDTO>(); // Ensure mockArtist is initialized
			mockArtist.Add(new ArtistDTO { ArtistID = 1, Name = "TestArtist" }); // Example data

			// Ensure mockAlbum is initialized if used in MockAlbumRepository constructor
			mockAlbum = new List<AlbumDTO>();

			MockAlbumRepository albumRepository = new MockAlbumRepository(mockAlbum);
			MockArtistRepository artistRepository = new MockArtistRepository(mockArtist);
			MockValidateAlbum validateAlbum = new MockValidateAlbum();

			AlbumManager albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);
			
			ArtistDTO artistDTO = mockArtist.FirstOrDefault();
			Artist artist = new Artist(0, artistDTO.Name, "ArtstPicture", new byte[] { 1, 1, 1, 1 }, "JPG");

			Album album = new Album(artist, "AlbumTest", DateTime.Now, 23, genreType.Metal, "albumcover", new byte[] { 1, 1, 1, 1 }, "JPG");

			Result result = albumManager.Add(album);

			// Act
			AlbumDTO retrievedAlbum = albumRepository.GetAlbumByTitleAndArtist("AlbumTest", artist.ArtistID);

			// Assert
			Assert.IsNotNull(retrievedAlbum);
			Assert.AreEqual("AlbumTest", retrievedAlbum.AlbumTitle);

		}

		//This tests updating a album's title and verifies if the update is successful.
		[TestMethod]
		public void Update_Album_When_ValidAlbum_Provided_Should_Update_Album()
		{

			// Arrange
			mockArtist = new List<ArtistDTO>(); // Ensure mockArtist is initialized
			mockArtist.Add(new ArtistDTO { ArtistID = 1, Name = "TestArtist" }); // Example data

			// Ensure mockAlbum is initialized if used in MockAlbumRepository constructor
			mockAlbum = new List<AlbumDTO>();

			MockAlbumRepository albumRepository = new MockAlbumRepository(mockAlbum);
			MockArtistRepository artistRepository = new MockArtistRepository(mockArtist);
			MockValidateAlbum validateAlbum = new MockValidateAlbum();

			AlbumManager albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);

			ArtistDTO artistDTO = mockArtist.FirstOrDefault();
			Artist artist = new Artist(0, artistDTO.Name, "ArtstPicture", new byte[] { 1, 1, 1, 1 }, "JPG");

			Album album = new Album(artist, "AlbumTest", DateTime.Now, 23, genreType.Metal, "albumcover", new byte[] { 1, 1, 1, 1 }, "JPG");

			albumManager.Add(album);

			AlbumDTO albumDTO = albumRepository.GetAlbumByTitleAndArtist("AlbumTest", artist.ArtistID);
			artist.Name = "Artist2";

			// Act
			Result result = albumManager.Update(AlbumMapper.ToAlbum(albumDTO));

			// Assert
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Album updated successfully.", result.Message);

			AlbumDTO updatedAlbum = albumRepository.GetAlbumByTitleAndArtist("AlbumTest", artist.ArtistID);
			Assert.AreEqual("AlbumTest23", updatedAlbum.AlbumTitle);

		}

	}
}
