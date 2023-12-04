namespace Quizzer.Entities;

public class QuizSessionResult
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid QuizSessionId { get; set; }
    
    public int? Score { get; set; }

    public User User { get; set; }
    
    public QuizSession QuizSession { get; set; }
    
    public ICollection<ResultDetails> ResultDetails { get; set; }
}
