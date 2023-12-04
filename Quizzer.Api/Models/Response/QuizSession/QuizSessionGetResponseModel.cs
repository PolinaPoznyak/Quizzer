using Quizzer.Api.Models.Response.QuizSessionResult;

namespace Quizzer.Api.Models.Response.QuizSession;

public class QuizSessionGetResponseModel
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public IEnumerable<QuizSessionResultGetResponseModel>? QuizSessionResults { get; set; }
}