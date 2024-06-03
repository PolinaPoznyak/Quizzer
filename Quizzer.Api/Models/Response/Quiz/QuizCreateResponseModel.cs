using Quizzer.Api.Models.Response.Questions;
using Quizzer.Dtos;

namespace Quizzer.Api.Models.Response.Quiz;

public class QuizCreateResponseModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? QuizPicture { get; set; }
    
    public bool IsMultiplayer { get; set; }
    
    public IEnumerable<QuestionCreateResponseModel>? Questions { get; set; }
}