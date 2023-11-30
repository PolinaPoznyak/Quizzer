namespace Quizzer.Api.Models.Response.QuizAnswer;

public class QuizAnswerCreateResponseModel
{
    public Guid Id { get; set; }
    
    public string AnswerText { get; set; }
    
    public bool IsCorrect { get; set; }
    
    public Guid QuestionId { get; set; }
}