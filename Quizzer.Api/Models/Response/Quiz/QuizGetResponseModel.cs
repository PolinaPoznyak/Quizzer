using Quizzer.Dtos;

namespace Quizzer.Api.Models.Response.Quiz;

public class QuizGetResponseModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public IEnumerable<QuestionDto>? Questions { get; set; }
}