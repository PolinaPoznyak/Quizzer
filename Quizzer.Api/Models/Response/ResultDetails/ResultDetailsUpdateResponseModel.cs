namespace Quizzer.Api.Models.Response.ResultDetails;

public class ResultDetailsUpdateResponseModel
{
    public Guid Id { get; set; }
    
    public int IsCorrect { get; set; }
}