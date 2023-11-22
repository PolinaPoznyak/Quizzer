namespace Quizzer.Dtos;

public class QuizDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public IEnumerable<QuestionDto>? Questions { get; set; }
    
    //public IEnumerable<ActiveQuizDto>? ActiveQuizzes { get; set; }
}