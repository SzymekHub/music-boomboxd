using Infrastructure;

namespace Logic
{
    public class AlbumManager
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ArtistManager _artistManager;
        private readonly IValidateAlbum _validateAlbum;
        private readonly Artist artist;

        public AlbumManager(IAlbumRepository ialbumRep, IArtistRepository iartRep, IValidateAlbum ivalidAlbum)
        {
            _albumRepository = ialbumRep;
            _artistManager = new ArtistManager(iartRep);
            _artistRepository = iartRep;
            _validateAlbum = ivalidAlbum;
        }

        public List<Album> LoadAlbumsFromDatabase()
        {
            List<Album> albums = new();
            List<AlbumDTO> albumDTOs = _albumRepository.GetAlbums(1000);

            foreach (var albumDTO in albumDTOs)
            {
                Artist artist = _artistManager.GetArtistByArtistID(albumDTO.ArtistDTO.ArtistID);

                if (artist != null)
                {
                    Album album = AlbumMapper.ToAlbum(albumDTO);
                    album.Artist = artist;
                    albums.Add(AlbumMapper.ToAlbum(albumDTO));
                }
            }

            return albums;
        }

        public List<Album> GetAlbumForUsers(int userID)
        {
            List<Album> albums = new List<Album>();

            List<AlbumDTO> albumDTOs = _albumRepository.GetAlbumsForUser(userID);

            foreach (var albumDTO in albumDTOs)
            {
                Artist artist = _artistManager.GetArtistByArtistID(albumDTO.ArtistDTO.ArtistID);

                if (artist != null)
                {
                    Album album = AlbumMapper.ToAlbum(albumDTO);
                    album.Artist = artist;
                    albums.Add(album);
                }
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

        public Album GetAlbumByAlbumID(int albumID)
        {
            AlbumDTO albumDTO = _albumRepository.GetAlbumByAlbumID(albumID);
            return AlbumMapper.ToAlbum(albumDTO);
        }

        public Result Add(Album album)
        {
            AlbumDTO albumDTO = AlbumMapper.ToAlbumDTO(album);

            Result resultAlbum = SendAlbumToTheDb(albumDTO);

            return resultAlbum;
        }
        public Result AddWEB(Album album)
        {
            AlbumDTO albumDTO = AlbumMapper.ToAlbumDTO(album);

            Result resultAlbum = SendAlbumToTheDbWEB(albumDTO);

            return resultAlbum;
        }

        public Result Remove(Album album)
        {
            Result resultRemoveAlbum = _albumRepository.DeleteAlbum(AlbumMapper.ToAlbumDTO(album));

            return resultRemoveAlbum;
        }

        public Result Update(Album newAlbum)
        {
            AlbumDTO albumDTO = AlbumMapper.ToAlbumDTO(newAlbum);

            if (newAlbum.AlbumID == 0)
            {
                return Add(newAlbum);
            }

            Result resultUpdate = _albumRepository.UpdateAlbum(albumDTO);

            return resultUpdate;
           
        }

        public Result SendAlbumToTheDb(AlbumDTO newAlbum)
        {
            return _albumRepository.InsertAlbum(newAlbum);
        }
        public Result SendAlbumToTheDbWEB(AlbumDTO newAlbum)
        {
            var errors = _validateAlbum.ValidateAlbums(newAlbum.AlbumTitle, newAlbum.ArtistDTO.ArtistID);
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
