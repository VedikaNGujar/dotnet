using JWTApproach3.Models;

namespace JWTApproach3.Services
{
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        private IConfiguration configuration;

        public CustomAuthenticationManager(
            IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly IList<User> users = new List<User>()
        {
            new User("Vedika","Vedika@123","Admin" ),
            new User("Nidhi","Nidhi@123" ,"User")
        };

        private readonly Dictionary<string, Tuple<string, string>> tokens = new();
        public Dictionary<string, Tuple<string, string>> Tokens => tokens;

        public string Authenticate(string username, string password)
        {
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user is null)
            {
                return null;
            }
            var token = Guid.NewGuid().ToString();
            tokens[token] = new Tuple<string, string>(user.Username, user.Role);
            return token;
        }

    }
}
