namespace Quizzer.Api.Models.Request.Users;

public class UserCreateRequestModel
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public bool confirmPassword { get; set; }
}