using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IQuizAnswerService
{
    Task<QuizAnswerDto> CreateQuizAnswerAsync(QuizAnswerDto quizAnswerDto);
    Task<QuizAnswerDto> UpdateQuizAnswerAsync(QuizAnswerDto quizAnswerDto);
    Task<QuizAnswerDto> DeleteQuizAnswerAsync(Guid id);
    Task<QuizAnswerDto> GetQuizAnswerByIdAsync(Guid id);
    Task<IReadOnlyCollection<QuizAnswerDto>> GetAllQuizAnswersAsync();
}