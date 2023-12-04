namespace Quizzer.Entities;

public class ResultDetails
{
    public Guid Id { get; set; }

    public Guid QuizSessionResultId { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public Guid QuizAnswerId { get; set; }
    
    public int IsCorrect { get; set; }
    
    public QuizSessionResult QuizSessionResult { get; set; }
    
    public Question Question { get; set; }
    
    public QuizAnswer QuizAnswer { get; set; }
}