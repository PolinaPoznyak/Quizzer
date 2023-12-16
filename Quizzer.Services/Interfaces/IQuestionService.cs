using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto);
    Task<QuestionDto> UpdateQuestionAsync(QuestionDto questionDto);
    Task<QuestionDto> DeleteQuestionAsync(Guid id);
    Task<QuestionDto> GetQuestionByIdAsync(Guid id);
    Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
    Task<IEnumerable<QuestionDto>> UpdateQuestionsInQuizAsync(Guid quizId, IEnumerable<QuestionDto> updatedQuestions);
}