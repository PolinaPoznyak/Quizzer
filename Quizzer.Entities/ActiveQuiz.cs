namespace Quizzer.Entities;

public class ActiveQuiz
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid QuizId { get; set; }
    
    public Guid ResultId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }

    public User User { get; set; }
    
    public Quiz Quiz { get; set; }
    
    public UserResult? Result { get; set; }
}