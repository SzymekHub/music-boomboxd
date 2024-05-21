namespace Infrastructure
{
    public interface IUserRepository
    {
        Result InsertUser(UserDTO userDTO);

        List<UserDTO> GetRecentUser(int count);

        Result UpdateUser(UserDTO newUserDTO, UserDTO oldUserDTO);

        Result DeleteUser(UserDTO userDTO);

    }
}