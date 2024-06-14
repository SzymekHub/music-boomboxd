using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.DTOs;
using Logic;
using System;
using System.Collections.Generic;
using UnitTestsMusicBoomBoxd.Mock;
using Logic.Interfaces;
using Infrastructure.Repositories;
using Infrastructure;

namespace UnitTestsMusicBoomBoxd.Tests
{
    [TestClass]
    public class AlbumManagerTest
    {
        [TestMethod]
        public void Insert_Album_Should_Return_Success()
        {
            // Arrange
            var mockAlbum = new List<AlbumDTO>();
            var mockArtist = new List<ArtistDTO>
            {
                new ArtistDTO
                {
                    Active = true,
                    ArtistID = 1,
                    Name = "TestArtist",
                    ArtistPictureName = "ArtistProfilePic",
                    ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                    ArtistPictureContentType = "JPG"
                }
            };

            MockAlbumRepository albumRepository = new MockAlbumRepository(mockAlbum);
            MockArtistRepository artistRepository = new MockArtistRepository(mockArtist);
            MockValidateAlbum validateAlbum = new MockValidateAlbum();

            AlbumManager albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);

            ArtistDTO artistDTO = mockArtist.First();
            Artist artist = new Artist(1, artistDTO.Name, "ArtistPicture", new byte[] { 1, 1, 1, 1 }, "JPG");

            Album album = new Album(artist, "AlbumTest", DateTime.Now, 23, genreType.Metal, "albumcover", new byte[] { 1, 1, 1, 1 }, "JPG");

            // Act
            Result result = albumManager.Add(album);

            // Assert
            Assert.IsTrue(result.Success);
            var recentAlbums = albumRepository.GetAlbums(1);
            Assert.AreEqual(1, recentAlbums.Count);
            Assert.AreEqual("AlbumTest", recentAlbums[0].AlbumTitle);
            Assert.AreEqual("albumcover", recentAlbums[0].AlbumCoverName);
        }

        [TestMethod]
        public void GetAlbum_When_AlbumExists_Should_Return_Album()
        {
            // Arrange
            var mockAlbum = new List<AlbumDTO>
            {
                new AlbumDTO
                {
                    AlbumID = 1,
                    AlbumTitle = "AlbumTest",
                    ReleaseDate = DateTime.Now,
                    RunTime = 23,
                    Genre = "Metal",
                    AlbumCoverName = "albumcover",
                    AlbumCoverData = new byte[] { 1, 1, 1, 1 },
                    AlbumCoverContentType = "JPG",
                    ArtistDTO = new ArtistDTO
                    {
                        ArtistID = 1,
                        Name = "TestArtist",
                        ArtistPictureName = "ArtistProfilePic",
                        ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                        ArtistPictureContentType = "JPG"
                    }
                }
            };

            var mockArtist = new List<ArtistDTO>
            {
                new ArtistDTO
                {
                    Active = true,
                    ArtistID = 1,
                    Name = "TestArtist",
                    ArtistPictureName = "ArtistProfilePic",
                    ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                    ArtistPictureContentType = "JPG"
                }
            };

            MockAlbumRepository albumRepository = new MockAlbumRepository(mockAlbum);
            MockArtistRepository artistRepository = new MockArtistRepository(mockArtist);
            MockValidateAlbum validateAlbum = new MockValidateAlbum();

            AlbumManager albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);

            ArtistDTO artistDTO = mockArtist.First();
            Artist artist = new Artist(1, artistDTO.Name, "ArtistPicture", new byte[] { 1, 1, 1, 1 }, "JPG");

            Album album = new Album(artist, "AlbumTest", DateTime.Now, 23, genreType.Metal, "albumcover", new byte[] { 1, 1, 1, 1 }, "JPG");
            albumManager.Add(album);

            // Act
            AlbumDTO retrievedAlbum = albumRepository.GetAlbumByTitleAndArtist("AlbumTest", artist.ArtistID);

            // Assert
            Assert.IsNotNull(retrievedAlbum);
            Assert.AreEqual("AlbumTest", retrievedAlbum.AlbumTitle);
        }

        [TestMethod]
        public void Update_Album_When_ValidAlbum_Provided_Should_Update_Album()
        {
            // Arrange
            var mockAlbum = new List<AlbumDTO>
            {
                new AlbumDTO
                {
                    AlbumID = 1,
                    AlbumTitle = "AlbumTest",
                    ReleaseDate = DateTime.Now,
                    RunTime = 23,
                    Genre = "Metal",
                    AlbumCoverName = "albumcover",
                    AlbumCoverData = new byte[] { 1, 1, 1, 1 },
                    AlbumCoverContentType = "JPG",
                    ArtistDTO = new ArtistDTO
                    {
                        ArtistID = 1,
                        Name = "TestArtist",
                        ArtistPictureName = "ArtistProfilePic",
                        ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                        ArtistPictureContentType = "JPG"
                    }
                }
            };

            var mockArtist = new List<ArtistDTO>
            {
                new ArtistDTO
                {
                    Active = true,
                    ArtistID = 1,
                    Name = "TestArtist",
                    ArtistPictureName = "ArtistProfilePic",
                    ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                    ArtistPictureContentType = "JPG"
                }
            };

            MockAlbumRepository albumRepository = new MockAlbumRepository(mockAlbum);
            MockArtistRepository artistRepository = new MockArtistRepository(mockArtist);
            MockValidateAlbum validateAlbum = new MockValidateAlbum();

            AlbumManager albumManager = new AlbumManager(albumRepository, artistRepository, validateAlbum);

            AlbumDTO albumDTO = albumRepository.GetAlbumByTitleAndArtist("AlbumTest", 1);
            albumDTO.AlbumTitle = "AlbumTestUpdated";

            // Act
            Result result = albumManager.Update(AlbumMapper.ToAlbum(albumDTO));

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Album updated successfully.", result.Message);

            AlbumDTO updatedAlbum = albumRepository.GetAlbumByTitleAndArtist("AlbumTestUpdated", 1);
            Assert.AreEqual("AlbumTestUpdated", updatedAlbum.AlbumTitle);
        }
    }
}
