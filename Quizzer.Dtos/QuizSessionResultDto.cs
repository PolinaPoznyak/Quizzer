namespace Quizzer.Dtos;

public class QuizSessionResultDto
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid QuizSessionId { get; set; }
    
    public int? Score { get; set; }
}