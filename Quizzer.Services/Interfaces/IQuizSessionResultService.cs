using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IQuizSessionResultService
{
        Task<QuizSessionResultDto> CreateQuizSessionResultAsync(QuizSessionResultDto quizSessionResultDto);
        Task<QuizSessionResultDto> UpdateQuizSessionResultAsync(QuizSessionResultDto quizSessionResultDto);
        Task<QuizSessionResultDto> DeleteQuizSessionResultAsync(Guid id);
        Task<QuizSessionResultDto> GetQuizSessionResultByIdAsync(Guid id);
        Task<IReadOnlyCollection<QuizSessionResultDto>> GetAllQuizSessionResultsAsync();
}