namespace Quizzer.Dtos;

public class QuizSessionDto
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public IEnumerable<QuizSessionResultDto>? QuizSessionResults { get; set; }
}