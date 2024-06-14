using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Infrastructure;
using Logic.Interfaces;
using Logic.Algorithms;
using Infrastructure.DTOs;

namespace Logic.Interfaces
{
    public interface IValidateUser
    {
		Dictionary<string, List<string>> ValidateUsers(string username);

		Dictionary<string, List<string>> ValidateUsersWEB(User user);

		bool IsUsernameOrEmailTaken(string username, string email, int userId);

		bool UsernameExists(string username);

        bool EmailExists(string email);
    }
}