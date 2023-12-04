namespace Quizzer.Entities;

public class QuizAnswer
{
    public Guid Id { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public string AnswerText { get; set; }
    
    public bool IsCorrect { get; set; }

    public Question Question { get; set; }
    
    public ICollection<ResultDetails> ResultDetails { get; set; }
}