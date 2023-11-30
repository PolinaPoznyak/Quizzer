namespace Quizzer.Dtos;

public class QuizAnswerDto
{
    public Guid Id { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public string AnswerText { get; set; }
    
    public bool IsCorrect { get; set; }
}