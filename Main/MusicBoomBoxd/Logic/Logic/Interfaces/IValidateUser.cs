
namespace Logic
{
    public interface IValidateUser
    {
        bool UsernameExists(string username);
        Dictionary<string, List<string>> ValidateUsers(string username);
    }
}