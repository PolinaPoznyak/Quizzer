using Quizzer.Api.Models.Response.QuizSessionResult;

namespace Quizzer.Api.Models.Response.QuizSession;

public class QuizSessionCreateResponseModel
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public int? QuizCode { get; set; }
    
    public IEnumerable<QuizSessionResultCreateResponseModel>? QuizSessionResults { get; set; }
}