using Quizzer.Api.Models.Request.Questions;
using Quizzer.Dtos;

namespace Quizzer.Api.Models.Request.Quiz;

public class QuizCreateRequestModel
{
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsMultiplayer { get; set; }
    
    public IEnumerable<QuestionCreateRequestModel>? Questions { get; set; }
}