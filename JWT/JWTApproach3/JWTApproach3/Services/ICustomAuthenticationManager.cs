namespace JWTApproach3.Services
{
    public interface ICustomAuthenticationManager
    {
        public string Authenticate(string userName, string password);
        public Dictionary<string, Tuple<string, string>> Tokens { get; }
    }
}
