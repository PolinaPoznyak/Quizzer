using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizSessionResultRepository : IRepository<QuizSessionResult>
{
    Task<QuizSessionResult> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<QuizSessionResult>> GetAllQuizSessionResultAsync();
}