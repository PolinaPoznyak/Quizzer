namespace Quizzer.Api.Models.Response.Users;

public class UserDeleteResponseModel
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string? FullName { get; set; }
    
    public string? ProfilePicture { get; set; }
}