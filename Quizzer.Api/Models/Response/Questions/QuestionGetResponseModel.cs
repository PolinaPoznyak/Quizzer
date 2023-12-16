using Quizzer.Api.Models.Response.QuizAnswer;

namespace Quizzer.Api.Models.Response.Questions;

public class QuestionGetResponseModel
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public string? QuestionType { get; set; }

    public Guid QuizId { get; set; }
    
    public IEnumerable<QuizAnswerGetResponseModel>? QuizAnswers { get; set; }
}