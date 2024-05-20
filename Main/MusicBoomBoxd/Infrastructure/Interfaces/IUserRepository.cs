using Infrastructure.DTOs;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Result InsertUser(UserDTO userDTO);

        List<UserDTO> GetRecentUsers(int count);

        Result UpdateUser(UserDTO newUserDTO, UserDTO oldUserDTO);

        Result DeleteUser(UserDTO userDTO);

    }
}