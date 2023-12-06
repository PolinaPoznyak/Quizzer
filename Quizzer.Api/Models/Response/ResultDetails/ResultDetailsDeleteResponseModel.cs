namespace Quizzer.Api.Models.Response.ResultDetails;

public class ResultDetailsDeleteResponseModel
{
    public Guid Id { get; set; }

    public Guid QuizSessionResultId { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public Guid QuizAnswerId { get; set; }
    
    public int IsCorrect { get; set; }
}