namespace Quizzer.Api.Models.Request.QuizSessionResult;

public class QuizSessionResultUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public int? Score { get; set; }
}