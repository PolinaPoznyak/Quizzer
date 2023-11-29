namespace Quizzer.Api.Models.Request.Questions;

public class QuestionUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public string? QuestionType { get; set; }
    
    public Guid QuizId { get; set; }
}