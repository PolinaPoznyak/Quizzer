using Quizzer.Dtos;

namespace Quizzer.Api.Models.Response.Quiz;

public class QuizCreateResponseModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
}