namespace Quizzer.Api.Models.Request.QuizAnswer;

public class QuizAnswerUpdateRequestModel
{
    public Guid Id { get; set; }
    
    public string AnswerText { get; set; }
    
    public bool IsCorrect { get; set; }
    
    public Guid QuestionId { get; set; }
}