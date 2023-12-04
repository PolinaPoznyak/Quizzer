namespace Quizzer.Api.Models.Response.QuizSessionResult;

public class QuizSessionResultUpdateResponseModel
{
    public Guid Id { get; set; }
    //TODO: PUT QuizSession return 0000000
    public Guid UserId { get; set; }
    
    public Guid QuizSessionId { get; set; }
    
    public int? Score { get; set; }
}