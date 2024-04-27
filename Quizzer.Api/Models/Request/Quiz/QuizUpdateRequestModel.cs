using Quizzer.Api.Models.Request.Questions;
using Quizzer.Dtos;

namespace Quizzer.Api.Models.Request.Quiz;

public class QuizUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsMultiplayer { get; set; }
    
    public IEnumerable<QuestionUpdateRequestModel>? Questions { get; set; }
}