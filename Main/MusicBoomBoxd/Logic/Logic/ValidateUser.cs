using Infrastructure;


namespace Logic
{
    public class ValidateUser : IValidateUser
    {
        private readonly IUserRepository _userRepository;

        public ValidateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Dictionary<string, List<string>> ValidateUsers(string username)
        {
            var errors = new Dictionary<string, List<string>>();

            if (UsernameExists(username))
            {
                errors.TryAdd("username", new List<string>());
                errors["username"].Add("Username is already taken");
            }
            return errors;
        }

        public bool UsernameExists(string username)
        {
            UserDTO userDTO = _userRepository.GetUserByUsername(username);
            return userDTO != null;
        }
    }
}
