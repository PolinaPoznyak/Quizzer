namespace Quizzer.Entities;

public class Question
{
    public Guid Id { get; set; }
    
    public Guid QuizId { get; set; }
    
    public string Text { get; set; }
    
    public string? QuestionType { get; set; }

    public Quiz Quiz { get; set; }
    
    public ICollection<QuizAnswer> Answers { get; set; }
    
    public ICollection<ResultDetails> ResultDetails { get; set; }
}