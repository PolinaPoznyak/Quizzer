using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto);
    Task<QuestionDto> UpdateQuestionAsync(QuestionDto questionDto);
    Task<QuestionDto> DeleteQuestionAsync(Guid id);
    
    Task<QuestionDto> GetQuestionByIdAsync(Guid id);
}