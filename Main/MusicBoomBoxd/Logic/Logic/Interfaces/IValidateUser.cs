
namespace Logic
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