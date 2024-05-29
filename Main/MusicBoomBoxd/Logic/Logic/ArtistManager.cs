using Infrastructure;
using Infrastructure.DTOs;

namespace Logic
{
    public class ArtistManager
    {
        public readonly IArtistRepository _artistsRepository;

        public ArtistManager(IArtistRepository iArtRep)
        {
            _artistsRepository = iArtRep;
        }

        //cmd.Connection = conn;
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = @"INSERT INTO [Artist] (ArtistID, Name, ArtistPictureName, ArtistPictureData, ArtistPictureContentType) 
        //                    VALUES (@ArtistID, @Name, @ArtistPictureName, @ArtistPictureData, @ArtistPictureContentType); 
        //                    SELECT SCOPE_IDENTITY();";

        //cmd.Parameters.AddWithValue("@Name", artistDTO.Name);
        //cmd.Parameters.AddWithValue("@ArtistPictureName", artistDTO.ArtistPictureName);
        //cmd.Parameters.AddWithValue("@ArtistPictureData", artistDTO.ArtistPictureData);
        //cmd.Parameters.AddWithValue("@ArtistPictureContentType", artistDTO.ArtistPictureContentType);


        public List<Artist> LoadArtistFromDB()
        {
            List<Artist> artists = new();

            List<ArtistDTO> artistDTOs = _artistsRepository.GetAllArtists();

            foreach (var artistDTO in artistDTOs)
            {
                Artist artist = ConvertToArtist(artistDTO);
                artists.Add(artist);
            }
            return artists;
        }

        public Result Add(Artist artist)
        {
            ArtistDTO artistDTO = ConvertToArtistDTO(artist);

            Result resultArtist = _artistsRepository.InsertArtist(artistDTO);

            return resultArtist;
        }
        public Result Delete(Artist artist)
        {
            return _artistsRepository.DeleteArtist(ConvertToArtistDTO(artist));
        }

        public Result Update(Artist newArtist)
        {
            ArtistDTO artistDTO = ConvertToArtistDTO(newArtist);

            Result resultUpdate = _artistsRepository.UpdateArtist(artistDTO);

            return resultUpdate;
        }

        private ArtistDTO ConvertToArtistDTO(Artist artist)
        {
            return new ArtistDTO(
                artist.ArtistID,
                artist.Name,
                artist.ArtistPictureName,
                artist.ArtistPictureData,
                artist.ArtistPictureContentType
            );
        }

        private Artist ConvertToArtist(ArtistDTO dto)
        {
            return new Artist(
                dto.ArtistID,
                dto.Name,
                dto.ArtistPictureName,
                dto.ArtistPictureData,
                dto.ArtistPictureContentType
            );
        }
    }
}
