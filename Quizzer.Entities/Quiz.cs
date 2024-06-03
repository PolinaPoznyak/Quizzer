namespace Quizzer.Entities;

public class Quiz
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? QuizPicture { get; set; }
    
    public bool IsMultiplayer { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; }
    
    public ICollection<Question>? Questions { get; set; }
    
    public ICollection<QuizSession>? QuizSessions { get; set; }
}