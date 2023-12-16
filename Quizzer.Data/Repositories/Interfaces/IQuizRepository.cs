using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizRepository : IRepository<Quiz>
{
    Task<IReadOnlyCollection<Quiz>> GetAllQuizzesAsync();
    Task<IReadOnlyCollection<Quiz>> GetQuizzesByUserIdAsync(Guid id);
    Task<IReadOnlyCollection<Quiz>> GetQuizzesByTitleAsync(string title);
    Task<Quiz> GetQuizByIdAsync(Guid id);
}