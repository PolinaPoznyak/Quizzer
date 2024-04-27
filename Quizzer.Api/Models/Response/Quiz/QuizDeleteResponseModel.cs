using Quizzer.Api.Models.Response.Questions;
using Quizzer.Dtos;

namespace Quizzer.Api.Models.Response.Quiz;

public class QuizDeleteResponseModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsMultiplayer { get; set; }
    
    public IEnumerable<QuestionDeleteResponseModel>? Questions { get; set; }
}