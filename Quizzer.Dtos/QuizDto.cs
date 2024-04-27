namespace Quizzer.Dtos;

public class QuizDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsMultiplayer { get; set; }
    
    public Guid UserId { get; set; }
    
    public IEnumerable<QuestionDto>? Questions { get; set; }
    
}