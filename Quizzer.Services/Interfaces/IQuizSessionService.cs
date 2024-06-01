using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IQuizSessionService
{
    Task<QuizSessionDto> CreateQuizSessionAsync(QuizSessionDto quizSessionDto);
    Task<QuizSessionDto> UpdateQuizSessionAsync(QuizSessionDto quizSessionDto);
    Task UpdateQuizSessionStartDate(Guid quizSessionId, DateTime startDate);
    Task<QuizSessionDto> DeleteQuizSessionAsync(Guid id);
    Task<QuizSessionDto> GetQuizSessionByIdAsync(Guid id);
    Task<QuizSessionDto> GetQuizSessionByCodeAsync(int code);
    Task<IReadOnlyCollection<QuizSessionDto>> GetQuizSessionByQuizIdAsync(Guid id);
    Task<IReadOnlyCollection<QuizSessionDto>> GetAllQuizSessionsAsync();
    Task<IReadOnlyCollection<UserDto>> GetUsersInQuizSessionAsync(Guid quizSessionId);
}