using Quizzer.Api.Models.Response.QuizSessionResult;

namespace Quizzer.Api.Models.Response.QuizSession;

public class QuizSessionDeleteResponseModel
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public int? QuizCode { get; set; }
    
    public IEnumerable<QuizSessionResultDeleteResponseModel>? QuizSessionResults { get; set; }
}