namespace Quizzer.Entities;

public class UserAnswer
{
    public Guid Id { get; set; }
    
    public string? AnswerText { get; set; }

    public UserResult UserResult { get; set; }
}