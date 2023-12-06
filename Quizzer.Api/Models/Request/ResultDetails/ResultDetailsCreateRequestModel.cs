namespace Quizzer.Api.Models.Request.ResultDetails;

public class ResultDetailsCreateRequestModel
{
    public Guid QuizSessionResultId { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public Guid QuizAnswerId { get; set; }
    
    public int IsCorrect { get; set; }
}