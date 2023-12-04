namespace Quizzer.Api.Models.Request.QuizSessionResult;

public class QuizSessionResultCreateRequestModel
{
    public Guid QuizSessionId { get; set; }
    
    public int? Score { get; set; }
}