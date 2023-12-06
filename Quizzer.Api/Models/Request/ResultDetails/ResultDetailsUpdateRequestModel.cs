namespace Quizzer.Api.Models.Request.ResultDetails;

public class ResultDetailsUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public int IsCorrect { get; set; }
}