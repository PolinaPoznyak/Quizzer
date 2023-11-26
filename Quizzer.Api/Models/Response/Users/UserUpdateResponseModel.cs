namespace Quizzer.Api.Models.Response.Users;

public class UserUpdateResponseModel
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string? FullName { get; set; }
    
    public string? ProfilePicture { get; set; }
}