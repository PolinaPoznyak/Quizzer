namespace Quizzer.Api.Models.Response.QuizSessionResult;

public class QuizSessionResultGetResponseModel
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid QuizSessionId { get; set; }
    
    public int? Score { get; set; }
}