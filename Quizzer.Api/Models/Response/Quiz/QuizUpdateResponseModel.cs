using Quizzer.Dtos;

namespace Quizzer.Api.Models.Response.Quiz;

public class QuizUpdateResponseModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
}