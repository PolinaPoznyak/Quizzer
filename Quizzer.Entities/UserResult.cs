namespace Quizzer.Entities;

public class UserResult
{
    public Guid Id { get; set; }
    
    public Guid? UserAnswerId { get; set; }
    
    public int? Score { get; set; }

    public ActiveQuiz ActiveQuiz { get; set; }
    
    public UserAnswer UserAnswer { get; set; }
}