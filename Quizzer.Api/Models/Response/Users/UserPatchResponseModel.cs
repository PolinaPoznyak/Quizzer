namespace Quizzer.Api.Models.Response.Users;

public class UserPatchResponseModel
{
    public Guid Id { get; set; }
    
    public bool IsDeleted { get; set; }
}