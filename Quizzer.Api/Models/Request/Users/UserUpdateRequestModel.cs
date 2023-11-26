namespace Quizzer.Api.Models.Request.Users;

public class UserUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string? FullName { get; set; }
    
    public string? ProfilePicture { get; set; }
}