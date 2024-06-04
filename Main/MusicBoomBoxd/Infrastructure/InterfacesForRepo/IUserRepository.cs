namespace Infrastructure
{
    public interface IUserRepository
    {
        Result InsertUser(UserDTO userDTO);

        List<UserDTO> GetRecentUser(int count);

        Result AddArtistToUser(int userID, int artistID);
        Result RemoveArtistFromUser(int userID, int artistID);

        UserDTO GetUserByUsername(string username);

        Result UpdateUser(UserDTO newUserDTO, UserDTO oldUserDTO);

        Result DeleteUser(UserDTO userDTO);

    }
}