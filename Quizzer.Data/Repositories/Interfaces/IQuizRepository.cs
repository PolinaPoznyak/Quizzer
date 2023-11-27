using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizRepository : IRepository<Quiz>
{
    Task<IReadOnlyCollection<Quiz>> GetAllQuizzesAsync();
    Task<Quiz> GetQuizByIdAsync(Guid id);
}