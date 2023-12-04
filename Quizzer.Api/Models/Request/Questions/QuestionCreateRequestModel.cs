namespace Quizzer.Api.Models.Request.Questions;

public class QuestionCreateRequestModel
{
    public string Text { get; set; }
    
    public string? QuestionType { get; set; }
    
    public Guid QuizId { get; set; }
}