namespace Quizzer.Dtos;

public class ResultDetailsDto
{
    public Guid Id { get; set; }

    public Guid QuizSessionResultId { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public Guid QuizAnswerId { get; set; }
    
    public int IsCorrect { get; set; }
}