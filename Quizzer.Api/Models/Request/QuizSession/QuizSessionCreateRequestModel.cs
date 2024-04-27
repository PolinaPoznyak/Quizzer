using Quizzer.Api.Models.Request.QuizSessionResult;

namespace Quizzer.Api.Models.Request.QuizSession;

public class QuizSessionCreateRequestModel
{
    public Guid QuizId { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public int? QuizCode { get; set; }
    
    public IEnumerable<QuizSessionResultCreateRequestModel>? QuizSessionResults { get; set; }
}