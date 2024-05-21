using Infrastructure;

namespace Logic
{
    public class AlbumManager
    {
        public List<Album> _albums;
        private readonly AlbumRepository _albumRepository;
        private readonly IAlbumRepository _ialbumRepository;

        public AlbumManager(AlbumRepository albumRep, IAlbumRepository ialbumRep)
        {
            _albums = new List<Album>();
            _albumRepository = albumRep;
            _ialbumRepository = ialbumRep;
        }

        public void LoadAlbumsFromDatabase()
        {
            List<AlbumDTO> albumDTOs = _albumRepository.GetRecentAlbum(1000);
            
            _albums.Clear();
            
            foreach (var albumDTO in albumDTOs)
            {
                // This converts AlbumDTO to Album and adds to the albums list
                Album album = ConvertToAlbum(albumDTO);
                _albums.Add(album);
            }
        }

        public Result Add(Album album)
        {
            AlbumDTO albumDTO = ConvertToAlbumDTO(album);

            _albums.Add(album);

            Result resultfailed = new Result { Success = false, Message = "" };

            Result resultAlbum = SendAlbumToTheDb(albumDTO);

            if (resultfailed.Success == false)
            {
                return resultfailed;
            }
            else
            {
                return resultAlbum;
            }
        }

        public bool Remove(Album album)
        {
            _albumRepository.DeleteAlbum(ConvertToAlbumDTO(album));
            return _albums.Remove(album);
        }

        public Album[] GetArray()
        {
            return _albums.ToArray();
        }

        public Result Update(Album newAlbum, Album oldAlbum)
        {
            AlbumDTO newAlbumDTO = ConvertToAlbumDTO(newAlbum);

            AlbumDTO oldAlbumDTO = ConvertToAlbumDTO(oldAlbum);

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
            else
            {
                Console.WriteLine("Looks like something went wrong when updating the album in the database :(");
            }

            return resultupdate;
        }

        public Result SendAlbumToTheDb(AlbumDTO newAlbum)
        {
            return _albumRepository.InsertAlbum(newAlbum);
        }

        public Album ConvertToAlbum(AlbumDTO newAlbumDTO)
        {
            genreType genre = (genreType)Enum.Parse(typeof(genreType), newAlbumDTO.Genre);

            // This converts AlbumDTO to Album
            return new Album(
                newAlbumDTO.AlbumID,
                newAlbumDTO.AlbumTitle,
                newAlbumDTO.Artist,
                newAlbumDTO.ReleaseDate,
                genre,
                newAlbumDTO.AlbumCoverName,
                newAlbumDTO.AlbumCoverData,
                newAlbumDTO.AlbumCoverContentType
            );
        }

        public AlbumDTO ConvertToAlbumDTO(Album album)
        {
            // this converts Album to AlbumDTO
            return new AlbumDTO(
                album.AlbumID,
                album.Title,
                album.Artist,
                album.Date,
                album.Genre.ToString(),
                album.AlbumCoverName,
                album.AlbumCoverData,
                album.AlbumCoverContentType
            );
        }
    }
}
