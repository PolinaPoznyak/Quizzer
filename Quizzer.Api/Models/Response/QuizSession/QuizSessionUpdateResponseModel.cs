using Quizzer.Api.Models.Response.QuizSessionResult;

namespace Quizzer.Api.Models.Response.QuizSession;

public class QuizSessionUpdateResponseModel
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public IEnumerable<QuizSessionResultUpdateResponseModel>? QuizSessionResults { get; set; }
}