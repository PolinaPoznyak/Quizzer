namespace Quizzer.Api.Models.Response.Questions;

public class QuestionCreateResponseModel
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public string? QuestionType { get; set; }
    
    public Guid QuizId { get; set; }
}