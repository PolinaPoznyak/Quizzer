using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IQuizSessionService
{
    Task<QuizSessionDto> CreateQuizSessionAsync(QuizSessionDto quizSessionDto);
    Task<QuizSessionDto> UpdateQuizSessionAsync(QuizSessionDto quizSessionDto);
    Task<QuizSessionDto> DeleteQuizSessionAsync(Guid id);
    Task<QuizSessionDto> GetQuizSessionByIdAsync(Guid id);
    Task<IReadOnlyCollection<QuizSessionDto>> GetQuizSessionByQuizIdAsync(Guid id);
    Task<IReadOnlyCollection<QuizSessionDto>> GetAllQuizSessionsAsync();
}