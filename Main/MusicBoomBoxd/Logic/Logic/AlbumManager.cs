using Infrastructure;

namespace Logic
{
    public class AlbumManager
    {
        public List<Album> _albums;
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ArtistManager _artistManager;
        private readonly IValidateAlbum _validateAlbum;
        private readonly Artist artist;

        public AlbumManager(IAlbumRepository ialbumRep, IArtistRepository iartRep, IValidateAlbum ivalidAlbum)
        {
            _albums = new List<Album>();
            _albumRepository = ialbumRep;
            _artistManager = new ArtistManager(iartRep);
            _artistRepository = iartRep;
            _validateAlbum = ivalidAlbum;
        }

        public List<Album> LoadAlbumsFromDatabase()
        {
            List<AlbumDTO> albumDTOs = _albumRepository.GetRecentAlbum(1000);
            _albums.Clear();

            foreach (var albumDTO in albumDTOs)
            {
                Artist artist = _artistManager.GetArtistByArtistID(albumDTO.ArtistID);

                if (artist != null)
                {
                    Album album = AlbumMapper.ToAlbum(albumDTO, artist);
                    album.Artist = artist;
                    _albums.Add(album);
                }
            }

            return _albums;
        }

        public List<Album> GetAlbumForUsers(int userID)
        {
            List<Album> albums = new List<Album>();

            List<AlbumDTO> albumDTOs = _albumRepository.GetAlbumsForUser(userID);

            foreach (var albumDTO in albumDTOs)
            {
                Album album = AlbumMapper.ToAlbum(albumDTO, artist);
                albums.Add(album);
            }

            return albums;
        }

        public Result SaveSongsInAlbums(int albumID, List<int> selectedSongIDs)
        {
            Result result = new Result();

            foreach (int songID in selectedSongIDs)
            {
                Result resultSongInAlbum = _albumRepository.AddSongToAlbum(albumID, songID);
                if (!resultSongInAlbum.Success)
                {
                    result.Success = false;
                    result.Message = "This song is already on this album";
                    return result;
                }
            }

            // If all songs are successfully added, return a success message
            result.Success = true;
            result.Message = "Successfully added the songs to this album.";
            return result;
        }

        public Result RemoveSongFromAlbum(int albumID, List<int> selectedSongIDs)
        {
            Result result = new Result();

            foreach (int songID in selectedSongIDs)
            {
                Result resultRemoveSongfromAlbum = _albumRepository.RemoveSongFromAlbum(albumID, songID);
                if (!resultRemoveSongfromAlbum.Success)
                {
                    result.Success = false;
                    result.Message = "This song is not on this album yet";
                    return result;
                }
            }

            // If all songs are successfully deleted, return a success message
            result.Success = true;
            result.Message = "Successfully removed the songs from this album.";
            return result;
        }

        public int GetAlbumIDByAlbumTitle(string albumTitle)
        {
            return _albumRepository.GetAlbumIDByAlbumTitle(albumTitle);
        }


		public Result Add(Album album)
        {
            AlbumDTO albumDTO = AlbumMapper.ToAlbumDTO(album);

            _albums.Add(album);

            Result resultAlbum = SendAlbumToTheDb(albumDTO);

            return resultAlbum;
        }
		public Result AddWEB(Album album)
		{
			AlbumDTO albumDTO = AlbumMapper.ToAlbumDTO(album);

			_albums.Add(album);

			Result resultAlbum = SendAlbumToTheDbWEB(albumDTO);

			return resultAlbum;
		}

		public bool Remove(Album album)
        {
            _albumRepository.DeleteAlbum(AlbumMapper.ToAlbumDTO(album));

            return _albums.Remove(album);
        }

        public Album[] GetArray()
        {
            return _albums.ToArray();
        }

        public Result Update(Album newAlbum, Album oldAlbum)
        {
            AlbumDTO newAlbumDTO = AlbumMapper.ToAlbumDTO(newAlbum);

            if (oldAlbum == null)
            {
                Result resultAdd = Add(newAlbum);
                return resultAdd;
            }
            else
            {
                AlbumDTO oldAlbumDTO = AlbumMapper.ToAlbumDTO(oldAlbum);

                // This calls the repository method to update the album
                Result resultupdate = _albumRepository.UpdateAlbum(newAlbumDTO, oldAlbumDTO);

                if (resultupdate.Success)
                {
                    LoadAlbumsFromDatabase();
                    // If the update was successful, this updates the album in the list
                    int index = _albums.FindIndex(a => a == oldAlbum);

                    if (index != -1)
                    {
                        _albums[index] = newAlbum;
                    }
                }

                return resultupdate;
            }
        }

        public Result SendAlbumToTheDb(AlbumDTO newAlbum)
        {
            return _albumRepository.InsertAlbum(newAlbum);
        }
		public Result SendAlbumToTheDbWEB(AlbumDTO newAlbum)
		{
			var errors = _validateAlbum.ValidateAlbums(newAlbum.AlbumTitle, newAlbum.ArtistID);
			if (errors.Any())
			{
				return new Result
				{
					Success = false,
					Errors = errors
				};
			}
			return _albumRepository.InsertAlbum(newAlbum);
		}
	}
}
