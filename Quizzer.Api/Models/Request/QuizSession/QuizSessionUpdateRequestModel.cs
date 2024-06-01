using Quizzer.Api.Models.Request.QuizSessionResult;

namespace Quizzer.Api.Models.Request.QuizSession;

public class QuizSessionUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public IEnumerable<QuizSessionResultUpdateRequestModel>? QuizSessionResults { get; set; }
}