using Quizzer.Api.Models.Response.Questions;
using Quizzer.Api.Models.Response.QuizAnswer;

namespace Quizzer.Api.Models.Response.ResultDetails;

public class ResultDetailsGetResponseModel
{
    public Guid Id { get; set; }

    public Guid QuizSessionResultId { get; set; }
    
    public Guid QuestionId { get; set; }
    
    public Guid QuizAnswerId { get; set; }
    
    public int IsCorrect { get; set; }
    
    public QuestionGetResponseModel Question { get; set; }
    
    public QuizAnswerGetResponseModel QuizAnswer { get; set; }
}