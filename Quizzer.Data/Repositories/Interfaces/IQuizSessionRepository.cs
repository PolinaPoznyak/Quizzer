using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizSessionRepository : IRepository<QuizSession>
{
    Task<QuizSession> GetByIdAsync(Guid id);
    Task<QuizSession> GetByCodeAsync(int quizCode);
    Task<IReadOnlyCollection<QuizSession>> GetQuizSessionByQuizIdAsync(Guid quizId);
    Task<IReadOnlyCollection<QuizSession>> GetAllQuizSessionsAsync();
}