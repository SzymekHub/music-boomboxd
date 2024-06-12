namespace Infrastructure
{
    public interface IUserRepository
    {
        Result InsertUser(UserDTO userDTO);

        List<UserDTO> GetRecentUser(int count);

        //for artists
        #region Artist
        Result AddArtistToUser(int userID, int artistID);
        Result RemoveArtistFromUser(int userID, int artistID);
        #endregion

        //For songs
        #region Songs
        Result AddSongToUser(int userID, int songID);

        Result RemoveSongFromUser(int userID, int songID);
        #endregion

        //For albums
        #region Albums
        Result AddAlbumToUser(int userID, int albumID);

        Result RemoveAlbumFromUser(int userID, int albumID);
        #endregion

        UserDTO GetUserByUsername(string username);
        UserDTO GetUserByEmail(string email);

        Result UpdateUser(UserDTO userDTO);

		Result UpdateUserRoleToCritic(UserDTO userDTO);

        Result UpdateUserRoleToMusician(UserDTO userDTO);

        Result DeleteUser(UserDTO userDTO);

    }
}