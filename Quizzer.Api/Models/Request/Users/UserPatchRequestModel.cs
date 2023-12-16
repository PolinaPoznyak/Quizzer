namespace Quizzer.Api.Models.Request.Users;

public class UserPatchRequestModel
{
    public Guid Id { get; set; }
    
    public bool IsDeleted { get; set; }
}