namespace Quizzer.Entities;

public class QuizSession
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public int? QuizCode { get; set; }

    public Quiz Quiz { get; set; }
    
    public ICollection<QuizSessionResult> QuizSessionResults { get; set; }
}