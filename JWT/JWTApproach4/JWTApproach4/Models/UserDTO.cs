namespace JWTApproach4.Models
{
    public record UserDTO(string Username, string Password);


    public record UserRegisterDTO(string Username, string Password, List<string> Roles) : UserDTO(Username, Password);
    public record UserLoginDTO(string Username, string Password) : UserDTO(Username, Password);

}
