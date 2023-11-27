using Quizzer.Dtos;

namespace Quizzer.Api.Models.Request.Quiz;

public class QuizUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
}