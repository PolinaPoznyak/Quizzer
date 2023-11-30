namespace Quizzer.Api.Models.Request.QuizAnswer;

public class QuizAnswerCreateRequestModel
{
    public string AnswerText { get; set; }
    
    public bool IsCorrect { get; set; }
    
    public Guid QuestionId { get; set; }
}