using Infrastructure.DTOs;
using Logic;

namespace UnitTestsMusicBoomBoxd.Tests
{
    [TestClass]
    public class AlbumMapperTest
    {
        [TestMethod]
        public void ConvertToAlbum_When_ValidAlbumDTO_Provided_Should_Return_Album()
        {
            // Arrange
            var albumDTO = new AlbumDTO
            {
                AlbumID = 1,
                Active = true,
                ArtistDTO = new ArtistDTO
                {
                    ArtistID = 1,
                    Name = "TestArtist",
                    Active = true,
                    ArtistPictureName = "ProfilePicTest",
                    ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                    ArtistPictureContentType = "JPG",
                },
                AlbumTitle = "TestAlbum",
                ReleaseDate = DateTime.Now,
                RunTime = 3232,
                Genre = "Metal",
                AlbumCoverName = "AlbumCoverTest",
                AlbumCoverData = new byte[] { 1, 1, 1, 1 },
                AlbumCoverContentType = "JPG",
            };

            // Act
            var album = AlbumMapper.ToAlbum(albumDTO);

            // Assert
            Assert.IsNotNull(album);
            Assert.AreEqual(albumDTO.AlbumID, album.AlbumID);
            Assert.AreEqual(albumDTO.ArtistDTO.Name, album.Artist.Name);
            Assert.AreEqual(albumDTO.AlbumTitle, album.Title);
            Assert.AreEqual(albumDTO.ReleaseDate, album.Date);
            Assert.AreEqual(albumDTO.RunTime, album.RunTime);
            Assert.AreEqual(albumDTO.Genre, album.Genre.ToString());
            Assert.AreEqual(albumDTO.AlbumCoverName, album.AlbumCoverName);
            Assert.AreEqual(albumDTO.AlbumCoverData, album.AlbumCoverData);
            Assert.AreEqual(albumDTO.AlbumCoverContentType, album.AlbumCoverContentType);
        }

        [TestMethod]
        public void ConvertToAlbum_When_NullAlbumDTO_Provided_Should_Return_Null()
        {
            // Arrange
            AlbumDTO albumDTO = null;

            // Act
            var album = AlbumMapper.ToAlbum(albumDTO);

            // Assert
            Assert.IsNull(album);
        }

        [TestMethod]
        public void ConvertToAlbumDTO_When_ValidAlbum_Provided_Should_Return_AlbumDTO()
        {
            // Arrange
            var album = new Album(
                1,
                new Artist("Test Artist", "ArtistProfilePic", new byte[] { 1, 1, 1, 1 }, "JPG"),
                "TestAlbu",
                DateTime.Now,
                3232,
                genreType.Rap,
                "AlbumCoverTest",
                new byte[] { 1, 1, 1, 1 },
                "JPG" 
                );

            // Act
            var albumDTO = AlbumMapper.ToAlbumDTO(album);

            // Assert
            Assert.IsNotNull(albumDTO);
            Assert.AreEqual(album.AlbumID, albumDTO.AlbumID);
            Assert.AreEqual(album.Artist.Name, albumDTO.ArtistDTO.Name);
            Assert.AreEqual(album.Title, albumDTO.AlbumTitle);
            Assert.AreEqual(album.Date, albumDTO.ReleaseDate);
            Assert.AreEqual(album.RunTime, albumDTO.RunTime);
            Assert.AreEqual(album.Genre.ToString(), albumDTO.Genre);
            Assert.AreEqual(album.AlbumCoverName, albumDTO.AlbumCoverName);
            Assert.AreEqual(album.AlbumCoverData, albumDTO.AlbumCoverData);
            Assert.AreEqual(album.AlbumCoverContentType, albumDTO.AlbumCoverContentType);
        }

        [TestMethod]
        public void ConvertToAlbumDTO_When_NullAlbum_Provided_Should_Return_Null()
        {
            // Arrange
            Album album = null;

            // Act
            var albumDTO = AlbumMapper.ToAlbumDTO(album);

            // Assert
            Assert.IsNull(albumDTO);
        }
    }
}
