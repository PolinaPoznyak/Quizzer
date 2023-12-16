namespace Quizzer.Dtos;

public class QuestionDto
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public string? QuestionType { get; set; }

    public Guid QuizId { get; set; }
    
    public IEnumerable<QuizAnswerDto>? QuizAnswers { get; set; }
}